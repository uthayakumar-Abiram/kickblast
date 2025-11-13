namespace kickvlast
{
    partial class dashboard
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
            lblTitle = new Label();
            sidebarFlow = new FlowLayoutPanel();
            btnOverview = new Button();
            btnTrainingPlans = new Button();
            btnWeightCategories = new Button();
            btnAthletes = new Button();
            comp1 = new Button();
            button5 = new Button();
            rightPanel = new Panel();
            rightInnerTable = new TableLayoutPanel();
            lblTrainingHeader = new Label();
            trainingTable = new TableLayoutPanel();
            lblWeightHeader = new Label();
            weightTable = new TableLayoutPanel();
            sidebarFlow.SuspendLayout();
            rightPanel.SuspendLayout();
            rightInnerTable.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(30, 30, 30);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(16, 0, 0, 0);
            lblTitle.Size = new Size(1000, 64);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "KickBlast Judo - Admin Dashboard";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sidebarFlow
            // 
            sidebarFlow.BackColor = Color.FromArgb(45, 45, 48);
            sidebarFlow.Controls.Add(btnOverview);
            sidebarFlow.Controls.Add(btnTrainingPlans);
            sidebarFlow.Controls.Add(btnWeightCategories);
            sidebarFlow.Controls.Add(btnAthletes);
            sidebarFlow.Controls.Add(comp1);
            sidebarFlow.Controls.Add(button5);
            sidebarFlow.Dock = DockStyle.Left;
            sidebarFlow.FlowDirection = FlowDirection.TopDown;
            sidebarFlow.Location = new Point(0, 64);
            sidebarFlow.Name = "sidebarFlow";
            sidebarFlow.Padding = new Padding(8);
            sidebarFlow.Size = new Size(200, 536);
            sidebarFlow.TabIndex = 1;
            sidebarFlow.WrapContents = false;
            // 
            // btnOverview
            // 
            btnOverview.BackColor = Color.FromArgb(63, 63, 70);
            btnOverview.FlatStyle = FlatStyle.Flat;
            btnOverview.ForeColor = Color.White;
            btnOverview.Location = new Point(16, 16);
            btnOverview.Margin = new Padding(8);
            btnOverview.Name = "btnOverview";
            btnOverview.Size = new Size(176, 40);
            btnOverview.TabIndex = 0;
            btnOverview.Text = "Overview";
            btnOverview.UseVisualStyleBackColor = false;
            // 
            // btnTrainingPlans
            // 
            btnTrainingPlans.BackColor = Color.FromArgb(63, 63, 70);
            btnTrainingPlans.FlatStyle = FlatStyle.Flat;
            btnTrainingPlans.ForeColor = Color.White;
            btnTrainingPlans.Location = new Point(16, 72);
            btnTrainingPlans.Margin = new Padding(8);
            btnTrainingPlans.Name = "btnTrainingPlans";
            btnTrainingPlans.Size = new Size(176, 40);
            btnTrainingPlans.TabIndex = 1;
            btnTrainingPlans.Text = "Training Plans";
            btnTrainingPlans.UseVisualStyleBackColor = false;
            btnTrainingPlans.Click += btnTrainingPlans_Click;
            // 
            // btnWeightCategories
            // 
            btnWeightCategories.BackColor = Color.FromArgb(63, 63, 70);
            btnWeightCategories.FlatStyle = FlatStyle.Flat;
            btnWeightCategories.ForeColor = Color.White;
            btnWeightCategories.Location = new Point(16, 128);
            btnWeightCategories.Margin = new Padding(8);
            btnWeightCategories.Name = "btnWeightCategories";
            btnWeightCategories.Size = new Size(176, 40);
            btnWeightCategories.TabIndex = 2;
            btnWeightCategories.Text = "Coaching";
            btnWeightCategories.UseVisualStyleBackColor = false;
            btnWeightCategories.Click += btnWeightCategories_Click;
            // 
            // btnAthletes
            // 
            btnAthletes.BackColor = Color.FromArgb(63, 63, 70);
            btnAthletes.FlatStyle = FlatStyle.Flat;
            btnAthletes.ForeColor = Color.White;
            btnAthletes.Location = new Point(16, 184);
            btnAthletes.Margin = new Padding(8);
            btnAthletes.Name = "btnAthletes";
            btnAthletes.Size = new Size(176, 40);
            btnAthletes.TabIndex = 3;
            btnAthletes.Text = "Athletes";
            btnAthletes.UseVisualStyleBackColor = false;
            btnAthletes.Click += btnAthletes_Click;
            // 
            // comp1
            // 
            comp1.BackColor = Color.FromArgb(63, 63, 70);
            comp1.FlatStyle = FlatStyle.Flat;
            comp1.ForeColor = Color.White;
            comp1.Location = new Point(16, 240);
            comp1.Margin = new Padding(8);
            comp1.Name = "comp1";
            comp1.Size = new Size(176, 40);
            comp1.TabIndex = 4;
            comp1.Text = "Competition";
            comp1.UseVisualStyleBackColor = false;
            comp1.Click += comp1_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(63, 63, 70);
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.White;
            button5.Location = new Point(16, 296);
            button5.Margin = new Padding(8);
            button5.Name = "button5";
            button5.Size = new Size(176, 40);
            button5.TabIndex = 5;
            button5.Text = "Logout";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.WhiteSmoke;
            rightPanel.Controls.Add(rightInnerTable);
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Location = new Point(199, 64);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(12);
            rightPanel.Size = new Size(801, 536);
            rightPanel.TabIndex = 1;
            // 
            // rightInnerTable
            // 
            rightInnerTable.ColumnCount = 1;
            rightInnerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightInnerTable.Controls.Add(lblTrainingHeader, 0, 0);
            rightInnerTable.Controls.Add(trainingTable, 0, 1);
            rightInnerTable.Controls.Add(lblWeightHeader, 0, 2);
            rightInnerTable.Controls.Add(weightTable, 0, 3);
            rightInnerTable.Dock = DockStyle.Fill;
            rightInnerTable.Location = new Point(12, 12);
            rightInnerTable.Name = "rightInnerTable";
            rightInnerTable.Padding = new Padding(6);
            rightInnerTable.RowCount = 4;
            rightInnerTable.RowStyles.Add(new RowStyle());
            rightInnerTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            rightInnerTable.RowStyles.Add(new RowStyle());
            rightInnerTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            rightInnerTable.Size = new Size(777, 512);
            rightInnerTable.TabIndex = 0;
            // 
            // lblTrainingHeader
            // 
            lblTrainingHeader.AutoSize = true;
            lblTrainingHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTrainingHeader.Location = new Point(9, 12);
            lblTrainingHeader.Margin = new Padding(3, 6, 3, 6);
            lblTrainingHeader.Name = "lblTrainingHeader";
            lblTrainingHeader.Size = new Size(246, 25);
            lblTrainingHeader.TabIndex = 0;
            lblTrainingHeader.Text = "Training Plan – Prices (Rs.)";
            // 
            // trainingTable
            // 
            trainingTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            trainingTable.ColumnCount = 2;
            trainingTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            trainingTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            trainingTable.Dock = DockStyle.Fill;
            trainingTable.Location = new Point(9, 46);
            trainingTable.Name = "trainingTable";
            trainingTable.Padding = new Padding(6);
            trainingTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            trainingTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            trainingTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            trainingTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            trainingTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            trainingTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            trainingTable.Size = new Size(759, 207);
            trainingTable.TabIndex = 1;
            // 
            // lblWeightHeader
            // 
            lblWeightHeader.AutoSize = true;
            lblWeightHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblWeightHeader.Location = new Point(9, 262);
            lblWeightHeader.Margin = new Padding(3, 6, 3, 6);
            lblWeightHeader.Name = "lblWeightHeader";
            lblWeightHeader.Size = new Size(171, 25);
            lblWeightHeader.TabIndex = 2;
            lblWeightHeader.Text = "Weight categories";
            // 
            // weightTable
            // 
            weightTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            weightTable.ColumnCount = 2;
            weightTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            weightTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            weightTable.Dock = DockStyle.Fill;
            weightTable.Location = new Point(9, 296);
            weightTable.Name = "weightTable";
            weightTable.Padding = new Padding(6);
            weightTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            weightTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            weightTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            weightTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            weightTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            weightTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            weightTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            weightTable.Size = new Size(759, 207);
            weightTable.TabIndex = 3;
            // 
            // dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(rightPanel);
            Controls.Add(sidebarFlow);
            Controls.Add(lblTitle);
            Name = "dashboard";
            Text = "Dashboard";
            Load += dashboard_Load;
            sidebarFlow.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            rightInnerTable.ResumeLayout(false);
            rightInnerTable.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel sidebarFlow;
        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.Button btnTrainingPlans;
        private System.Windows.Forms.Button btnWeightCategories;
        private System.Windows.Forms.Button btnAthletes;
        private System.Windows.Forms.Button comp1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.TableLayoutPanel rightInnerTable;
        private System.Windows.Forms.Label lblTrainingHeader;
        private System.Windows.Forms.TableLayoutPanel trainingTable;
        private System.Windows.Forms.Label lblWeightHeader;
        private System.Windows.Forms.TableLayoutPanel weightTable;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}