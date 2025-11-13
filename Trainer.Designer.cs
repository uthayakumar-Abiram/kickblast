namespace kickvlast
{
    partial class Trainer
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
            panelLeft = new Panel();
            qubox = new TextBox();
            lblName = new Label();
            textBoxName = new TextBox();
            lblNIC = new Label();
            textBoxNIC = new TextBox();
            lblContact = new Label();
            textBoxContact = new TextBox();
            lblAddress = new Label();
            textBoxAddress = new TextBox();
            lblQualification = new Label();
            lblExperience = new Label();
            numericExperience = new NumericUpDown();
            lblSalary = new Label();
            textBoxSalary = new NumericUpDown();
            btnSave = new Button();
            btnClear = new Button();
            panelRight = new Panel();
            dgvTrainers = new DataGridView();
            TrainerIDCol = new DataGridViewTextBoxColumn();
            TrainerNameCol = new DataGridViewTextBoxColumn();
            NICCol = new DataGridViewTextBoxColumn();
            ContactCol = new DataGridViewTextBoxColumn();
            AddressCol = new DataGridViewTextBoxColumn();
            QualificationCol = new DataGridViewTextBoxColumn();
            ExperienceCol = new DataGridViewTextBoxColumn();
            SalaryCol = new DataGridViewTextBoxColumn();
            ViewCol = new DataGridViewButtonColumn();
            del = new DataGridViewButtonColumn();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericExperience).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxSalary).BeginInit();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrainers).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(250, 250, 250);
            panelLeft.Controls.Add(qubox);
            panelLeft.Controls.Add(lblName);
            panelLeft.Controls.Add(textBoxName);
            panelLeft.Controls.Add(lblNIC);
            panelLeft.Controls.Add(textBoxNIC);
            panelLeft.Controls.Add(lblContact);
            panelLeft.Controls.Add(textBoxContact);
            panelLeft.Controls.Add(lblAddress);
            panelLeft.Controls.Add(textBoxAddress);
            panelLeft.Controls.Add(lblQualification);
            panelLeft.Controls.Add(lblExperience);
            panelLeft.Controls.Add(numericExperience);
            panelLeft.Controls.Add(lblSalary);
            panelLeft.Controls.Add(textBoxSalary);
            panelLeft.Controls.Add(btnSave);
            panelLeft.Controls.Add(btnClear);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(12);
            panelLeft.Size = new Size(380, 720);
            panelLeft.TabIndex = 1;
            // 
            // qubox
            // 
            qubox.Location = new Point(12, 378);
            qubox.Name = "qubox";
            qubox.Size = new Size(340, 27);
            qubox.TabIndex = 18;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 72);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 94);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(340, 27);
            textBoxName.TabIndex = 3;
            // 
            // lblNIC
            // 
            lblNIC.AutoSize = true;
            lblNIC.Location = new Point(12, 132);
            lblNIC.Name = "lblNIC";
            lblNIC.Size = new Size(91, 20);
            lblNIC.TabIndex = 4;
            lblNIC.Text = "NIC Number";
            // 
            // textBoxNIC
            // 
            textBoxNIC.Location = new Point(12, 154);
            textBoxNIC.Name = "textBoxNIC";
            textBoxNIC.Size = new Size(340, 27);
            textBoxNIC.TabIndex = 5;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(12, 192);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(84, 20);
            lblContact.TabIndex = 6;
            lblContact.Text = "Contact No";
            // 
            // textBoxContact
            // 
            textBoxContact.Location = new Point(12, 214);
            textBoxContact.Name = "textBoxContact";
            textBoxContact.Size = new Size(340, 27);
            textBoxContact.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(12, 252);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(62, 20);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Address";
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(12, 274);
            textBoxAddress.Multiline = true;
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(340, 60);
            textBoxAddress.TabIndex = 9;
            // 
            // lblQualification
            // 
            lblQualification.AutoSize = true;
            lblQualification.Location = new Point(12, 348);
            lblQualification.Name = "lblQualification";
            lblQualification.Size = new Size(94, 20);
            lblQualification.TabIndex = 10;
            lblQualification.Text = "Qualification";
            // 
            // lblExperience
            // 
            lblExperience.AutoSize = true;
            lblExperience.Location = new Point(12, 408);
            lblExperience.Name = "lblExperience";
            lblExperience.Size = new Size(129, 20);
            lblExperience.TabIndex = 12;
            lblExperience.Text = "Experience (years)";
            // 
            // numericExperience
            // 
            numericExperience.Location = new Point(12, 430);
            numericExperience.Name = "numericExperience";
            numericExperience.Size = new Size(120, 27);
            numericExperience.TabIndex = 13;
            numericExperience.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericExperience.ValueChanged += numericExperience_ValueChanged;
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Location = new Point(12, 468);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(49, 20);
            lblSalary.TabIndex = 14;
            lblSalary.Text = "Salary";
            // 
            // textBoxSalary
            // 
            textBoxSalary.DecimalPlaces = 2;
            textBoxSalary.Location = new Point(12, 490);
            textBoxSalary.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.Size = new Size(140, 27);
            textBoxSalary.TabIndex = 15;
            textBoxSalary.Value = new decimal(new int[] { 30000, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 120, 215);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(12, 540);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 36);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(200, 200, 200);
            btnClear.Location = new Point(152, 540);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 36);
            btnClear.TabIndex = 17;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.WhiteSmoke;
            panelRight.Controls.Add(dgvTrainers);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(380, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(12);
            panelRight.Size = new Size(620, 720);
            panelRight.TabIndex = 0;
            // 
            // dgvTrainers
            // 
            dgvTrainers.AllowUserToAddRows = false;
            dgvTrainers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrainers.ColumnHeadersHeight = 29;
            dgvTrainers.Columns.AddRange(new DataGridViewColumn[] { TrainerIDCol, TrainerNameCol, NICCol, ContactCol, AddressCol, QualificationCol, ExperienceCol, SalaryCol, ViewCol, del });
            dgvTrainers.Dock = DockStyle.Fill;
            dgvTrainers.Location = new Point(12, 12);
            dgvTrainers.Name = "dgvTrainers";
            dgvTrainers.ReadOnly = true;
            dgvTrainers.RowHeadersWidth = 51;
            dgvTrainers.Size = new Size(596, 696);
            dgvTrainers.TabIndex = 0;
            dgvTrainers.CellContentClick += dgvTrainers_CellContentClick;
            // 
            // TrainerIDCol
            // 
            TrainerIDCol.HeaderText = "Trainer ID";
            TrainerIDCol.MinimumWidth = 6;
            TrainerIDCol.Name = "TrainerIDCol";
            TrainerIDCol.ReadOnly = true;
            // 
            // TrainerNameCol
            // 
            TrainerNameCol.HeaderText = "Name";
            TrainerNameCol.MinimumWidth = 6;
            TrainerNameCol.Name = "TrainerNameCol";
            TrainerNameCol.ReadOnly = true;
            // 
            // NICCol
            // 
            NICCol.HeaderText = "NIC";
            NICCol.MinimumWidth = 6;
            NICCol.Name = "NICCol";
            NICCol.ReadOnly = true;
            // 
            // ContactCol
            // 
            ContactCol.HeaderText = "Contact";
            ContactCol.MinimumWidth = 6;
            ContactCol.Name = "ContactCol";
            ContactCol.ReadOnly = true;
            // 
            // AddressCol
            // 
            AddressCol.HeaderText = "Address";
            AddressCol.MinimumWidth = 6;
            AddressCol.Name = "AddressCol";
            AddressCol.ReadOnly = true;
            // 
            // QualificationCol
            // 
            QualificationCol.HeaderText = "Qualification";
            QualificationCol.MinimumWidth = 6;
            QualificationCol.Name = "QualificationCol";
            QualificationCol.ReadOnly = true;
            // 
            // ExperienceCol
            // 
            ExperienceCol.HeaderText = "Experience";
            ExperienceCol.MinimumWidth = 6;
            ExperienceCol.Name = "ExperienceCol";
            ExperienceCol.ReadOnly = true;
            // 
            // SalaryCol
            // 
            SalaryCol.HeaderText = "Salary";
            SalaryCol.MinimumWidth = 6;
            SalaryCol.Name = "SalaryCol";
            SalaryCol.ReadOnly = true;
            // 
            // ViewCol
            // 
            ViewCol.HeaderText = "View";
            ViewCol.MinimumWidth = 24;
            ViewCol.Name = "ViewCol";
            ViewCol.ReadOnly = true;
            ViewCol.Text = "👁";
            ViewCol.UseColumnTextForButtonValue = true;
            // 
            // del
            // 
            del.HeaderText = "Delete";
            del.MinimumWidth = 24;
            del.Name = "del";
            del.ReadOnly = true;
            del.Text = "🗑";
            del.UseColumnTextForButtonValue = true;
            // 
            // Trainer
            // 
            ClientSize = new Size(1000, 720);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Name = "Trainer";
            Text = "Add Trainer";
            Load += Trainer_Load;
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericExperience).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxSalary).EndInit();
            panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTrainers).EndInit();
            ResumeLayout(false);
        }

        private void numericExperience_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown textBoxSalary;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.NumericUpDown numericExperience;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblQualification;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox textBoxContact;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox textBoxNIC;
        private System.Windows.Forms.Label lblNIC;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox textBoxTrainerID;
        private System.Windows.Forms.Label lblTrainerID;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.DataGridView dgvTrainers;
        private TextBox qubox;
        private DataGridViewTextBoxColumn TrainerIDCol;
        private DataGridViewTextBoxColumn TrainerNameCol;
        private DataGridViewTextBoxColumn NICCol;
        private DataGridViewTextBoxColumn ContactCol;
        private DataGridViewTextBoxColumn AddressCol;
        private DataGridViewTextBoxColumn QualificationCol;
        private DataGridViewTextBoxColumn ExperienceCol;
        private DataGridViewTextBoxColumn SalaryCol;
        private DataGridViewButtonColumn ViewCol;
        private DataGridViewButtonColumn del;
    }
}