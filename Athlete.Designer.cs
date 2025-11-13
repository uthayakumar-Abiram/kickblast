namespace kickvlast
{
    partial class Athlete
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
            lblName = new Label();
            textBoxName = new TextBox();
            lblNIC = new Label();
            textBoxNIC = new TextBox();
            lblContact = new Label();
            textBoxContact = new TextBox();
            lblAddress = new Label();
            textBoxAddress = new TextBox();
            lblWeight = new Label();
            numericWeight = new NumericUpDown();
            lblHeight = new Label();
            numericHeight = new NumericUpDown();
            lblBMI = new Label();
            textBoxBMI = new TextBox();
            lblCategory = new Label();
            comboCategory = new ComboBox();
            lblBloodGroup = new Label();
            comboBloodGroup = new ComboBox();
            btnSave = new Button();
            btnClear = new Button();
            panelRight = new Panel();
            dgvAthletes = new DataGridView();
            AthleteIDCol = new DataGridViewTextBoxColumn();
            NameCol = new DataGridViewTextBoxColumn();
            NICCol = new DataGridViewTextBoxColumn();
            ContactCol = new DataGridViewTextBoxColumn();
            AddressCol = new DataGridViewTextBoxColumn();
            WeightCol = new DataGridViewTextBoxColumn();
            CategoryCol = new DataGridViewTextBoxColumn();
            HeightCol = new DataGridViewTextBoxColumn();
            BMICol = new DataGridViewTextBoxColumn();
            BloodGroupCol = new DataGridViewTextBoxColumn();
            view = new DataGridViewButtonColumn();
            delete = new DataGridViewButtonColumn();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).BeginInit();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAthletes).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(250, 250, 250);
            panelLeft.Controls.Add(lblName);
            panelLeft.Controls.Add(textBoxName);
            panelLeft.Controls.Add(lblNIC);
            panelLeft.Controls.Add(textBoxNIC);
            panelLeft.Controls.Add(lblContact);
            panelLeft.Controls.Add(textBoxContact);
            panelLeft.Controls.Add(lblAddress);
            panelLeft.Controls.Add(textBoxAddress);
            panelLeft.Controls.Add(lblWeight);
            panelLeft.Controls.Add(numericWeight);
            panelLeft.Controls.Add(lblHeight);
            panelLeft.Controls.Add(numericHeight);
            panelLeft.Controls.Add(lblBMI);
            panelLeft.Controls.Add(textBoxBMI);
            panelLeft.Controls.Add(lblCategory);
            panelLeft.Controls.Add(comboCategory);
            panelLeft.Controls.Add(lblBloodGroup);
            panelLeft.Controls.Add(comboBloodGroup);
            panelLeft.Controls.Add(btnSave);
            panelLeft.Controls.Add(btnClear);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(12);
            panelLeft.Size = new Size(380, 606);
            panelLeft.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 68);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 90);
            textBoxName.Name = "textBoxName";
            textBoxName.ScrollBars = ScrollBars.Vertical;
            textBoxName.Size = new Size(340, 27);
            textBoxName.TabIndex = 3;
            // 
            // lblNIC
            // 
            lblNIC.AutoSize = true;
            lblNIC.Location = new Point(12, 128);
            lblNIC.Name = "lblNIC";
            lblNIC.Size = new Size(91, 20);
            lblNIC.TabIndex = 4;
            lblNIC.Text = "NIC Number";
            // 
            // textBoxNIC
            // 
            textBoxNIC.Location = new Point(12, 150);
            textBoxNIC.Name = "textBoxNIC";
            textBoxNIC.Size = new Size(340, 27);
            textBoxNIC.TabIndex = 5;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(12, 188);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(84, 20);
            lblContact.TabIndex = 6;
            lblContact.Text = "Contact No";
            // 
            // textBoxContact
            // 
            textBoxContact.Location = new Point(12, 210);
            textBoxContact.Name = "textBoxContact";
            textBoxContact.Size = new Size(340, 27);
            textBoxContact.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(12, 248);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(62, 20);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Address";
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(12, 270);
            textBoxAddress.Multiline = true;
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(340, 60);
            textBoxAddress.TabIndex = 9;
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Location = new Point(12, 344);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(138, 20);
            lblWeight.TabIndex = 10;
            lblWeight.Text = "Current Weight (kg)";
            // 
            // numericWeight
            // 
            numericWeight.DecimalPlaces = 1;
            numericWeight.Location = new Point(12, 366);
            numericWeight.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericWeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericWeight.Name = "numericWeight";
            numericWeight.Size = new Size(120, 27);
            numericWeight.TabIndex = 11;
            numericWeight.Value = new decimal(new int[] { 70, 0, 0, 0 });
            numericWeight.ValueChanged += Numeric_ValueChanged;
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Location = new Point(12, 404);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(88, 20);
            lblHeight.TabIndex = 12;
            lblHeight.Text = "Height (cm)";
            // 
            // numericHeight
            // 
            numericHeight.Location = new Point(12, 426);
            numericHeight.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numericHeight.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            numericHeight.Name = "numericHeight";
            numericHeight.Size = new Size(120, 27);
            numericHeight.TabIndex = 13;
            numericHeight.Value = new decimal(new int[] { 170, 0, 0, 0 });
            numericHeight.ValueChanged += Numeric_ValueChanged;
            // 
            // lblBMI
            // 
            lblBMI.AutoSize = true;
            lblBMI.Location = new Point(12, 464);
            lblBMI.Name = "lblBMI";
            lblBMI.Size = new Size(35, 20);
            lblBMI.TabIndex = 14;
            lblBMI.Text = "BMI";
            // 
            // textBoxBMI
            // 
            textBoxBMI.Location = new Point(12, 486);
            textBoxBMI.Name = "textBoxBMI";
            textBoxBMI.ReadOnly = true;
            textBoxBMI.Size = new Size(120, 27);
            textBoxBMI.TabIndex = 15;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(12, 524);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(120, 20);
            lblCategory.TabIndex = 16;
            lblCategory.Text = "Weight Category";
            // 
            // comboCategory
            // 
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategory.Items.AddRange(new object[] { "Heavyweight", "Light–Heavyweight", "Middleweight", "Light–Middleweight", "Lightweight", "Flyweight" });
            comboCategory.Location = new Point(12, 546);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(200, 28);
            comboCategory.TabIndex = 17;
            // 
            // lblBloodGroup
            // 
            lblBloodGroup.AutoSize = true;
            lblBloodGroup.Location = new Point(12, 584);
            lblBloodGroup.Name = "lblBloodGroup";
            lblBloodGroup.Size = new Size(94, 20);
            lblBloodGroup.TabIndex = 18;
            lblBloodGroup.Text = "Blood Group";
            // 
            // comboBloodGroup
            // 
            comboBloodGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBloodGroup.Items.AddRange(new object[] { "A+", "A-", "B+", "B-", "O+", "O-", "AB+", "AB-" });
            comboBloodGroup.Location = new Point(12, 606);
            comboBloodGroup.Name = "comboBloodGroup";
            comboBloodGroup.Size = new Size(120, 28);
            comboBloodGroup.TabIndex = 19;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 120, 215);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(12, 646);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 36);
            btnSave.TabIndex = 20;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(200, 200, 200);
            btnClear.Location = new Point(152, 646);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 36);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.WhiteSmoke;
            panelRight.Controls.Add(dgvAthletes);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(380, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(12);
            panelRight.Size = new Size(801, 606);
            panelRight.TabIndex = 0;
            // 
            // dgvAthletes
            // 
            dgvAthletes.AllowUserToAddRows = false;
            dgvAthletes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAthletes.ColumnHeadersHeight = 29;
            dgvAthletes.Columns.AddRange(new DataGridViewColumn[] { AthleteIDCol, NameCol, NICCol, ContactCol, AddressCol, WeightCol, CategoryCol, HeightCol, BMICol, BloodGroupCol, view, delete });
            dgvAthletes.Dock = DockStyle.Fill;
            dgvAthletes.Location = new Point(12, 12);
            dgvAthletes.Name = "dgvAthletes";
            dgvAthletes.RowHeadersWidth = 51;
            dgvAthletes.Size = new Size(777, 582);
            dgvAthletes.TabIndex = 0;
            dgvAthletes.CellContentClick += dgvAthletes_CellContentClick;
            // 
            // AthleteIDCol
            // 
            AthleteIDCol.HeaderText = "Athlete ID";
            AthleteIDCol.MinimumWidth = 6;
            AthleteIDCol.Name = "AthleteIDCol";
            AthleteIDCol.ReadOnly = true;
            // 
            // NameCol
            // 
            NameCol.HeaderText = "Name";
            NameCol.MinimumWidth = 6;
            NameCol.Name = "NameCol";
            NameCol.ReadOnly = true;
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
            // WeightCol
            // 
            WeightCol.HeaderText = "Weight (kg)";
            WeightCol.MinimumWidth = 6;
            WeightCol.Name = "WeightCol";
            WeightCol.ReadOnly = true;
            // 
            // CategoryCol
            // 
            CategoryCol.HeaderText = "Category";
            CategoryCol.MinimumWidth = 6;
            CategoryCol.Name = "CategoryCol";
            CategoryCol.ReadOnly = true;
            // 
            // HeightCol
            // 
            HeightCol.HeaderText = "Height (cm)";
            HeightCol.MinimumWidth = 6;
            HeightCol.Name = "HeightCol";
            HeightCol.ReadOnly = true;
            // 
            // BMICol
            // 
            BMICol.HeaderText = "BMI";
            BMICol.MinimumWidth = 6;
            BMICol.Name = "BMICol";
            BMICol.ReadOnly = true;
            // 
            // BloodGroupCol
            // 
            BloodGroupCol.HeaderText = "Blood Group";
            BloodGroupCol.MinimumWidth = 6;
            BloodGroupCol.Name = "BloodGroupCol";
            BloodGroupCol.ReadOnly = true;
            // 
            // view
            // 
            view.HeaderText = "View";
            view.MinimumWidth = 6;
            view.Name = "view";
            view.Resizable = DataGridViewTriState.True;
            view.SortMode = DataGridViewColumnSortMode.Automatic;
            view.Text = "👁";
            view.UseColumnTextForButtonValue = true;
            // 
            // delete
            // 
            delete.HeaderText = "Delete";
            delete.MinimumWidth = 6;
            delete.Name = "delete";
            delete.Resizable = DataGridViewTriState.True;
            delete.SortMode = DataGridViewColumnSortMode.Automatic;
            delete.Text = "🗑";
            delete.UseColumnTextForButtonValue = true;
            // 
            // Athlete
            // 
            ClientSize = new Size(1181, 606);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Name = "Athlete";
            Text = "Add Athlete";
            Load += Athlete_Load;
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).EndInit();
            panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAthletes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox comboBloodGroup;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox textBoxBMI;
        private System.Windows.Forms.Label lblBMI;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.NumericUpDown numericWeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox textBoxContact;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox textBoxNIC;
        private System.Windows.Forms.Label lblNIC;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.DataGridView dgvAthletes;
        private DataGridViewTextBoxColumn AthleteIDCol;
        private DataGridViewTextBoxColumn NameCol;
        private DataGridViewTextBoxColumn NICCol;
        private DataGridViewTextBoxColumn ContactCol;
        private DataGridViewTextBoxColumn AddressCol;
        private DataGridViewTextBoxColumn WeightCol;
        private DataGridViewTextBoxColumn CategoryCol;
        private DataGridViewTextBoxColumn HeightCol;
        private DataGridViewTextBoxColumn BMICol;
        private DataGridViewTextBoxColumn BloodGroupCol;
        private DataGridViewButtonColumn view;
        private DataGridViewButtonColumn delete;
    }
}