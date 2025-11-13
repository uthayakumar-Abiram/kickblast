using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace kickvlast
{
    public partial class Competition : Form
    {
        // Connection string (adjust if needed)
        private readonly SqlConnection con = new SqlConnection("Data Source=ABIRAM\\SQLEXPRESS01;Initial Catalog=ksb;Integrated Security=True;Trust Server Certificate=True");
        private readonly List<CompetitionRecord> records = new();
        private int? editingId = null;
        private const decimal CompetitionFee = 220.00m;

        public Competition()
        {
            InitializeComponent();

            if (btnSave != null) btnSave.Click += btnSave_Click;
            if (btnClear != null) btnClear.Click += btnClear_Click;
            if (txtCoachingID != null) txtCoachingID.Leave += txtCoachingID_Leave;
            if (dgvEntries != null) dgvEntries.CellContentClick += dgvEntries_CellContentClick;
            if (comboBox1 != null) comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            Load += Competition_Load;
        }

        private void Competition_Load(object sender, EventArgs e)
        {
            RebuildGridColumns();
            LoadCompetitionsFromDatabase();
            if (dtpCreationDate != null) dtpCreationDate.Value = DateTime.Now;
            if (dtpCompetitionDate != null) dtpCompetitionDate.Value = DateTime.Now;
            if (dtpCoachingCreationDate != null) dtpCoachingCreationDate.Value = DateTime.Now;
            LoadCoachingCombo();
        }

        private void RebuildGridColumns()
        {
            if (dgvEntries == null) return;
            dgvEntries.Columns.Clear();
            dgvEntries.Columns.Add(new DataGridViewTextBoxColumn { Name = "CompetitionID", HeaderText = "Competition ID", ReadOnly = true });
            dgvEntries.Columns.Add(new DataGridViewTextBoxColumn { Name = "CompetitionCreatedDate", HeaderText = "Created (Comp)", ReadOnly = true });
            dgvEntries.Columns.Add(new DataGridViewTextBoxColumn { Name = "CoachingID", HeaderText = "Coaching ID", ReadOnly = true });
            dgvEntries.Columns.Add(new DataGridViewTextBoxColumn { Name = "CoachingCreatedDate", HeaderText = "Created (Coach)", ReadOnly = true });
            dgvEntries.Columns.Add(new DataGridViewTextBoxColumn { Name = "AthleteID", HeaderText = "Athlete ID", ReadOnly = true });
            dgvEntries.Columns.Add(new DataGridViewTextBoxColumn { Name = "AthleteName", HeaderText = "Athlete Name", ReadOnly = true });
            dgvEntries.Columns.Add(new DataGridViewTextBoxColumn { Name = "CurrentWeight", HeaderText = "Current Weight", ReadOnly = true });
            dgvEntries.Columns.Add(new DataGridViewTextBoxColumn { Name = "WeightCategory", HeaderText = "Weight Category", ReadOnly = true });
            dgvEntries.Columns.Add(new DataGridViewTextBoxColumn { Name = "CompetitionDate", HeaderText = "Competition Date", ReadOnly = true });
            dgvEntries.Columns.Add(new DataGridViewButtonColumn { Name = "View", HeaderText = "View", Text = "View", UseColumnTextForButtonValue = true });
            dgvEntries.Columns.Add(new DataGridViewButtonColumn { Name = "Edit", HeaderText = "Edit", Text = "Edit", UseColumnTextForButtonValue = true });
            dgvEntries.Columns.Add(new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true });
            dgvEntries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtCoachingID_Leave(object sender, EventArgs e)
        {
            if (txtCoachingID == null) return;
            // When user enters a CoachingID, fetch coaching details to populate athlete fields
            if (string.IsNullOrWhiteSpace(txtCoachingID.Text)) return;
            if (!int.TryParse(txtCoachingID.Text.Trim(), out var cid)) return;

            // set combo selection if possible
            SelectCoachingComboItem(cid);
            PopulateCoachingInfo(cid);
        }

        private void comboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBox1 == null) return;
            if (comboBox1.SelectedItem is CoachingComboItem item)
            {
                if (txtCoachingID != null) txtCoachingID.Text = item.Id.ToString();
                PopulateCoachingInfo(item.Id);
            }
        }

        private void PopulateCoachingInfo(int coachingId)
        {
            const string q = "SELECT CreationDate, AthleteID, AthleteName, CurrentWeight, WeightCategory FROM Coaching WHERE CoachingID = @id";
            using var cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@id", coachingId);
            try
            {
                con.Open();
                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    if (dtpCoachingCreationDate != null) dtpCoachingCreationDate.Value = r["CreationDate"] != DBNull.Value ? Convert.ToDateTime(r["CreationDate"]) : DateTime.Now;
                    if (txtAthleteID != null) txtAthleteID.Text = r["AthleteID"]?.ToString() ?? string.Empty;
                    if (txtAthleteName != null) txtAthleteName.Text = r["AthleteName"]?.ToString() ?? string.Empty;
                    if (nudCurrentWeight != null) nudCurrentWeight.Value = r["CurrentWeight"] != DBNull.Value ? Convert.ToDecimal(r["CurrentWeight"]) : 0;

                    // robustly select weight category text in combobox
                    if (cmbWeightCategory != null)
                    {
                        var cat = r["WeightCategory"]?.ToString() ?? string.Empty;
                        var idx = -1;
                        for (int i = 0; i < cmbWeightCategory.Items.Count; i++)
                        {
                            var item = cmbWeightCategory.Items[i]?.ToString() ?? string.Empty;
                            if (string.Equals(item, cat, StringComparison.OrdinalIgnoreCase)) { idx = i; break; }
                        }
                        cmbWeightCategory.SelectedIndex = idx;
                    }
                }
                else
                {
                    MessageBox.Show("No coaching record found for the provided Coaching ID.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load coaching: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (con.State == System.Data.ConnectionState.Open) con.Close(); }
        }

        private void LoadCoachingCombo()
        {
            if (comboBox1 == null) return;
            comboBox1.Items.Clear();
            const string q = "SELECT CoachingID, AthleteName FROM Coaching";
            using var cmd = new SqlCommand(q, con);
            try
            {
                con.Open();
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var id = r["CoachingID"] != DBNull.Value ? Convert.ToInt32(r["CoachingID"]) : 0;
                    var name = r["AthleteName"]?.ToString() ?? string.Empty;
                    comboBox1.Items.Add(new CoachingComboItem(id, name));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load coaching list: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (con.State == System.Data.ConnectionState.Open) con.Close(); }
        }

        private void LoadCompetitionsFromDatabase()
        {
            records.Clear();
            const string q = @"SELECT CompetitionID, CompetitionCreatedDate, CoachingID, CoachingCreatedDate, AthleteID, AthleteName, CurrentWeight, WeightCategory, CompetitionDate FROM CompetitionDetails";
            using var cmd = new SqlCommand(q, con);
            try
            {
                con.Open();
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var rec = new CompetitionRecord
                    {
                        CompetitionID = r["CompetitionID"] != DBNull.Value ? Convert.ToInt32(r["CompetitionID"]) : 0,
                        CompetitionCreatedDate = r["CompetitionCreatedDate"] != DBNull.Value ? Convert.ToDateTime(r["CompetitionCreatedDate"]) : DateTime.MinValue,
                        CoachingID = r["CoachingID"] != DBNull.Value ? Convert.ToInt32(r["CoachingID"]) : 0,
                        CoachingCreatedDate = r["CoachingCreatedDate"] != DBNull.Value ? Convert.ToDateTime(r["CoachingCreatedDate"]) : DateTime.MinValue,
                        AthleteID = r["AthleteID"] != DBNull.Value ? Convert.ToInt32(r["AthleteID"]) : 0,
                        AthleteName = r["AthleteName"]?.ToString() ?? string.Empty,
                        CurrentWeight = r["CurrentWeight"] != DBNull.Value ? Convert.ToDecimal(r["CurrentWeight"]) : 0m,
                        WeightCategory = r["WeightCategory"]?.ToString() ?? string.Empty,
                        CompetitionDate = r["CompetitionDate"] != DBNull.Value ? Convert.ToDateTime(r["CompetitionDate"]) : DateTime.MinValue
                    };
                    records.Add(rec);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load competitions: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (con.State == System.Data.ConnectionState.Open) con.Close(); }

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            if (dgvEntries == null) return;
            dgvEntries.Rows.Clear();
            foreach (var r in records)
            {
                dgvEntries.Rows.Add(r.CompetitionID, r.CompetitionCreatedDate.ToShortDateString(), r.CoachingID, r.CoachingCreatedDate == DateTime.MinValue ? string.Empty : r.CoachingCreatedDate.ToShortDateString(), r.AthleteID, r.AthleteName, r.CurrentWeight.ToString("0.00"), r.WeightCategory, r.CompetitionDate == DateTime.MinValue ? string.Empty : r.CompetitionDate.ToShortDateString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // use coaching combo or coaching id textbox
            int coachingId = 0;
            if (comboBox1 != null && comboBox1.SelectedItem is CoachingComboItem ci) coachingId = ci.Id;
            else if (txtCoachingID != null && int.TryParse(txtCoachingID.Text.Trim(), out var cid)) coachingId = cid;

            if (coachingId <= 0)
            {
                MessageBox.Show("Select a Coaching ID from the list or enter a valid Coaching ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rec = new CompetitionRecord
            {
                CompetitionCreatedDate = dtpCreationDate?.Value ?? DateTime.Now,
                CoachingID = coachingId,
                CoachingCreatedDate = dtpCoachingCreationDate?.Value ?? DateTime.Now,
                AthleteID = (txtAthleteID != null && int.TryParse(txtAthleteID.Text.Trim(), out var aid)) ? aid : 0,
                AthleteName = txtAthleteName?.Text.Trim() ?? string.Empty,
                CurrentWeight = nudCurrentWeight?.Value ?? 0,
                WeightCategory = cmbWeightCategory?.SelectedItem?.ToString() ?? string.Empty,
                CompetitionDate = dtpCompetitionDate?.Value.Date ?? DateTime.Now.Date
            };

            if (editingId == null)
            {
                // INSERT and update Coaching counters
                using var tranConn = con;
                con.Open();
                using var tran = con.BeginTransaction();
                try
                {
                    const string insertQ = @"INSERT INTO CompetitionDetails (CompetitionCreatedDate, CoachingID, CoachingCreatedDate, AthleteID, AthleteName, CurrentWeight, WeightCategory, CompetitionDate) VALUES (@CompetitionCreatedDate,@CoachingID,@CoachingCreatedDate,@AthleteID,@AthleteName,@CurrentWeight,@WeightCategory,@CompetitionDate); SELECT SCOPE_IDENTITY();";
                    using var cmd = new SqlCommand(insertQ, con, tran);
                    cmd.Parameters.AddWithValue("@CompetitionCreatedDate", rec.CompetitionCreatedDate);
                    cmd.Parameters.AddWithValue("@CoachingID", rec.CoachingID);
                    cmd.Parameters.AddWithValue("@CoachingCreatedDate", rec.CoachingCreatedDate);
                    cmd.Parameters.AddWithValue("@AthleteID", rec.AthleteID);
                    cmd.Parameters.AddWithValue("@AthleteName", rec.AthleteName);
                    cmd.Parameters.AddWithValue("@CurrentWeight", rec.CurrentWeight);
                    cmd.Parameters.AddWithValue("@WeightCategory", rec.WeightCategory);
                    cmd.Parameters.AddWithValue("@CompetitionDate", rec.CompetitionDate);

                    var obj = cmd.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out var newId))
                    {
                        rec.CompetitionID = newId; // keep for in-memory list
                    }

                    const string incQ = "UPDATE Coaching SET NoOfCompetition = ISNULL(NoOfCompetition,0) + 1, TotalAmount = ISNULL(TotalAmount,0) + @fee WHERE CoachingID = @id";
                    using var updCmd = new SqlCommand(incQ, con, tran);
                    updCmd.Parameters.AddWithValue("@fee", CompetitionFee);
                    updCmd.Parameters.AddWithValue("@id", rec.CoachingID);
                    updCmd.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("Competition saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    MessageBox.Show("Failed to save competition: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { if (con.State == System.Data.ConnectionState.Open) con.Close(); }
            }
            else
            {
                // Update existing competition
                using var tranConn = con;
                con.Open();
                using var tran = con.BeginTransaction();
                try
                {
                    const string updateQ = @"UPDATE CompetitionDetails SET CompetitionCreatedDate=@CompetitionCreatedDate, CoachingCreatedDate=@CoachingCreatedDate, AthleteID=@AthleteID, AthleteName=@AthleteName, CurrentWeight=@CurrentWeight, WeightCategory=@WeightCategory, CompetitionDate=@CompetitionDate WHERE CompetitionID=@CompetitionID";
                    using var cmd = new SqlCommand(updateQ, con, tran);
                    cmd.Parameters.AddWithValue("@CompetitionCreatedDate", rec.CompetitionCreatedDate);
                    cmd.Parameters.AddWithValue("@CoachingCreatedDate", rec.CoachingCreatedDate);
                    cmd.Parameters.AddWithValue("@AthleteID", rec.AthleteID);
                    cmd.Parameters.AddWithValue("@AthleteName", rec.AthleteName);
                    cmd.Parameters.AddWithValue("@CurrentWeight", rec.CurrentWeight);
                    cmd.Parameters.AddWithValue("@WeightCategory", rec.WeightCategory);
                    cmd.Parameters.AddWithValue("@CompetitionDate", rec.CompetitionDate);
                    cmd.Parameters.AddWithValue("@CompetitionID", editingId.Value);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0) MessageBox.Show("Competition updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("No record updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    MessageBox.Show("Failed to update competition: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { if (con.State == System.Data.ConnectionState.Open) con.Close(); }

                editingId = null;
            }

            LoadCompetitionsFromDatabase();
            ClearInputs();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dgvEntries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEntries == null) return;
            if (e.RowIndex < 0) return;
            var col = dgvEntries.Columns[e.ColumnIndex].Name;
            var idObj = dgvEntries.Rows[e.RowIndex].Cells["CompetitionID"].Value;
            if (idObj == null) return;
            if (!int.TryParse(idObj.ToString(), out var id)) return;

            if (col == "View" || col == "Edit")
            {
                var row = dgvEntries.Rows[e.RowIndex];
                editingId = id;
                if (dtpCreationDate != null) dtpCreationDate.Value = DateTime.TryParse(row.Cells["CompetitionCreatedDate"].Value?.ToString(), out var cd) ? cd : DateTime.Now;
                // coaching id from grid
                var coachingId = int.TryParse(row.Cells["CoachingID"].Value?.ToString(), out var tmp) ? tmp : 0;
                if (txtCoachingID != null) txtCoachingID.Text = coachingId > 0 ? coachingId.ToString() : string.Empty;
                if (dtpCoachingCreationDate != null) dtpCoachingCreationDate.Value = DateTime.TryParse(row.Cells["CoachingCreatedDate"].Value?.ToString(), out var ccd) ? ccd : DateTime.Now;

                // populate from Coaching table to ensure fields like weight category are accurate
                if (coachingId > 0) {
                    SelectCoachingComboItem(coachingId);
                    PopulateCoachingInfo(coachingId);
                }

                if (txtAthleteID != null) txtAthleteID.Text = row.Cells["AthleteID"].Value?.ToString();
                if (txtAthleteName != null) txtAthleteName.Text = row.Cells["AthleteName"].Value?.ToString();
                if (nudCurrentWeight != null) nudCurrentWeight.Value = decimal.TryParse(row.Cells["CurrentWeight"].Value?.ToString(), out var w) ? w : 0;
                var cat = row.Cells["WeightCategory"].Value?.ToString();
                if (!string.IsNullOrEmpty(cat) && cmbWeightCategory != null && cmbWeightCategory.Items.Contains(cat)) cmbWeightCategory.SelectedItem = cat; else if (cmbWeightCategory != null) cmbWeightCategory.SelectedIndex = -1;
                if (dtpCompetitionDate != null) dtpCompetitionDate.Value = DateTime.TryParse(row.Cells["CompetitionDate"].Value?.ToString(), out var cmpd) ? cmpd : DateTime.Now;

                // when viewing, do not allow changing coaching id
                if (col == "View") if (txtCoachingID != null) txtCoachingID.ReadOnly = true; else if (txtCoachingID != null) txtCoachingID.ReadOnly = false;
            }
            else if (col == "Delete")
            {
                var confirm = MessageBox.Show("Delete this competition record? This will decrement the Coaching's NoOfCompetition and subtract the competition fee.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var coachingIdObj = dgvEntries.Rows[e.RowIndex].Cells["CoachingID"].Value;
                var coachingId = coachingIdObj != null && int.TryParse(coachingIdObj.ToString(), out var cv) ? cv : 0;

                using var tranConn = con;
                con.Open();
                using var tran = con.BeginTransaction();
                try
                {
                    const string delQ = "DELETE FROM CompetitionDetails WHERE CompetitionID = @id";
                    using var cmd = new SqlCommand(delQ, con, tran);
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0 && coachingId > 0)
                    {
                        const string decQ = "UPDATE Coaching SET NoOfCompetition = CASE WHEN ISNULL(NoOfCompetition,0) - 1 >= 0 THEN NoOfCompetition - 1 ELSE 0 END, TotalAmount = CASE WHEN ISNULL(TotalAmount,0) - @fee >= 0 THEN TotalAmount - @fee ELSE 0 END WHERE CoachingID = @id";
                        using var decCmd = new SqlCommand(decQ, con, tran);
                        decCmd.Parameters.AddWithValue("@fee", CompetitionFee);
                        decCmd.Parameters.AddWithValue("@id", coachingId);
                        decCmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Competition deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    MessageBox.Show("Failed to delete: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { if (con.State == System.Data.ConnectionState.Open) con.Close(); }

                LoadCompetitionsFromDatabase();
                ClearInputs();
            }
        }

        private void ClearInputs()
        {
            if (dtpCreationDate != null) dtpCreationDate.Value = DateTime.Now;
            if (txtCoachingID != null) txtCoachingID.Text = string.Empty;
            if (dtpCoachingCreationDate != null) dtpCoachingCreationDate.Value = DateTime.Now;
            if (txtAthleteID != null) txtAthleteID.Text = string.Empty;
            if (txtAthleteName != null) txtAthleteName.Text = string.Empty;
            if (nudCurrentWeight != null) nudCurrentWeight.Value = 0;
            if (cmbWeightCategory != null) cmbWeightCategory.SelectedIndex = -1;
            if (dtpCompetitionDate != null) dtpCompetitionDate.Value = DateTime.Now;
            editingId = null;
            if (comboBox1 != null) comboBox1.SelectedIndex = -1;
        }

        private void SelectCoachingComboItem(int coachingId)
        {
            if (comboBox1 == null) return;
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items[i] is CoachingComboItem it && it.Id == coachingId)
                {
                    comboBox1.SelectedIndex = i;
                    return;
                }
            }
            // not found
            comboBox1.SelectedIndex = -1;
        }

        private sealed class CompetitionRecord
        {
            public int CompetitionID { get; set; }
            public DateTime CompetitionCreatedDate { get; set; }
            public int CoachingID { get; set; }
            public DateTime CoachingCreatedDate { get; set; }
            public int AthleteID { get; set; }
            public string AthleteName { get; set; } = string.Empty;
            public decimal CurrentWeight { get; set; }
            public string WeightCategory { get; set; } = string.Empty;
            public DateTime CompetitionDate { get; set; }
        }

        private sealed class CoachingComboItem
        {
            public int Id { get; }
            public string Name { get; }
            public CoachingComboItem(int id, string name) { Id = id; Name = name; }
            public override string ToString() => $"{Id} - {Name}";
        }
    }
}
