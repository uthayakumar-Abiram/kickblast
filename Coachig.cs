using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace kickvlast
{
    public partial class Coachig : Form
    {
        // Adjust connection string as needed
        private readonly SqlConnection con = new SqlConnection("Data Source=ABIRAM\\SQLEXPRESS01;Initial Catalog=ksb;Integrated Security=True;Trust Server Certificate=True");
        private readonly List<CoachingRecord> records = new();
        private int? editingId = null;

        // Pricing constants
        private const decimal BeginnerWeekly = 250.00m;
        private const decimal IntermediateWeekly = 300.00m;
        private const decimal EliteWeekly = 350.00m;
        private const decimal PrivateHourRate = 90.50m;
        private const decimal CompetitionFee = 220.00m;

        public Coachig()
        {
            InitializeComponent();

            // CoachingID is identity, don't allow user to edit it
            try { textBoxCoachingID.ReadOnly = true; } catch { }

            // Wire recalculation events
            numericWeeksTraining.ValueChanged += (_, _) => { UpdateTrainingEnd(); RecalculateAmounts(); };
            numericWeeksPrivate.ValueChanged += (_, _) => { UpdatePrivateEnd(); RecalculateAmounts(); };
            numericPrivateHours.ValueChanged += (_, _) => RecalculateAmounts();
            numericAmountTraining.ValueChanged += (_, _) => RecalculateAmounts();
            comboBoxTrainingPlan.SelectedIndexChanged += (_, _) => RecalculateAmounts();
            chkWeeksAsMonths.CheckedChanged += (_, _) => { UpdateTrainingEnd(); UpdatePrivateEnd(); RecalculateAmounts(); };
            numericNoOfCompetition.ValueChanged += (_, _) => RecalculateAmounts();

            // Wire button clicks
            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;

            // Wire start date changes to update ends
            dateTimePickerTrainingStart.ValueChanged += (_, _) => UpdateTrainingEnd();
            dateTimePickerPrivateStart.ValueChanged += (_, _) => UpdatePrivateEnd();
        }

        private decimal GetWeeklyFee(string plan)
        {
            if (string.IsNullOrWhiteSpace(plan)) return 0m;
            plan = plan.Trim().ToLowerInvariant();
            return plan switch
            {
                "beginner" => BeginnerWeekly,
                "intermediate" => IntermediateWeekly,
                "elite" => EliteWeekly,
                _ => 0m
            };
        }

        // PSEUDO-CODE:
        // 1. If end < start or trainingAmount <= 0 return empty map
        // 2. Compute totalDays = inclusive days between start and end
        // 3. For each month between start.Month and end.Month:
        //    a. monthStart = first day of that month
        //    b. monthEnd = last day of that month
        //    c. segStart = max(start, monthStart)
        //    d. segEnd = min(end, monthEnd)
        //    e. if segEnd >= segStart: daysInSegment = inclusive days between segStart and segEnd
        //       allocate monthAmount = trainingAmount * daysInSegment / totalDays
        //    f. store monthAmount keyed by the month's first day
        // 4. Because of rounding, adjust the last month's amount so that the sum equals trainingAmount
        // 5. Return the map of month -> allocated amount
        
        // Implementation: allocate trainingAmount across calendar months proportionally by covered days
        private Dictionary<DateTime, decimal> CalculateMonthlyTrainingFees(DateTime start, DateTime end, decimal trainingAmount)
        {
            var result = new Dictionary<DateTime, decimal>();
            try
            {
                if (trainingAmount <= 0m) return result;
                if (end.Date < start.Date) return result;

                // inclusive total days
                var totalDays = (end.Date - start.Date).TotalDays + 1;
                if (totalDays <= 0) return result;

                // iterate months from start's month to end's month
                var cursor = new DateTime(start.Year, start.Month, 1);
                var lastMonth = new DateTime(end.Year, end.Month, 1);

                while (cursor <= lastMonth)
                {
                    var monthStart = new DateTime(cursor.Year, cursor.Month, 1);
                    var monthEnd = monthStart.AddMonths(1).AddDays(-1);

                    var segStart = start.Date > monthStart ? start.Date : monthStart;
                    var segEnd = end.Date < monthEnd ? end.Date : monthEnd;

                    if (segEnd >= segStart)
                    {
                        var daysInSegment = (segEnd - segStart).TotalDays + 1;
                        var amount = Math.Round(trainingAmount * (decimal)daysInSegment / (decimal)totalDays, 2);
                        result[monthStart] = amount;
                    }

                    cursor = cursor.AddMonths(1);
                }

                // correct rounding drift so sum(result) == trainingAmount
                var sum = result.Values.Sum();
                var diff = trainingAmount - sum;
                if (result.Count > 0 && diff != 0m)
                {
                    // add the difference to the last month
                    var lastKey = result.Keys.Max();
                    result[lastKey] = result[lastKey] + diff;
                }
            }
            catch
            {
                // ignore and return whatever we built
            }

            return result;
        }

        // Accept optional sender/eventargs so this can be used as an event handler
        private void RecalculateAmounts(object? sender = null, EventArgs? e = null)
        {
            try
            {
                var multiplier = chkWeeksAsMonths.Checked ? 4 : 1;

                var weeksTraining = (int)numericWeeksTraining.Value * multiplier;
                var plan = comboBoxTrainingPlan.SelectedItem?.ToString() ?? string.Empty;
                var weeklyFee = GetWeeklyFee(plan);
                var trainingAmount = weeklyFee * weeksTraining;

                // Private coaching: hours per week limited to 5
                // ensure private hours is integer and within [0,5]
                var hoursPerWeekDecimal = numericPrivateHours.Value;
                var hoursPerWeek = Math.Min(5, Math.Max(0, decimal.ToInt32(hoursPerWeekDecimal)));
                // reflect rounding back to control (so UI shows integer)
                if (numericPrivateHours.Value != hoursPerWeek) numericPrivateHours.Value = hoursPerWeek;
                var weeksPrivate = (int)numericWeeksPrivate.Value * multiplier;
                var totalPrivateHours = hoursPerWeek * weeksPrivate;
                var privateAmount = totalPrivateHours * PrivateHourRate;

                // Competition fees
                var competitions = (int)numericNoOfCompetition.Value;
                var competitionAmount = competitions * CompetitionFee;

                // Apply to numeric controls (clamp to max)
                numericAmountTraining.Value = Math.Min(trainingAmount, numericAmountTraining.Maximum);
                numericAmountCoaching.Value = Math.Min(privateAmount, numericAmountCoaching.Maximum);
                var total = trainingAmount + privateAmount + competitionAmount;
                numericTotalAmount.Value = Math.Min(total, numericTotalAmount.Maximum);
            }
            catch
            {
                // ignore transient UI parse errors
            }
        }

        private void UpdateTrainingEnd()
        {
            try
            {
                var multiplier = chkWeeksAsMonths.Checked ? 4 : 1;
                var weeks = (int)numericWeeksTraining.Value * multiplier;
                if (weeks <= 0)
                {
                    dateTimePickerTrainingEnd.Value = dateTimePickerTrainingStart.Value.Date;
                    return;
                }

                var end = dateTimePickerTrainingStart.Value.Date.AddDays(weeks * 7L).AddDays(-1);
                if (end < dateTimePickerTrainingStart.MinDate) end = dateTimePickerTrainingStart.MinDate;
                if (end > dateTimePickerTrainingStart.MaxDate) end = dateTimePickerTrainingStart.MaxDate;
                dateTimePickerTrainingEnd.Value = end;
            }
            catch { }
        }

        private void UpdatePrivateEnd()
        {
            try
            {
                var multiplier = chkWeeksAsMonths.Checked ? 4 : 1;
                var weeks = (int)numericWeeksPrivate.Value * multiplier;
                if (weeks <= 0)
                {
                    dateTimePickerPrivateEnd.Value = dateTimePickerPrivateStart.Value.Date;
                    return;
                }

                var end = dateTimePickerPrivateStart.Value.Date.AddDays(weeks * 7L).AddDays(-1);
                if (end < dateTimePickerPrivateStart.MinDate) end = dateTimePickerPrivateStart.MinDate;
                if (end > dateTimePickerPrivateStart.MaxDate) end = dateTimePickerPrivateStart.MaxDate;
                dateTimePickerPrivateEnd.Value = end;
            }
            catch { }
        }

        private void LoadAthletes()
        {
            comboBoxAthlete.Items.Clear();
            const string q = "SELECT AthleteID, AthleteName, ContactNo, CurrentWeight, WeightCategory FROM Athlete";
            using var cmd = new SqlCommand(q, con);
            try
            {
                con.Open();
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var id = r["AthleteID"] != DBNull.Value ? Convert.ToInt32(r["AthleteID"]) : 0;
                    var name = r["AthleteName"]?.ToString() ?? string.Empty;
                    var contact = r["ContactNo"]?.ToString() ?? string.Empty;
                    var weight = r["CurrentWeight"] != DBNull.Value ? Convert.ToDecimal(r["CurrentWeight"]) : 0m;
                    var cat = r["WeightCategory"]?.ToString() ?? string.Empty;
                    comboBoxAthlete.Items.Add(new ComboItem(id, name, contact, weight, cat));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load athletes: " + ex.Message);
            }
            finally { if (con.State == System.Data.ConnectionState.Open) con.Close(); }
        }

        private void LoadTrainers()
        {
            comboBoxTrainer.Items.Clear();
            const string q = "SELECT id, Trainer_Name FROM Trainer";
            using var cmd = new SqlCommand(q, con);
            try
            {
                con.Open();
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var id = r["id"] != DBNull.Value ? Convert.ToInt32(r["id"]) : 0;
                    var name = r["Trainer_Name"]?.ToString() ?? string.Empty;
                    comboBoxTrainer.Items.Add(new ComboItem(id, name));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load trainers: " + ex.Message);
            }
            finally { if (con.State == System.Data.ConnectionState.Open) con.Close(); }
        }

        private void comboBoxAthlete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAthlete.SelectedItem is ComboItem it)
            {
                textBoxAthleteName.Text = it.Text;
                textBoxAthleteContact.Text = it.Contact;
                numericCurrentWeight.Value = it.Weight;
                textBoxWeightCategory.Text = it.Category;
                RecalculateAmounts();
            }
        }

        private void comboBoxTrainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTrainer.SelectedItem is ComboItem it)
            {
                textBoxTrainerName.Text = it.Text;
            }
        }

        private void LoadCoachingFromDatabase()
        {
            records.Clear();
            const string q = @"SELECT CoachingID, CreationDate, AthleteID, AthleteName, AthleteContact, CurrentWeight, WeightCategory, TrainerID, TrainerName, TrainingPlan, TrainingStart, TrainingEnd, WeeksTraining, AmountTraining, PrivateHours, PrivateStart, PrivateEnd, WeeksPrivate, AmountCoaching, NoOfCompetition, TotalAmount FROM Coaching";
            using var cmd = new SqlCommand(q, con);
            try
            {
                con.Open();
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var rec = new CoachingRecord
                    {
                        CoachingID = r["CoachingID"] != DBNull.Value ? Convert.ToInt32(r["CoachingID"]) : 0,
                        CreationDate = r["CreationDate"] != DBNull.Value ? Convert.ToDateTime(r["CreationDate"]) : DateTime.MinValue,
                        AthleteID = r["AthleteID"] != DBNull.Value ? Convert.ToInt32(r["AthleteID"]) : 0,
                        AthleteName = r["AthleteName"]?.ToString() ?? string.Empty,
                        AthleteContact = r["AthleteContact"]?.ToString() ?? string.Empty,
                        CurrentWeight = r["CurrentWeight"] != DBNull.Value ? Convert.ToDecimal(r["CurrentWeight"]) : 0m,
                        WeightCategory = r["WeightCategory"]?.ToString() ?? string.Empty,
                        TrainerID = r["TrainerID"] != DBNull.Value ? Convert.ToInt32(r["TrainerID"]) : 0,
                        TrainerName = r["TrainerName"]?.ToString() ?? string.Empty,
                        TrainingPlan = r["TrainingPlan"]?.ToString() ?? string.Empty,
                        TrainingStart = r["TrainingStart"] != DBNull.Value ? Convert.ToDateTime(r["TrainingStart"]) : DateTime.MinValue,
                        TrainingEnd = r["TrainingEnd"] != DBNull.Value ? Convert.ToDateTime(r["TrainingEnd"]) : DateTime.MinValue,
                        WeeksTraining = r["WeeksTraining"] != DBNull.Value ? Convert.ToInt32(r["WeeksTraining"]) : 0,
                        AmountTraining = r["AmountTraining"] != DBNull.Value ? Convert.ToDecimal(r["AmountTraining"]) : 0m,
                        PrivateHours = r["PrivateHours"] != DBNull.Value ? Convert.ToDecimal(r["PrivateHours"]) : 0m,
                        PrivateStart = r["PrivateStart"] != DBNull.Value ? Convert.ToDateTime(r["PrivateStart"]) : DateTime.MinValue,
                        PrivateEnd = r["PrivateEnd"] != DBNull.Value ? Convert.ToDateTime(r["PrivateEnd"]) : DateTime.MinValue,
                        WeeksPrivate = r["WeeksPrivate"] != DBNull.Value ? Convert.ToInt32(r["WeeksPrivate"]) : 0,
                        AmountCoaching = r["AmountCoaching"] != DBNull.Value ? Convert.ToDecimal(r["AmountCoaching"]) : 0m,
                        NoOfCompetition = r["NoOfCompetition"] != DBNull.Value ? Convert.ToInt32(r["NoOfCompetition"]) : 0,
                        TotalAmount = r["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(r["TotalAmount"]) : 0m
                    };
                    records.Add(rec);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load coaching data: " + ex.Message);
            }
            finally { if (con.State == System.Data.ConnectionState.Open) con.Close(); }

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvCoaching.Rows.Clear();
            foreach (var rec in records)
            {
                dgvCoaching.Rows.Add(
                    rec.CoachingID,
                    rec.CreationDate == DateTime.MinValue ? string.Empty : rec.CreationDate.ToShortDateString(),
                    rec.AthleteID,
                    rec.AthleteName,
                    rec.AthleteContact,
                    rec.CurrentWeight.ToString("F2"),
                    rec.WeightCategory,
                    rec.TrainerID,
                    rec.TrainerName,
                    rec.TrainingPlan,
                    rec.TrainingStart == DateTime.MinValue ? string.Empty : rec.TrainingStart.ToShortDateString(),
                    rec.TrainingEnd == DateTime.MinValue ? string.Empty : rec.TrainingEnd.ToShortDateString(),
                    rec.WeeksTraining,
                    rec.AmountTraining.ToString("F2"),
                    rec.PrivateHours.ToString("F2"),
                    rec.PrivateStart == DateTime.MinValue ? string.Empty : rec.PrivateStart.ToShortDateString(),
                    rec.PrivateEnd == DateTime.MinValue ? string.Empty : rec.PrivateEnd.ToShortDateString(),
                    rec.WeeksPrivate,
                    rec.AmountCoaching.ToString("F2"),
                    rec.TotalAmount.ToString("F2")
                );
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Recalculate amounts for UI
            RecalculateAmounts();

            // Compute amounts deterministically here (do not rely on UI numeric controls for final value)
            var multiplier = chkWeeksAsMonths.Checked ? 4 : 1;
            var weeksTraining = (int)numericWeeksTraining.Value * multiplier;
            var plan = comboBoxTrainingPlan.SelectedItem?.ToString() ?? string.Empty;
            var weeklyFee = GetWeeklyFee(plan);
            var trainingAmount = weeklyFee * weeksTraining;

            var hoursPerWeek = numericPrivateHours.Value;
            if (hoursPerWeek > 5) hoursPerWeek = 5;
            var weeksPrivate = (int)numericWeeksPrivate.Value * multiplier;
            var totalPrivateHours = hoursPerWeek * weeksPrivate;
            var privateAmount = totalPrivateHours * PrivateHourRate;

            int competitionsCount = 0;
            // For insert, competitions should start at 0. For update, preserve existing DB value.
            if (editingId == null)
            {
                competitionsCount = 0;
            }
            else
            {
                // read existing NoOfCompetition from DB to avoid changing via UI
                try
                {
                    const string qSel = "SELECT NoOfCompetition FROM Coaching WHERE CoachingID = @id";
                    using var selCmd = new SqlCommand(qSel, con);
                    selCmd.Parameters.AddWithValue("@id", editingId.Value);
                    con.Open();
                    var obj = selCmd.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out var v)) competitionsCount = v;
                }
                catch
                {
                    // ignore and leave as 0
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }
            }

            var competitionAmount = competitionsCount * CompetitionFee;
            var totalAmount = trainingAmount + privateAmount + competitionAmount;

            // Build record from UI
            var rec = new CoachingRecord
            {
                CreationDate = dateTimePickerCreation.Value.Date,
                AthleteID = comboBoxAthlete.SelectedItem is ComboItem a ? a.Id : 0,
                AthleteName = textBoxAthleteName.Text ?? string.Empty,
                AthleteContact = textBoxAthleteContact.Text ?? string.Empty,
                CurrentWeight = numericCurrentWeight.Value,
                WeightCategory = textBoxWeightCategory.Text ?? string.Empty,
                TrainerID = comboBoxTrainer.SelectedItem is ComboItem t ? t.Id : 0,
                TrainerName = textBoxTrainerName.Text ?? string.Empty,
                TrainingPlan = comboBoxTrainingPlan.SelectedItem?.ToString() ?? string.Empty,
                TrainingStart = dateTimePickerTrainingStart.Value.Date,
                TrainingEnd = dateTimePickerTrainingEnd.Value.Date,
                WeeksTraining = (int)numericWeeksTraining.Value,
                AmountTraining = trainingAmount,
                PrivateHours = numericPrivateHours.Value,
                PrivateStart = dateTimePickerPrivateStart.Value.Date,
                PrivateEnd = dateTimePickerPrivateEnd.Value.Date,
                WeeksPrivate = (int)numericWeeksPrivate.Value,
                AmountCoaching = privateAmount,
                NoOfCompetition = competitionsCount,
                TotalAmount = totalAmount
            };

            if (editingId == null)
            {
                // Insert
                const string q = @"INSERT INTO Coaching (CreationDate, AthleteID, AthleteName, AthleteContact, CurrentWeight, WeightCategory, TrainerID, TrainerName, TrainingPlan, TrainingStart, TrainingEnd, WeeksTraining, AmountTraining, PrivateHours, PrivateStart, PrivateEnd, WeeksPrivate, AmountCoaching, NoOfCompetition, TotalAmount) VALUES (@CreationDate,@AthleteID,@AthleteName,@AthleteContact,@CurrentWeight,@WeightCategory,@TrainerID,@TrainerName,@TrainingPlan,@TrainingStart,@TrainingEnd,@WeeksTraining,@AmountTraining,@PrivateHours,@PrivateStart,@PrivateEnd,@WeeksPrivate,@AmountCoaching,@NoOfCompetition,@TotalAmount); SELECT SCOPE_IDENTITY();";
                using var cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@CreationDate", rec.CreationDate);
                cmd.Parameters.AddWithValue("@AthleteID", rec.AthleteID);
                cmd.Parameters.AddWithValue("@AthleteName", rec.AthleteName);
                cmd.Parameters.AddWithValue("@AthleteContact", rec.AthleteContact);
                cmd.Parameters.AddWithValue("@CurrentWeight", rec.CurrentWeight);
                cmd.Parameters.AddWithValue("@WeightCategory", rec.WeightCategory);
                cmd.Parameters.AddWithValue("@TrainerID", rec.TrainerID);
                cmd.Parameters.AddWithValue("@TrainerName", rec.TrainerName);
                cmd.Parameters.AddWithValue("@TrainingPlan", rec.TrainingPlan);
                cmd.Parameters.AddWithValue("@TrainingStart", rec.TrainingStart);
                cmd.Parameters.AddWithValue("@TrainingEnd", rec.TrainingEnd);
                cmd.Parameters.AddWithValue("@WeeksTraining", rec.WeeksTraining);
                cmd.Parameters.AddWithValue("@AmountTraining", rec.AmountTraining);
                cmd.Parameters.AddWithValue("@PrivateHours", rec.PrivateHours);
                cmd.Parameters.AddWithValue("@PrivateStart", rec.PrivateStart);
                cmd.Parameters.AddWithValue("@PrivateEnd", rec.PrivateEnd);
                cmd.Parameters.AddWithValue("@WeeksPrivate", rec.WeeksPrivate);
                cmd.Parameters.AddWithValue("@AmountCoaching", rec.AmountCoaching);
                cmd.Parameters.AddWithValue("@NoOfCompetition", 0); // new coaching starts with 0 competitions
                cmd.Parameters.AddWithValue("@TotalAmount", rec.TotalAmount);

                try
                {
                    con.Open();
                    var obj = cmd.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out var newId))
                    {
                        rec.CoachingID = newId;
                    }
                    MessageBox.Show("Coaching saved.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save coaching: " + ex.Message);
                }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else
            {
                // Update: preserve NoOfCompetition from DB
                int existingCompetitions = rec.NoOfCompetition;
                try
                {
                    const string qSel = "SELECT NoOfCompetition FROM Coaching WHERE CoachingID = @id";
                    using var selCmd = new SqlCommand(qSel, con);
                    selCmd.Parameters.AddWithValue("@id", editingId.Value);
                    con.Open();
                    var obj = selCmd.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out var val)) existingCompetitions = val;
                }
                catch
                {
                    // ignore, keep rec.NoOfCompetition
                }
                finally { if (con.State == System.Data.ConnectionState.Open) con.Close(); }

                const string q = @"UPDATE Coaching SET CreationDate=@CreationDate, AthleteID=@AthleteID, AthleteName=@AthleteName, AthleteContact=@AthleteContact, CurrentWeight=@CurrentWeight, WeightCategory=@WeightCategory, TrainerID=@TrainerID, TrainerName=@TrainerName, TrainingPlan=@TrainingPlan, TrainingStart=@TrainingStart, TrainingEnd=@TrainingEnd, WeeksTraining=@WeeksTraining, AmountTraining=@AmountTraining, PrivateHours=@PrivateHours, PrivateStart=@PrivateStart, PrivateEnd=@PrivateEnd, WeeksPrivate=@WeeksPrivate, AmountCoaching=@AmountCoaching, NoOfCompetition=@NoOfCompetition, TotalAmount=@TotalAmount WHERE CoachingID=@CoachingID";
                using var cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@CreationDate", rec.CreationDate);
                cmd.Parameters.AddWithValue("@AthleteID", rec.AthleteID);
                cmd.Parameters.AddWithValue("@AthleteName", rec.AthleteName);
                cmd.Parameters.AddWithValue("@AthleteContact", rec.AthleteContact);
                cmd.Parameters.AddWithValue("@CurrentWeight", rec.CurrentWeight);
                cmd.Parameters.AddWithValue("@WeightCategory", rec.WeightCategory);
                cmd.Parameters.AddWithValue("@TrainerID", rec.TrainerID);
                cmd.Parameters.AddWithValue("@TrainerName", rec.TrainerName);
                cmd.Parameters.AddWithValue("@TrainingPlan", rec.TrainingPlan);
                cmd.Parameters.AddWithValue("@TrainingStart", rec.TrainingStart);
                cmd.Parameters.AddWithValue("@TrainingEnd", rec.TrainingEnd);
                cmd.Parameters.AddWithValue("@WeeksTraining", rec.WeeksTraining);
                cmd.Parameters.AddWithValue("@AmountTraining", rec.AmountTraining);
                cmd.Parameters.AddWithValue("@PrivateHours", rec.PrivateHours);
                cmd.Parameters.AddWithValue("@PrivateStart", rec.PrivateStart);
                cmd.Parameters.AddWithValue("@PrivateEnd", rec.PrivateEnd);
                cmd.Parameters.AddWithValue("@WeeksPrivate", rec.WeeksPrivate);
                cmd.Parameters.AddWithValue("@AmountCoaching", rec.AmountCoaching);
                cmd.Parameters.AddWithValue("@NoOfCompetition", existingCompetitions);
                cmd.Parameters.AddWithValue("@TotalAmount", (rec.AmountTraining + rec.AmountCoaching + existingCompetitions * CompetitionFee));
                cmd.Parameters.AddWithValue("@CoachingID", editingId.Value);

                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0) MessageBox.Show("Coaching updated.");
                    else MessageBox.Show("No record updated.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update: " + ex.Message);
                }
                finally { if (con.State == ConnectionState.Open) con.Close(); }

                editingId = null;
            }

            LoadCoachingFromDatabase();
            ClearInputs();
        }

        private void ClearInputs()
        {
            textBoxCoachingID.Text = string.Empty;
            dateTimePickerCreation.Value = DateTime.Now;
            comboBoxAthlete.SelectedIndex = -1;
            textBoxAthleteName.Text = string.Empty;
            textBoxAthleteContact.Text = string.Empty;
            numericCurrentWeight.Value = 0;
            textBoxWeightCategory.Text = string.Empty;
            comboBoxTrainer.SelectedIndex = -1;
            textBoxTrainerName.Text = string.Empty;
            comboBoxTrainingPlan.SelectedIndex = -1;
            dateTimePickerTrainingStart.Value = DateTime.Now;
            dateTimePickerTrainingEnd.Value = DateTime.Now;
            numericWeeksTraining.Value = 0;
            numericAmountTraining.Value = 0;
            numericPrivateHours.Value = 0;
            dateTimePickerPrivateStart.Value = DateTime.Now;
            dateTimePickerPrivateEnd.Value = DateTime.Now;
            numericWeeksPrivate.Value = 0;
            numericAmountCoaching.Value = 0;
            numericNoOfCompetition.Value = 0;
            numericTotalAmount.Value = 0;
            editingId = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dgvCoaching_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var col = dgvCoaching.Columns[e.ColumnIndex].Name;
            var idObj = dgvCoaching.Rows[e.RowIndex].Cells[0].Value;
            if (idObj == null) return;
            if (!int.TryParse(idObj.ToString(), out var id)) return;

            if (col == "ViewCol")
            {
                // prefer to populate inputs from the in-memory record so we get all fields (including NoOfCompetition)
                var rec = records.Find(x => x.CoachingID == id);
                if (rec != null)
                {
                    editingId = id;
                    textBoxCoachingID.Text = rec.CoachingID.ToString();
                    dateTimePickerCreation.Value = rec.CreationDate == DateTime.MinValue ? DateTime.Now : rec.CreationDate;

                    // select athlete combo
                    for (int i = 0; i < comboBoxAthlete.Items.Count; i++)
                    {
                        if (((ComboItem)comboBoxAthlete.Items[i]).Id == rec.AthleteID)
                        {
                            comboBoxAthlete.SelectedIndex = i; break;
                        }
                    }

                    textBoxAthleteName.Text = rec.AthleteName;
                    textBoxAthleteContact.Text = rec.AthleteContact;
                    numericCurrentWeight.Value = rec.CurrentWeight;
                    textBoxWeightCategory.Text = rec.WeightCategory;

                    // trainer
                    for (int i = 0; i < comboBoxTrainer.Items.Count; i++)
                    {
                        if (((ComboItem)comboBoxTrainer.Items[i]).Id == rec.TrainerID)
                        {
                            comboBoxTrainer.SelectedIndex = i; break;
                        }
                    }
                    textBoxTrainerName.Text = rec.TrainerName;

                    if (!string.IsNullOrEmpty(rec.TrainingPlan) && comboBoxTrainingPlan.Items.Contains(rec.TrainingPlan)) comboBoxTrainingPlan.SelectedItem = rec.TrainingPlan; else comboBoxTrainingPlan.SelectedIndex = -1;

                    dateTimePickerTrainingStart.Value = rec.TrainingStart == DateTime.MinValue ? DateTime.Now : rec.TrainingStart;
                    dateTimePickerTrainingEnd.Value = rec.TrainingEnd == DateTime.MinValue ? DateTime.Now : rec.TrainingEnd;
                    numericWeeksTraining.Value = rec.WeeksTraining;
                    numericAmountTraining.Value = Math.Min(rec.AmountTraining, numericAmountTraining.Maximum);

                    numericPrivateHours.Value = Math.Min(rec.PrivateHours, numericPrivateHours.Maximum);
                    dateTimePickerPrivateStart.Value = rec.PrivateStart == DateTime.MinValue ? DateTime.Now : rec.PrivateStart;
                    dateTimePickerPrivateEnd.Value = rec.PrivateEnd == DateTime.MinValue ? DateTime.Now : rec.PrivateEnd;
                    numericWeeksPrivate.Value = rec.WeeksPrivate;
                    numericAmountCoaching.Value = Math.Min(rec.AmountCoaching, numericAmountCoaching.Maximum);

                    numericNoOfCompetition.Value = rec.NoOfCompetition;
                    numericTotalAmount.Value = Math.Min(rec.TotalAmount, numericTotalAmount.Maximum);

                    // prevent changing coaching id when editing
                    try { textBoxCoachingID.ReadOnly = true; } catch { }
                }
                else
                {
                    // fallback: previous behavior reading from grid cells
                    var row = dgvCoaching.Rows[e.RowIndex];
                    editingId = id;
                    textBoxCoachingID.Text = row.Cells[0].Value?.ToString();
                    dateTimePickerCreation.Value = DateTime.TryParse(row.Cells[1].Value?.ToString(), out var cd) ? cd : DateTime.Now;
                    // find athlete in combo
                    var aid = int.TryParse(row.Cells[2].Value?.ToString(), out var aidv) ? aidv : 0;
                    for (int i = 0; i < comboBoxAthlete.Items.Count; i++)
                    {
                        if (((ComboItem)comboBoxAthlete.Items[i]).Id == aid)
                        {
                            comboBoxAthlete.SelectedIndex = i; break;
                        }
                    }
                    var plan = row.Cells[9].Value?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(plan) && comboBoxTrainingPlan.Items.Contains(plan)) comboBoxTrainingPlan.SelectedItem = plan; else comboBoxTrainingPlan.SelectedIndex = -1;
                    dateTimePickerTrainingStart.Value = DateTime.TryParse(row.Cells[10].Value?.ToString(), out var ts) ? ts : DateTime.Now;
                    dateTimePickerTrainingEnd.Value = DateTime.TryParse(row.Cells[11].Value?.ToString(), out var te) ? te : DateTime.Now;
                    numericWeeksTraining.Value = int.TryParse(row.Cells[12].Value?.ToString(), out var w) ? w : 0;
                    numericAmountTraining.Value = decimal.TryParse(row.Cells[13].Value?.ToString(), out var at) ? at : 0;
                    numericPrivateHours.Value = decimal.TryParse(row.Cells[14].Value?.ToString(), out var ph) ? ph : 0;
                    dateTimePickerPrivateStart.Value = DateTime.TryParse(row.Cells[15].Value?.ToString(), out var ps) ? ps : DateTime.Now;
                    dateTimePickerPrivateEnd.Value = DateTime.TryParse(row.Cells[16].Value?.ToString(), out var pe) ? pe : DateTime.Now;
                    numericWeeksPrivate.Value = int.TryParse(row.Cells[17].Value?.ToString(), out var wp) ? wp : 0;
                    numericAmountCoaching.Value = decimal.TryParse(row.Cells[18].Value?.ToString(), out var ac) ? ac : 0;
                    numericNoOfCompetition.Value = int.TryParse(row.Cells[19].Value?.ToString(), out var nc) ? nc : 0;
                    numericTotalAmount.Value = decimal.TryParse(row.Cells[20].Value?.ToString(), out var ta) ? ta : 0;
                }
            }
            else if (col == "delCol")
            {
                var confirm = MessageBox.Show("Delete this coaching record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;
                const string q = "DELETE FROM Coaching WHERE CoachingID=@id";
                using var cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0) MessageBox.Show("Deleted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete: " + ex.Message);
                }
                finally { if (con.State == System.Data.ConnectionState.Open) con.Close(); }

                LoadCoachingFromDatabase();
                ClearInputs();
            }
        }

        // Designer expects this handler; ensure it exists and delegates to the same initialization
        private void Coachig_Load(object sender, EventArgs e)
        {
            // Keep behavior identical to what was previously done
            try
            {
                LoadAthletes();
                LoadTrainers();
                LoadCoachingFromDatabase();
                dateTimePickerCreation.Value = DateTime.Now;
                RecalculateAmounts();
            }
            catch
            {
                // ignore errors during designer-time invocation
            }
        }

        // Event handler stubs to satisfy designer-generated references
        private void numericTotalAmount_ValueChanged(object sender, EventArgs e)
        {
            // Total amount is calculated programmatically; update dependent calculations if needed
            RecalculateAmounts(sender, e);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Legacy designer bound handler - delegate to primary save
            btnSave_Click(sender, e);
        }

        // Helper classes
        private sealed class CoachingRecord
        {
            public int CoachingID { get; set; }
            public DateTime CreationDate { get; set; }
            public int AthleteID { get; set; }
            public string AthleteName { get; set; } = string.Empty;
            public string AthleteContact { get; set; } = string.Empty;
            public decimal CurrentWeight { get; set; }
            public string WeightCategory { get; set; } = string.Empty;
            public int TrainerID { get; set; }
            public string TrainerName { get; set; } = string.Empty;
            public string TrainingPlan { get; set; } = string.Empty;
            public DateTime TrainingStart { get; set; }
            public DateTime TrainingEnd { get; set; }
            public int WeeksTraining { get; set; }
            public decimal AmountTraining { get; set; }
            public decimal PrivateHours { get; set; }
            public DateTime PrivateStart { get; set; }
            public DateTime PrivateEnd { get; set; }
            public int WeeksPrivate { get; set; }
            public decimal AmountCoaching { get; set; }
            public int NoOfCompetition { get; set; }
            public decimal TotalAmount { get; set; }
        }

        private sealed class ComboItem
        {
            public int Id { get; }
            public string Text { get; }
            public string Contact { get; }
            public decimal Weight { get; }
            public string Category { get; }

            public ComboItem(int id, string text)
            {
                Id = id; Text = text; Contact = string.Empty; Weight = 0; Category = string.Empty;
            }

            public ComboItem(int id, string text, string contact, decimal weight, string category)
            {
                Id = id; Text = text; Contact = contact; Weight = weight; Category = category;
            }

            public override string ToString() => Text;
        }

        private void btnSave_Click_2(object sender, EventArgs e)
        {

        }

        /* SQL to create Coaching table (run in SSMS):


        */
    }
}
