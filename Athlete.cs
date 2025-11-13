using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace kickvlast
{
    public partial class Athlete : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ABIRAM\\SQLEXPRESS01;Initial Catalog=ksb;Integrated Security=True;Trust Server Certificate=True");
        private readonly List<AthleteRecord> athletes = new();
        private int? editingAthleteId = null;

        public Athlete()
        {
            InitializeComponent();
            // AthleteID is DB-generated and not shown in the UI
            LoadAthletesFromDatabase();
        }

        private void LoadAthletesFromDatabase()
        {
            athletes.Clear();

            const string query = "SELECT AthleteID, AthleteName, NICNumber, ContactNo, Address, CurrentWeight, WeightCategory, Height, BMIIndex, BloodGroup FROM Athlete";
            using var cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var rec = new AthleteRecord
                    {
                        AthleteID = reader["AthleteID"] != DBNull.Value ? Convert.ToInt32(reader["AthleteID"]) : 0,
                        Name = reader["AthleteName"]?.ToString() ?? string.Empty,
                        NIC = reader["NICNumber"]?.ToString() ?? string.Empty,
                        Contact = reader["ContactNo"]?.ToString() ?? string.Empty,
                        Address = reader["Address"]?.ToString() ?? string.Empty,
                        Weight = reader["CurrentWeight"] != DBNull.Value ? Convert.ToDecimal(reader["CurrentWeight"]) : 0m,
                        Category = reader["WeightCategory"]?.ToString() ?? string.Empty,
                        Height = reader["Height"] != DBNull.Value ? Convert.ToDecimal(reader["Height"]) : 0m,
                        BMI = reader["BMIIndex"] != DBNull.Value ? Convert.ToDecimal(reader["BMIIndex"]) : 0m,
                        BloodGroup = reader["BloodGroup"]?.ToString() ?? string.Empty
                    };
                    athletes.Add(rec);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load athletes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            RefreshGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Prepare record from UI
            var rec = new AthleteRecord
            {
                // AthleteID not taken from user; it will be set when editing
                Name = textBoxName.Text?.Trim() ?? string.Empty,
                NIC = textBoxNIC.Text?.Trim() ?? string.Empty,
                Contact = textBoxContact.Text?.Trim() ?? string.Empty,
                Address = textBoxAddress.Text?.Trim() ?? string.Empty,
                Weight = numericWeight.Value,
                Height = numericHeight.Value,
                BMI = decimal.TryParse(textBoxBMI.Text, out var b) ? b : 0m,
                Category = comboCategory.SelectedItem?.ToString() ?? string.Empty,
                BloodGroup = comboBloodGroup.SelectedItem?.ToString() ?? string.Empty
            };

            if (editingAthleteId == null)
            {
                // Insert
                const string query = "INSERT INTO Athlete (AthleteName, NICNumber, ContactNo, Address, CurrentWeight, WeightCategory, Height, BMIIndex, BloodGroup) VALUES (@name,@nic,@contact,@address,@weight,@category,@height,@bmi,@blood); SELECT SCOPE_IDENTITY();";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", rec.Name);
                cmd.Parameters.AddWithValue("@nic", rec.NIC);
                cmd.Parameters.AddWithValue("@contact", rec.Contact);
                cmd.Parameters.AddWithValue("@address", rec.Address);
                cmd.Parameters.AddWithValue("@weight", rec.Weight);
                cmd.Parameters.AddWithValue("@category", rec.Category);
                cmd.Parameters.AddWithValue("@height", rec.Height);
                cmd.Parameters.AddWithValue("@bmi", rec.BMI);
                cmd.Parameters.AddWithValue("@blood", rec.BloodGroup);

                try
                {
                    con.Open();
                    var obj = cmd.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out var newId))
                    {
                        rec.AthleteID = newId;
                    }
                    MessageBox.Show("Athlete saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save athlete: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            else
            {
                // Update
                const string query = "UPDATE Athlete SET AthleteName=@name, NICNumber=@nic, ContactNo=@contact, Address=@address, CurrentWeight=@weight, WeightCategory=@category, Height=@height, BMIIndex=@bmi, BloodGroup=@blood WHERE AthleteID=@id";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", editingAthleteId.Value);
                cmd.Parameters.AddWithValue("@name", rec.Name);
                cmd.Parameters.AddWithValue("@nic", rec.NIC);
                cmd.Parameters.AddWithValue("@contact", rec.Contact);
                cmd.Parameters.AddWithValue("@address", rec.Address);
                cmd.Parameters.AddWithValue("@weight", rec.Weight);
                cmd.Parameters.AddWithValue("@category", rec.Category);
                cmd.Parameters.AddWithValue("@height", rec.Height);
                cmd.Parameters.AddWithValue("@bmi", rec.BMI);
                cmd.Parameters.AddWithValue("@blood", rec.BloodGroup);

                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Athlete updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No record updated. The athlete may have been removed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update athlete: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }

                editingAthleteId = null;
            }

            // Refresh from DB and clear inputs
            LoadAthletesFromDatabase();
            ClearInputs();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
            // BMI = weight(kg) / (height(m)^2)
            var weight = (double)numericWeight.Value;
            var heightCm = (double)numericHeight.Value;
            if (heightCm <= 0)
            {
                textBoxBMI.Text = string.Empty;
            }
            else
            {
                var heightM = heightCm / 100.0;
                var bmi = weight / (heightM * heightM);
                textBoxBMI.Text = bmi.ToString("0.0");
            }

            // Determine and set weight category automatically
            try
            {
                var cat = GetWeightCategory(numericWeight.Value);
                if (!string.IsNullOrEmpty(cat) && comboCategory.Items.Contains(cat))
                {
                    comboCategory.SelectedItem = cat;
                }
                else
                {
                    comboCategory.SelectedIndex = -1;
                }
            }
            catch
            {
                // ignore
            }
        }

        private string GetWeightCategory(decimal weight)
        {
            // weight in kg
            if (weight < 66m) return "Flyweight";
            if (weight <= 73m) return "Lightweight";
            if (weight <= 81m) return "Light–Middleweight";
            if (weight <= 90m) return "Middleweight";
            if (weight <= 100m) return "Light–Heavyweight";
            return "Heavyweight";
        }

        private void RefreshGrid()
        {
            dgvAthletes.Rows.Clear();
            foreach (var a in athletes)
            {
                dgvAthletes.Rows.Add(a.AthleteID, a.Name, a.NIC, a.Contact, a.Address, a.Weight.ToString("0.00"), a.Category, a.Height.ToString("0.00"), a.BMI.ToString("0.00"), a.BloodGroup);
            }
        }

        private void ClearInputs()
        {
            // ID is not shown to the user
            textBoxName.Text = string.Empty;
            textBoxNIC.Text = string.Empty;
            textBoxContact.Text = string.Empty;
            textBoxAddress.Text = string.Empty;
            numericWeight.Value = 70;
            numericHeight.Value = 170;
            textBoxBMI.Text = string.Empty;
            comboCategory.SelectedIndex = -1;
            comboBloodGroup.SelectedIndex = -1;
            editingAthleteId = null;
        }

        private sealed class AthleteRecord
        {
            public int AthleteID { get; set; }
            public string Name { get; set; } = string.Empty;
            public string NIC { get; set; } = string.Empty;
            public string Contact { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public decimal Weight { get; set; }
            public string Category { get; set; } = string.Empty;
            public decimal Height { get; set; }
            public decimal BMI { get; set; }
            public string BloodGroup { get; set; } = string.Empty;
        }

        private void dgvAthletes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = dgvAthletes.Columns[e.ColumnIndex].Name;
            var idObj = dgvAthletes.Rows[e.RowIndex].Cells[0].Value;
            if (idObj == null) return;
            if (!int.TryParse(idObj.ToString(), out var id)) return;

            if (colName == "view")
            {
                var row = dgvAthletes.Rows[e.RowIndex];
                // populate inputs for editing (do not show ID in UI)
                textBoxName.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                textBoxNIC.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                textBoxContact.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
                textBoxAddress.Text = row.Cells[4].Value?.ToString() ?? string.Empty;
                if (decimal.TryParse(row.Cells[5].Value?.ToString(), out var wt))
                    numericWeight.Value = Math.Max(numericWeight.Minimum, Math.Min(numericWeight.Maximum, wt));
                comboCategory.SelectedItem = row.Cells[6].Value?.ToString();
                if (decimal.TryParse(row.Cells[7].Value?.ToString(), out var ht))
                    numericHeight.Value = Math.Max(numericHeight.Minimum, Math.Min(numericHeight.Maximum, ht));
                if (decimal.TryParse(row.Cells[8].Value?.ToString(), out var bmi))
                    textBoxBMI.Text = bmi.ToString("0.0");
                comboBloodGroup.SelectedItem = row.Cells[9].Value?.ToString();

                editingAthleteId = id;
            }
            else if (colName == "delete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this athlete?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                const string query = "DELETE FROM Athlete WHERE AthleteID = @id";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Athlete deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No athlete deleted. It may already have been removed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete athlete: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }

                LoadAthletesFromDatabase();
                ClearInputs();
            }
        }

        private void Athlete_Load(object sender, EventArgs e)
        {

        }
    }
}
