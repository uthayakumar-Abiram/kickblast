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
    public partial class Trainer : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ABIRAM\\SQLEXPRESS01;Initial Catalog=ksb;Integrated Security=True;Trust Server Certificate=True");
        private readonly List<TrainerRecord> trainers = new();
        private int? editingTrainerId = null;

        public Trainer()
        {
            InitializeComponent();
        

            // Load existing trainers from the database so the grid is populated initially
            LoadTrainersFromDatabase();
        }

        private void LoadTrainersFromDatabase()
        {
            trainers.Clear();

            // Adjust table/column names to match your schema if different
            const string query = "SELECT id, Trainer_Name, NIC_Number, Contact_No, Address, Qualification, Experience, Salary FROM Trainer";

            using var cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var rec = new TrainerRecord
                    {
                        TrainerID = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                        Name = reader["Trainer_Name"]?.ToString() ?? string.Empty,
                        NIC = reader["NIC_Number"]?.ToString() ?? string.Empty,
                        Contact = reader["Contact_No"]?.ToString() ?? string.Empty,
                        Address = reader["Address"]?.ToString() ?? string.Empty,
                        Qualification = reader["Qualification"]?.ToString() ?? string.Empty,
                        Experience = reader["Experience"] != DBNull.Value ? Convert.ToInt32(reader["Experience"]) : 0,
                        Salary = reader["Salary"] != DBNull.Value ? Convert.ToDecimal(reader["Salary"]) : 0m
                    };
                    trainers.Add(rec);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load trainers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Validate required fields
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Trainer name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rec = new TrainerRecord
            {
                // TrainerID assigned by DB
                Name = textBoxName.Text?.Trim() ?? string.Empty,
                NIC = textBoxNIC.Text?.Trim() ?? string.Empty,
                Contact = textBoxContact.Text?.Trim() ?? string.Empty,
                Address = textBoxAddress.Text?.Trim() ?? string.Empty,
                Qualification = qubox.Text ?? string.Empty,
                Experience = (int)numericExperience.Value,
                Salary = textBoxSalary.Value
            };

            if (editingTrainerId == null)
            {
                // Insert (DB generates id)
                string query = "INSERT INTO Trainer (Trainer_Name, NIC_Number, Contact_No, Address, Qualification, Experience, Salary) VALUES (@name,@nic,@contact,@address,@qul,@exp,@sal); SELECT SCOPE_IDENTITY();";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", rec.Name);
                cmd.Parameters.AddWithValue("@nic", rec.NIC);
                cmd.Parameters.AddWithValue("@contact", rec.Contact);
                cmd.Parameters.AddWithValue("@address", rec.Address);
                cmd.Parameters.AddWithValue("@qul", rec.Qualification);
                cmd.Parameters.AddWithValue("@exp", rec.Experience);
                cmd.Parameters.AddWithValue("@sal", rec.Salary);

                try
                {
                    con.Open();
                    var obj = cmd.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out var newId))
                    {
                        rec.TrainerID = newId;
                    }
                    MessageBox.Show("Trainer saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save trainer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string query = "UPDATE Trainer SET Trainer_Name=@name, NIC_Number=@nic, Contact_No=@contact, Address=@address, Qualification=@qul, Experience=@exp, Salary=@sal WHERE id=@id";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", editingTrainerId.Value);
                cmd.Parameters.AddWithValue("@name", rec.Name);
                cmd.Parameters.AddWithValue("@nic", rec.NIC);
                cmd.Parameters.AddWithValue("@contact", rec.Contact);
                cmd.Parameters.AddWithValue("@address", rec.Address);
                cmd.Parameters.AddWithValue("@qul", rec.Qualification);
                cmd.Parameters.AddWithValue("@exp", rec.Experience);
                cmd.Parameters.AddWithValue("@sal", rec.Salary);

                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Trainer updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No record updated. The trainer may have been removed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update trainer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }

                editingTrainerId = null;
            }

            // Refresh list from database and UI
            LoadTrainersFromDatabase();
            ClearInputs();
        }

         private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void RefreshGrid()
        {
            dgvTrainers.Rows.Clear();
            foreach (var t in trainers)
            {
                dgvTrainers.Rows.Add(t.TrainerID, t.Name, t.NIC, t.Contact, t.Address, t.Qualification, t.Experience, t.Salary.ToString("0.00"));
            }
        }

        private void ClearInputs()
        {
            // hide/ignore TrainerID in UI
            try { textBoxTrainerID.Text = string.Empty; lblTrainerID.Visible = false; textBoxTrainerID.Visible = false; } catch { }
            textBoxName.Text = string.Empty;
            textBoxNIC.Text = string.Empty;
            textBoxContact.Text = string.Empty;
            textBoxAddress.Text = string.Empty;
            qubox.Text = string.Empty;
            numericExperience.Value = 1;
            textBoxSalary.Value = 30000;
            editingTrainerId = null;
            try { textBoxTrainerID.ReadOnly = false; } catch { }
        }

        private sealed class TrainerRecord
        {
            public int TrainerID { get; set; }
            public string Name { get; set; } = string.Empty;
            public string NIC { get; set; } = string.Empty;
            public string Contact { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public string Qualification { get; set; } = string.Empty;
            public int Experience { get; set; }
            public decimal Salary { get; set; }
        }

        private void lblTrainerID_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTrainerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvTrainers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = dgvTrainers.Columns[e.ColumnIndex].Name;
            var idObj = dgvTrainers.Rows[e.RowIndex].Cells[0].Value;
            if (idObj == null) return;
            if (!int.TryParse(idObj.ToString(), out var id)) return;

            if (colName == "ViewCol")
            {
                // populate left-side inputs for editing
                var row = dgvTrainers.Rows[e.RowIndex];
                // do not populate ID textbox (hidden)
                textBoxName.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                textBoxNIC.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                textBoxContact.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
                textBoxAddress.Text = row.Cells[4].Value?.ToString() ?? string.Empty;
                qubox.Text = row.Cells[5].Value?.ToString() ?? string.Empty;
                if (int.TryParse(row.Cells[6].Value?.ToString(), out var exp))
                    numericExperience.Value = Math.Max(numericExperience.Minimum, Math.Min(numericExperience.Maximum, exp));
                if (decimal.TryParse(row.Cells[7].Value?.ToString(), out var sal))
                    textBoxSalary.Value = sal;

                editingTrainerId = id;
                // lock TrainerID (hidden) to prevent changing primary key
                try { textBoxTrainerID.ReadOnly = true; } catch { }
            }
            else if (colName == "del")
            {
                // confirm and delete
                var confirm = MessageBox.Show("Are you sure you want to delete this trainer?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                string query = "DELETE FROM Trainer WHERE id = @id";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Trainer deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No trainer deleted. It may already have been removed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete trainer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }

                // refresh
                LoadTrainersFromDatabase();
                ClearInputs();
            }
        }

        private void Trainer_Load(object sender, EventArgs e)
        {

        }
    }
}
