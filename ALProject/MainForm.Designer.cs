namespace ALProject
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.nudLifeSpeed = new System.Windows.Forms.NumericUpDown();
            this.SetFSize_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudResolution = new System.Windows.Forms.NumericUpDown();
            this.nudFieldRows = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudFieldCols = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.clear_button = new System.Windows.Forms.Button();
            this.random_button = new System.Windows.Forms.Button();
            this.pause_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.open_button = new System.Windows.Forms.Button();
            this.screen = new System.Windows.Forms.PictureBox();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PrintTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLifeSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.screen);
            this.splitContainer1.Size = new System.Drawing.Size(944, 604);
            this.splitContainer1.SplitterDistance = 136;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.nudLifeSpeed);
            this.splitContainer2.Panel1.Controls.Add(this.SetFSize_button);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.nudResolution);
            this.splitContainer2.Panel1.Controls.Add(this.nudFieldRows);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.nudFieldCols);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.clear_button);
            this.splitContainer2.Panel2.Controls.Add(this.random_button);
            this.splitContainer2.Panel2.Controls.Add(this.pause_button);
            this.splitContainer2.Panel2.Controls.Add(this.save_button);
            this.splitContainer2.Panel2.Controls.Add(this.open_button);
            this.splitContainer2.Size = new System.Drawing.Size(132, 600);
            this.splitContainer2.SplitterDistance = 262;
            this.splitContainer2.TabIndex = 0;
            // 
            // nudLifeSpeed
            // 
            this.nudLifeSpeed.Location = new System.Drawing.Point(6, 80);
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
            this.nudLifeSpeed.Size = new System.Drawing.Size(119, 20);
            this.nudLifeSpeed.TabIndex = 34;
            this.nudLifeSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLifeSpeed.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudLifeSpeed.ValueChanged += new System.EventHandler(this.nudLifeSpeed_ValueChanged);
            // 
            // SetFSize_button
            // 
            this.SetFSize_button.Location = new System.Drawing.Point(6, 199);
            this.SetFSize_button.Name = "SetFSize_button";
            this.SetFSize_button.Size = new System.Drawing.Size(119, 23);
            this.SetFSize_button.TabIndex = 32;
            this.SetFSize_button.Text = "Set Size";
            this.SetFSize_button.UseVisualStyleBackColor = true;
            this.SetFSize_button.Click += new System.EventHandler(this.SetFSize_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(38, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Life Speed:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(39, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Resolution:";
            // 
            // nudResolution
            // 
            this.nudResolution.Location = new System.Drawing.Point(6, 32);
            this.nudResolution.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudResolution.Name = "nudResolution";
            this.nudResolution.Size = new System.Drawing.Size(119, 20);
            this.nudResolution.TabIndex = 31;
            this.nudResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudResolution.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudResolution.ValueChanged += new System.EventHandler(this.nudResolution_ValueChanged);
            // 
            // nudFieldRows
            // 
            this.nudFieldRows.Location = new System.Drawing.Point(54, 173);
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
            this.nudFieldRows.Size = new System.Drawing.Size(71, 20);
            this.nudFieldRows.TabIndex = 29;
            this.nudFieldRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFieldRows.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Width";
            // 
            // nudFieldCols
            // 
            this.nudFieldCols.Location = new System.Drawing.Point(54, 147);
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
            this.nudFieldCols.Size = new System.Drawing.Size(71, 20);
            this.nudFieldCols.TabIndex = 26;
            this.nudFieldCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFieldCols.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(44, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Field Size:";
            // 
            // clear_button
            // 
            this.clear_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clear_button.Location = new System.Drawing.Point(6, 237);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(119, 36);
            this.clear_button.TabIndex = 39;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // random_button
            // 
            this.random_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.random_button.Location = new System.Drawing.Point(6, 195);
            this.random_button.Name = "random_button";
            this.random_button.Size = new System.Drawing.Size(119, 36);
            this.random_button.TabIndex = 38;
            this.random_button.Text = "Randomize";
            this.random_button.UseVisualStyleBackColor = true;
            this.random_button.Click += new System.EventHandler(this.random_button_Click);
            // 
            // pause_button
            // 
            this.pause_button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pause_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pause_button.Location = new System.Drawing.Point(6, 100);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(119, 89);
            this.pause_button.TabIndex = 37;
            this.pause_button.Text = "Start";
            this.pause_button.UseVisualStyleBackColor = false;
            this.pause_button.Click += new System.EventHandler(this.pause_button_Click);
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_button.Location = new System.Drawing.Point(6, 58);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(119, 36);
            this.save_button.TabIndex = 36;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            // 
            // open_button
            // 
            this.open_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.open_button.Location = new System.Drawing.Point(6, 16);
            this.open_button.Name = "open_button";
            this.open_button.Size = new System.Drawing.Size(119, 36);
            this.open_button.TabIndex = 35;
            this.open_button.Text = "Open";
            this.open_button.UseVisualStyleBackColor = true;
            // 
            // screen
            // 
            this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screen.Location = new System.Drawing.Point(0, 0);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(800, 600);
            this.screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.screen.TabIndex = 0;
            this.screen.TabStop = false;
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 20;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // PrintTimer
            // 
            this.PrintTimer.Enabled = true;
            this.PrintTimer.Interval = 1;
            this.PrintTimer.Tick += new System.EventHandler(this.PrintTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 604);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ClientSizeChanged += new System.EventHandler(this.MainForm_ClientSizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLifeSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.NumericUpDown nudLifeSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SetFSize_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudResolution;
        private System.Windows.Forms.NumericUpDown nudFieldRows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudFieldCols;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button pause_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button open_button;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button random_button;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer PrintTimer;
        public System.Windows.Forms.PictureBox screen;
    }
}

