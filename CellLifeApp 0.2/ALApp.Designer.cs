namespace CellLifeApp
{
    partial class ALApp
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ALApp));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.saveButton = new System.Windows.Forms.Button();
            this.labelEnergy = new System.Windows.Forms.Label();
            this.labelCountOfGen = new System.Windows.Forms.Label();
            this.labelGeneration = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelCellType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelCharge = new System.Windows.Forms.Label();
            this.labelOrganic = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.camModeBox = new System.Windows.Forms.ComboBox();
            this.resolutionTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCamSpeed = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clear_button = new System.Windows.Forms.Button();
            this.pause_button = new System.Windows.Forms.Button();
            this.nudLifeSpeed = new System.Windows.Forms.NumericUpDown();
            this.SetFSize_button = new System.Windows.Forms.Button();
            this.label_FieldSize = new System.Windows.Forms.Label();
            this.label_LifeSpeed = new System.Windows.Forms.Label();
            this.nudFieldCols = new System.Windows.Forms.NumericUpDown();
            this.label_Resolution = new System.Windows.Forms.Label();
            this.label_Cols = new System.Windows.Forms.Label();
            this.label_Rows = new System.Windows.Forms.Label();
            this.nudFieldRows = new System.Windows.Forms.NumericUpDown();
            this.screen = new System.Windows.Forms.PictureBox();
            this.LifeTimer = new System.Windows.Forms.Timer(this.components);
            this.PrintTimer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCamSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLifeSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.saveButton);
            this.splitContainer1.Panel1.Controls.Add(this.labelEnergy);
            this.splitContainer1.Panel1.Controls.Add(this.labelCountOfGen);
            this.splitContainer1.Panel1.Controls.Add(this.labelGeneration);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.labelCellType);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.labelCharge);
            this.splitContainer1.Panel1.Controls.Add(this.labelOrganic);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.camModeBox);
            this.splitContainer1.Panel1.Controls.Add(this.resolutionTrackBar);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.nudCamSpeed);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.clear_button);
            this.splitContainer1.Panel1.Controls.Add(this.pause_button);
            this.splitContainer1.Panel1.Controls.Add(this.nudLifeSpeed);
            this.splitContainer1.Panel1.Controls.Add(this.SetFSize_button);
            this.splitContainer1.Panel1.Controls.Add(this.label_FieldSize);
            this.splitContainer1.Panel1.Controls.Add(this.label_LifeSpeed);
            this.splitContainer1.Panel1.Controls.Add(this.nudFieldCols);
            this.splitContainer1.Panel1.Controls.Add(this.label_Resolution);
            this.splitContainer1.Panel1.Controls.Add(this.label_Cols);
            this.splitContainer1.Panel1.Controls.Add(this.label_Rows);
            this.splitContainer1.Panel1.Controls.Add(this.nudFieldRows);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.screen);
            this.splitContainer1.Size = new System.Drawing.Size(1006, 602);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(78, 309);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(10, 10);
            this.saveButton.TabIndex = 63;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // labelEnergy
            // 
            this.labelEnergy.AutoSize = true;
            this.labelEnergy.Location = new System.Drawing.Point(3, 322);
            this.labelEnergy.Name = "labelEnergy";
            this.labelEnergy.Size = new System.Drawing.Size(39, 13);
            this.labelEnergy.TabIndex = 62;
            this.labelEnergy.Text = "energy";
            // 
            // labelCountOfGen
            // 
            this.labelCountOfGen.AutoSize = true;
            this.labelCountOfGen.Location = new System.Drawing.Point(3, 377);
            this.labelCountOfGen.Name = "labelCountOfGen";
            this.labelCountOfGen.Size = new System.Drawing.Size(35, 13);
            this.labelCountOfGen.TabIndex = 61;
            this.labelCountOfGen.Text = "label8";
            // 
            // labelGeneration
            // 
            this.labelGeneration.AutoSize = true;
            this.labelGeneration.Location = new System.Drawing.Point(3, 361);
            this.labelGeneration.Name = "labelGeneration";
            this.labelGeneration.Size = new System.Drawing.Size(35, 13);
            this.labelGeneration.TabIndex = 60;
            this.labelGeneration.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Generation:";
            // 
            // labelCellType
            // 
            this.labelCellType.AutoSize = true;
            this.labelCellType.Location = new System.Drawing.Point(3, 309);
            this.labelCellType.Name = "labelCellType";
            this.labelCellType.Size = new System.Drawing.Size(27, 13);
            this.labelCellType.TabIndex = 58;
            this.labelCellType.Text = "type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Cell Type:";
            // 
            // labelCharge
            // 
            this.labelCharge.AutoSize = true;
            this.labelCharge.Location = new System.Drawing.Point(48, 283);
            this.labelCharge.Name = "labelCharge";
            this.labelCharge.Size = new System.Drawing.Size(40, 13);
            this.labelCharge.TabIndex = 56;
            this.labelCharge.Text = "charge";
            // 
            // labelOrganic
            // 
            this.labelOrganic.AutoSize = true;
            this.labelOrganic.Location = new System.Drawing.Point(48, 270);
            this.labelOrganic.Name = "labelOrganic";
            this.labelOrganic.Size = new System.Drawing.Size(42, 13);
            this.labelOrganic.TabIndex = 55;
            this.labelOrganic.Text = "organic";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Charge:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Organic:";
            // 
            // camModeBox
            // 
            this.camModeBox.AllowDrop = true;
            this.camModeBox.CausesValidation = false;
            this.camModeBox.FormattingEnabled = true;
            this.camModeBox.Items.AddRange(new object[] {
            "Default",
            "Organic",
            "Charge"});
            this.camModeBox.Location = new System.Drawing.Point(4, 436);
            this.camModeBox.Name = "camModeBox";
            this.camModeBox.Size = new System.Drawing.Size(90, 21);
            this.camModeBox.TabIndex = 52;
            this.camModeBox.TabStop = false;
            // 
            // resolutionTrackBar
            // 
            this.resolutionTrackBar.LargeChange = 1;
            this.resolutionTrackBar.Location = new System.Drawing.Point(3, 27);
            this.resolutionTrackBar.Maximum = 8;
            this.resolutionTrackBar.Minimum = 1;
            this.resolutionTrackBar.Name = "resolutionTrackBar";
            this.resolutionTrackBar.Size = new System.Drawing.Size(92, 45);
            this.resolutionTrackBar.TabIndex = 51;
            this.resolutionTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.resolutionTrackBar.Value = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 50;
            this.label3.Text = "Cam speed:";
            // 
            // nudCamSpeed
            // 
            this.nudCamSpeed.InterceptArrowKeys = false;
            this.nudCamSpeed.Location = new System.Drawing.Point(3, 410);
            this.nudCamSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCamSpeed.Name = "nudCamSpeed";
            this.nudCamSpeed.ReadOnly = true;
            this.nudCamSpeed.Size = new System.Drawing.Size(92, 20);
            this.nudCamSpeed.TabIndex = 49;
            this.nudCamSpeed.TabStop = false;
            this.nudCamSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCamSpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "label1";
            // 
            // clear_button
            // 
            this.clear_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clear_button.Location = new System.Drawing.Point(3, 466);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(92, 36);
            this.clear_button.TabIndex = 46;
            this.clear_button.TabStop = false;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            // 
            // pause_button
            // 
            this.pause_button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pause_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pause_button.Location = new System.Drawing.Point(3, 540);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(192, 57);
            this.pause_button.TabIndex = 45;
            this.pause_button.Text = "Start";
            this.pause_button.UseVisualStyleBackColor = false;
            // 
            // nudLifeSpeed
            // 
            this.nudLifeSpeed.Location = new System.Drawing.Point(3, 102);
            this.nudLifeSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudLifeSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLifeSpeed.Name = "nudLifeSpeed";
            this.nudLifeSpeed.ReadOnly = true;
            this.nudLifeSpeed.Size = new System.Drawing.Size(92, 20);
            this.nudLifeSpeed.TabIndex = 44;
            this.nudLifeSpeed.TabStop = false;
            this.nudLifeSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLifeSpeed.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // SetFSize_button
            // 
            this.SetFSize_button.Location = new System.Drawing.Point(3, 221);
            this.SetFSize_button.Name = "SetFSize_button";
            this.SetFSize_button.Size = new System.Drawing.Size(92, 23);
            this.SetFSize_button.TabIndex = 42;
            this.SetFSize_button.TabStop = false;
            this.SetFSize_button.Text = "Set Size";
            this.SetFSize_button.UseVisualStyleBackColor = true;
            // 
            // label_FieldSize
            // 
            this.label_FieldSize.AutoSize = true;
            this.label_FieldSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_FieldSize.Location = new System.Drawing.Point(14, 150);
            this.label_FieldSize.Name = "label_FieldSize";
            this.label_FieldSize.Size = new System.Drawing.Size(81, 16);
            this.label_FieldSize.TabIndex = 35;
            this.label_FieldSize.Text = "Field Size:";
            // 
            // label_LifeSpeed
            // 
            this.label_LifeSpeed.AutoSize = true;
            this.label_LifeSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_LifeSpeed.Location = new System.Drawing.Point(8, 83);
            this.label_LifeSpeed.Name = "label_LifeSpeed";
            this.label_LifeSpeed.Size = new System.Drawing.Size(87, 16);
            this.label_LifeSpeed.TabIndex = 43;
            this.label_LifeSpeed.Text = "Life Speed:";
            // 
            // nudFieldCols
            // 
            this.nudFieldCols.Location = new System.Drawing.Point(43, 169);
            this.nudFieldCols.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudFieldCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFieldCols.Name = "nudFieldCols";
            this.nudFieldCols.Size = new System.Drawing.Size(52, 20);
            this.nudFieldCols.TabIndex = 36;
            this.nudFieldCols.TabStop = false;
            this.nudFieldCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFieldCols.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label_Resolution
            // 
            this.label_Resolution.AutoSize = true;
            this.label_Resolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Resolution.Location = new System.Drawing.Point(9, 8);
            this.label_Resolution.Name = "label_Resolution";
            this.label_Resolution.Size = new System.Drawing.Size(86, 16);
            this.label_Resolution.TabIndex = 40;
            this.label_Resolution.Text = "Resolution:";
            // 
            // label_Cols
            // 
            this.label_Cols.AutoSize = true;
            this.label_Cols.Location = new System.Drawing.Point(3, 171);
            this.label_Cols.Name = "label_Cols";
            this.label_Cols.Size = new System.Drawing.Size(27, 13);
            this.label_Cols.TabIndex = 37;
            this.label_Cols.Text = "Cols";
            // 
            // label_Rows
            // 
            this.label_Rows.AutoSize = true;
            this.label_Rows.Location = new System.Drawing.Point(3, 197);
            this.label_Rows.Name = "label_Rows";
            this.label_Rows.Size = new System.Drawing.Size(34, 13);
            this.label_Rows.TabIndex = 38;
            this.label_Rows.Text = "Rows";
            // 
            // nudFieldRows
            // 
            this.nudFieldRows.Location = new System.Drawing.Point(43, 195);
            this.nudFieldRows.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudFieldRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFieldRows.Name = "nudFieldRows";
            this.nudFieldRows.Size = new System.Drawing.Size(52, 20);
            this.nudFieldRows.TabIndex = 39;
            this.nudFieldRows.TabStop = false;
            this.nudFieldRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFieldRows.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // screen
            // 
            this.screen.BackColor = System.Drawing.Color.Gray;
            this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screen.Location = new System.Drawing.Point(0, 0);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(800, 600);
            this.screen.TabIndex = 0;
            this.screen.TabStop = false;
            // 
            // LifeTimer
            // 
            this.LifeTimer.Interval = 20;
            // 
            // PrintTimer
            // 
            this.PrintTimer.Enabled = true;
            this.PrintTimer.Interval = 1;
            this.PrintTimer.Tick += new System.EventHandler(this.PrintTimer_Tick);
            // 
            // ALApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 602);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ALApp";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resolutionTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCamSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLifeSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown nudLifeSpeed;
        private System.Windows.Forms.Button SetFSize_button;
        private System.Windows.Forms.Label label_FieldSize;
        private System.Windows.Forms.Label label_LifeSpeed;
        private System.Windows.Forms.NumericUpDown nudFieldCols;
        private System.Windows.Forms.Label label_Resolution;
        private System.Windows.Forms.Label label_Cols;
        private System.Windows.Forms.Label label_Rows;
        private System.Windows.Forms.NumericUpDown nudFieldRows;
        private System.Windows.Forms.Button pause_button;
        private System.Windows.Forms.Timer LifeTimer;
        private System.Windows.Forms.Timer PrintTimer;
        internal System.Windows.Forms.PictureBox screen;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCamSpeed;
        private System.Windows.Forms.TrackBar resolutionTrackBar;
        private System.Windows.Forms.ComboBox camModeBox;
        private System.Windows.Forms.Label labelCharge;
        private System.Windows.Forms.Label labelOrganic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCellType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelGeneration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCountOfGen;
        private System.Windows.Forms.Label labelEnergy;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

