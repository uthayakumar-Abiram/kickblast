using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kickvlast
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            PopulateInfoTables();
        }

        private void PopulateInfoTables()
        {
            try
            {
                // Training plans
                var trainingItems = new (string Name, string Price)[]
                {
                    ("Beginner (2 sessions per week)", "250.00"),
                    ("Intermediate (3 sessions per week)", "300.00"),
                    ("Elite (5 sessions per week)", "350.00"),
                    ("Private tuition (per hour)", "90.50"),
                    ("Competition entry fee (per competition)", "220.00")
                };

                trainingTable.Controls.Clear();
                trainingTable.RowStyles.Clear();
                trainingTable.RowCount = trainingItems.Length + 1; // header + items
                // header row
                trainingTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                trainingTable.Controls.Add(new Label
                {
                    Text = "Training Plan",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft
                }, 0, 0);
                trainingTable.Controls.Add(new Label
                {
                    Text = "Price (Rs.)",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight
                }, 1, 0);

                for (int i = 0; i < trainingItems.Length; i++)
                {
                    trainingTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    var row = i + 1;
                    trainingTable.Controls.Add(new Label
                    {
                        Text = trainingItems[i].Name,
                        Font = new Font("Segoe UI", 9F),
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleLeft
                    }, 0, row);
                    trainingTable.Controls.Add(new Label
                    {
                        Text = trainingItems[i].Price,
                        Font = new Font("Segoe UI", 9F),
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleRight
                    }, 1, row);
                }

                // Weight categories
                var weightItems = new (string Category, string Limit)[]
                {
                    ("Heavyweight", "Unlimited (Over 100)"),
                    ("Light–Heavyweight", "100"),
                    ("Middleweight", "90"),
                    ("Light–Middleweight", "81"),
                    ("Lightweight", "73"),
                    ("Flyweight", "66")
                };

                weightTable.Controls.Clear();
                weightTable.RowStyles.Clear();
                weightTable.RowCount = weightItems.Length + 1;
                weightTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                weightTable.Controls.Add(new Label
                {
                    Text = "Categories",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft
                }, 0, 0);
                weightTable.Controls.Add(new Label
                {
                    Text = "Upper weight limit (kg)",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight
                }, 1, 0);

                for (int i = 0; i < weightItems.Length; i++)
                {
                    weightTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    var row = i + 1;
                    weightTable.Controls.Add(new Label
                    {
                        Text = weightItems[i].Category,
                        Font = new Font("Segoe UI", 9F),
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleLeft
                    }, 0, row);
                    weightTable.Controls.Add(new Label
                    {
                        Text = weightItems[i].Limit,
                        Font = new Font("Segoe UI", 9F),
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleRight
                    }, 1, row);
                }
            }
            catch
            {
                // ignore UI population failures
            }
        }

        private void btnTrainingPlans_Click(object sender, EventArgs e)
        {
            Form frm = new Trainer();
            frm.Show();
            this.Hide();
        }

        private void btnAthletes_Click(object sender, EventArgs e)
        {
            Form frm = new Athlete();
            frm.Show();
            this.Hide();
        }

        private void comp1_Click(object sender, EventArgs e)
        {
            Form frm = new Competition();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You have successfully logged out.", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btnWeightCategories_Click(object sender, EventArgs e)
        {
            Form frm = new Coachig();
            frm.Show();
            this.Hide();
        }

        private void trainingPlansGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
