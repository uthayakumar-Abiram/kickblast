namespace kickvlast
{
    partial class Competition
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
            lblCompetitionID = new Label();
            txtCompetitionID = new TextBox();
            lblCreationDate = new Label();
            dtpCreationDate = new DateTimePicker();
            lblCoachingID = new Label();
            lblCoachingCreationDate = new Label();
            dtpCoachingCreationDate = new DateTimePicker();
            lblAthleteID = new Label();
            txtAthleteID = new TextBox();
            lblAthleteName = new Label();
            txtAthleteName = new TextBox();
            lblCurrentWeight = new Label();
            nudCurrentWeight = new NumericUpDown();
            lblWeightCategory = new Label();
            cmbWeightCategory = new ComboBox();
            lblCompetitionDate = new Label();
            dtpCompetitionDate = new DateTimePicker();
            dgvEntries = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            btnSave = new Button();
            btnClear = new Button();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudCurrentWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEntries).BeginInit();
            SuspendLayout();
            // 
            // lblCompetitionID
            // 
            lblCompetitionID.AutoSize = true;
            lblCompetitionID.Location = new Point(12, 15);
            lblCompetitionID.Name = "lblCompetitionID";
            lblCompetitionID.Size = new Size(114, 20);
            lblCompetitionID.TabIndex = 0;
            lblCompetitionID.Text = "Competition ID:";
            lblCompetitionID.Visible = false;
            // 
            // txtCompetitionID
            // 
            txtCompetitionID.Location = new Point(160, 12);
            txtCompetitionID.Name = "txtCompetitionID";
            txtCompetitionID.Size = new Size(200, 27);
            txtCompetitionID.TabIndex = 1;
            txtCompetitionID.Visible = false;
            // 
            // lblCreationDate
            // 
            lblCreationDate.AutoSize = true;
            lblCreationDate.Location = new Point(12, 50);
            lblCreationDate.Name = "lblCreationDate";
            lblCreationDate.Size = new Size(176, 20);
            lblCreationDate.TabIndex = 2;
            lblCreationDate.Text = "Date of Creation (Comp):";
            // 
            // dtpCreationDate
            // 
            dtpCreationDate.Format = DateTimePickerFormat.Short;
            dtpCreationDate.Location = new Point(160, 46);
            dtpCreationDate.Name = "dtpCreationDate";
            dtpCreationDate.Size = new Size(200, 27);
            dtpCreationDate.TabIndex = 3;
            // 
            // lblCoachingID
            // 
            lblCoachingID.AutoSize = true;
            lblCoachingID.Location = new Point(12, 85);
            lblCoachingID.Name = "lblCoachingID";
            lblCoachingID.Size = new Size(93, 20);
            lblCoachingID.TabIndex = 4;
            lblCoachingID.Text = "Coaching ID:";
            // 
            // lblCoachingCreationDate
            // 
            lblCoachingCreationDate.AutoSize = true;
            lblCoachingCreationDate.Location = new Point(12, 120);
            lblCoachingCreationDate.Name = "lblCoachingCreationDate";
            lblCoachingCreationDate.Size = new Size(177, 20);
            lblCoachingCreationDate.TabIndex = 6;
            lblCoachingCreationDate.Text = "Date of Creation (Coach):";
            // 
            // dtpCoachingCreationDate
            // 
            dtpCoachingCreationDate.Format = DateTimePickerFormat.Short;
            dtpCoachingCreationDate.Location = new Point(160, 116);
            dtpCoachingCreationDate.Name = "dtpCoachingCreationDate";
            dtpCoachingCreationDate.Size = new Size(200, 27);
            dtpCoachingCreationDate.TabIndex = 7;
            // 
            // lblAthleteID
            // 
            lblAthleteID.AutoSize = true;
            lblAthleteID.Location = new Point(12, 155);
            lblAthleteID.Name = "lblAthleteID";
            lblAthleteID.Size = new Size(79, 20);
            lblAthleteID.TabIndex = 8;
            lblAthleteID.Text = "Athlete ID:";
            // 
            // txtAthleteID
            // 
            txtAthleteID.Location = new Point(160, 152);
            txtAthleteID.Name = "txtAthleteID";
            txtAthleteID.Size = new Size(200, 27);
            txtAthleteID.TabIndex = 9;
            // 
            // lblAthleteName
            // 
            lblAthleteName.AutoSize = true;
            lblAthleteName.Location = new Point(12, 190);
            lblAthleteName.Name = "lblAthleteName";
            lblAthleteName.Size = new Size(104, 20);
            lblAthleteName.TabIndex = 10;
            lblAthleteName.Text = "Athlete Name:";
            // 
            // txtAthleteName
            // 
            txtAthleteName.Location = new Point(160, 187);
            txtAthleteName.Name = "txtAthleteName";
            txtAthleteName.Size = new Size(200, 27);
            txtAthleteName.TabIndex = 11;
            // 
            // lblCurrentWeight
            // 
            lblCurrentWeight.AutoSize = true;
            lblCurrentWeight.Location = new Point(12, 225);
            lblCurrentWeight.Name = "lblCurrentWeight";
            lblCurrentWeight.Size = new Size(111, 20);
            lblCurrentWeight.TabIndex = 12;
            lblCurrentWeight.Text = "Current Weight:";
            // 
            // nudCurrentWeight
            // 
            nudCurrentWeight.DecimalPlaces = 1;
            nudCurrentWeight.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudCurrentWeight.Location = new Point(160, 222);
            nudCurrentWeight.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudCurrentWeight.Name = "nudCurrentWeight";
            nudCurrentWeight.Size = new Size(100, 27);
            nudCurrentWeight.TabIndex = 13;
            // 
            // lblWeightCategory
            // 
            lblWeightCategory.AutoSize = true;
            lblWeightCategory.Location = new Point(12, 260);
            lblWeightCategory.Name = "lblWeightCategory";
            lblWeightCategory.Size = new Size(123, 20);
            lblWeightCategory.TabIndex = 14;
            lblWeightCategory.Text = "Weight Category:";
            // 
            // cmbWeightCategory
            // 
            cmbWeightCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWeightCategory.FormattingEnabled = true;
            cmbWeightCategory.Items.AddRange(new object[] { "Heavyweight", "Light–Heavyweight", "Middleweight", "Light–Middleweight", "Lightweight\t ", "Flyweight" });
            cmbWeightCategory.Location = new Point(160, 256);
            cmbWeightCategory.Name = "cmbWeightCategory";
            cmbWeightCategory.Size = new Size(200, 28);
            cmbWeightCategory.TabIndex = 15;
            // 
            // lblCompetitionDate
            // 
            lblCompetitionDate.AutoSize = true;
            lblCompetitionDate.Location = new Point(12, 295);
            lblCompetitionDate.Name = "lblCompetitionDate";
            lblCompetitionDate.Size = new Size(149, 20);
            lblCompetitionDate.TabIndex = 16;
            lblCompetitionDate.Text = "Date of Competition:";
            // 
            // dtpCompetitionDate
            // 
            dtpCompetitionDate.Format = DateTimePickerFormat.Short;
            dtpCompetitionDate.Location = new Point(160, 291);
            dtpCompetitionDate.Name = "dtpCompetitionDate";
            dtpCompetitionDate.Size = new Size(200, 27);
            dtpCompetitionDate.TabIndex = 17;
            // 
            // dgvEntries
            // 
            dgvEntries.AllowUserToAddRows = false;
            dgvEntries.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntries.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9 });
            dgvEntries.Location = new Point(365, 15);
            dgvEntries.MultiSelect = false;
            dgvEntries.Name = "dgvEntries";
            dgvEntries.RowHeadersWidth = 51;
            dgvEntries.RowTemplate.Height = 25;
            dgvEntries.Size = new Size(1000, 445);
            dgvEntries.TabIndex = 19;
            dgvEntries.CellContentClick += dgvEntries_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Competition ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Creation Date";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Coaching ID";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Coaching Creation Date";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Athlete ID";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Athlete Name";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Current Weight";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Weight Category";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Competition Date";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.Width = 125;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 120, 215);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(99, 347);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 36);
            btnSave.TabIndex = 20;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(200, 200, 200);
            btnClear.Location = new Point(239, 347);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 36);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(160, 84);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 28);
            comboBox1.TabIndex = 22;
            // 
            // Competition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1398, 475);
            Controls.Add(comboBox1);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(dgvEntries);
            Controls.Add(dtpCompetitionDate);
            Controls.Add(lblCompetitionDate);
            Controls.Add(cmbWeightCategory);
            Controls.Add(lblWeightCategory);
            Controls.Add(nudCurrentWeight);
            Controls.Add(lblCurrentWeight);
            Controls.Add(txtAthleteName);
            Controls.Add(lblAthleteName);
            Controls.Add(txtAthleteID);
            Controls.Add(lblAthleteID);
            Controls.Add(dtpCoachingCreationDate);
            Controls.Add(lblCoachingCreationDate);
            Controls.Add(lblCoachingID);
            Controls.Add(dtpCreationDate);
            Controls.Add(lblCreationDate);
            Controls.Add(txtCompetitionID);
            Controls.Add(lblCompetitionID);
            Name = "Competition";
            Text = "Competition";
            ((System.ComponentModel.ISupportInitialize)nudCurrentWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEntries).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCompetitionID;
        private System.Windows.Forms.TextBox txtCompetitionID;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.DateTimePicker dtpCreationDate;
        private System.Windows.Forms.Label lblCoachingID;
        private System.Windows.Forms.TextBox txtCoachingID;
        private System.Windows.Forms.Label lblCoachingCreationDate;
        private System.Windows.Forms.DateTimePicker dtpCoachingCreationDate;
        private System.Windows.Forms.Label lblAthleteID;
        private System.Windows.Forms.TextBox txtAthleteID;
        private System.Windows.Forms.Label lblAthleteName;
        private System.Windows.Forms.TextBox txtAthleteName;
        private System.Windows.Forms.Label lblCurrentWeight;
        private System.Windows.Forms.NumericUpDown nudCurrentWeight;
        private System.Windows.Forms.Label lblWeightCategory;
        private System.Windows.Forms.ComboBox cmbWeightCategory;
        private System.Windows.Forms.Label lblCompetitionDate;
        private System.Windows.Forms.DateTimePicker dtpCompetitionDate;
        private System.Windows.Forms.DataGridView dgvEntries;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Button btnSave;
        private Button btnClear;
        private ComboBox comboBox1;
    }
}