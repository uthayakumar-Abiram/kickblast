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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Center the login form inside the right panel
            loginTableLayoutPanel.Left = (rightPanel.Width - loginTableLayoutPanel.Width) / 2;
            loginTableLayoutPanel.Top = (rightPanel.Height - loginTableLayoutPanel.Height) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text?.Trim() ?? string.Empty;
            var password = textBox2.Text ?? string.Empty;

            if (username == "admin" && password == "admin123")
            {
                // open dashboard
                var frm = new dashboard();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Use username 'admin' and password 'admin123'.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox1.Focus();
        }
    }
}
