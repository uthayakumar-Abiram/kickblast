namespace kickvlast
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            rightPanel = new Panel();
            buttonClear = new Button();
            button1 = new Button();
            textBox2 = new TextBox();
            labelPass = new Label();
            textBox1 = new TextBox();
            labelUser = new Label();
            labelTitle = new Label();
            loginTableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            rightPanel.SuspendLayout();
            loginTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(rightPanel, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1000, 720);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(494, 714);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(loginTableLayoutPanel);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(503, 3);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(494, 714);
            rightPanel.TabIndex = 1;
            rightPanel.Paint += panel1_Paint_1;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(23, 136);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(80, 29);
            buttonClear.TabIndex = 6;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // button1
            // 
            button1.Location = new Point(109, 136);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(109, 103);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(168, 27);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            // 
            // labelPass
            // 
            labelPass.AutoSize = true;
            labelPass.Location = new Point(23, 100);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(70, 20);
            labelPass.TabIndex = 3;
            labelPass.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(109, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(168, 27);
            textBox1.TabIndex = 2;
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Location = new Point(23, 67);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(75, 20);
            labelUser.TabIndex = 1;
            labelUser.Text = "Username";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            loginTableLayoutPanel.SetColumnSpan(labelTitle, 2);
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(23, 20);
            labelTitle.Margin = new Padding(3, 0, 3, 10);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(181, 37);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Admin Login";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // loginTableLayoutPanel
            // 
            loginTableLayoutPanel.Anchor = AnchorStyles.None;
            loginTableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loginTableLayoutPanel.ColumnCount = 2;
            loginTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            loginTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            loginTableLayoutPanel.Controls.Add(labelTitle, 0, 0);
            loginTableLayoutPanel.Controls.Add(labelUser, 0, 1);
            loginTableLayoutPanel.Controls.Add(textBox1, 1, 1);
            loginTableLayoutPanel.Controls.Add(labelPass, 0, 2);
            loginTableLayoutPanel.Controls.Add(textBox2, 1, 2);
            loginTableLayoutPanel.Controls.Add(button1, 1, 3);
            loginTableLayoutPanel.Controls.Add(buttonClear, 0, 3);
            loginTableLayoutPanel.Location = new Point(93, 245);
            loginTableLayoutPanel.MinimumSize = new Size(300, 200);
            loginTableLayoutPanel.Name = "loginTableLayoutPanel";
            loginTableLayoutPanel.Padding = new Padding(20);
            loginTableLayoutPanel.RowCount = 5;
            loginTableLayoutPanel.RowStyles.Add(new RowStyle());
            loginTableLayoutPanel.RowStyles.Add(new RowStyle());
            loginTableLayoutPanel.RowStyles.Add(new RowStyle());
            loginTableLayoutPanel.RowStyles.Add(new RowStyle());
            loginTableLayoutPanel.RowStyles.Add(new RowStyle());
            loginTableLayoutPanel.Size = new Size(300, 226);
            loginTableLayoutPanel.TabIndex = 1;
            // 
            // Login
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(1000, 720);
            Controls.Add(tableLayoutPanel1);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            Resize += Form1_Resize;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            rightPanel.ResumeLayout(false);
            loginTableLayoutPanel.ResumeLayout(false);
            loginTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private Panel rightPanel;
        private TableLayoutPanel loginTableLayoutPanel;
        private Label labelTitle;
        private Label labelUser;
        private TextBox textBox1;
        private Label labelPass;
        private TextBox textBox2;
        private Button button1;
        private Button buttonClear;
    }
}