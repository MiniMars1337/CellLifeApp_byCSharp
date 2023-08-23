namespace CellLifeApp_0._4
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.screen = new System.Windows.Forms.PictureBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.renderTimer = new System.Windows.Forms.Timer(this.components);
            this.F3info = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMI_File = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_OpenField = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_OpenGenCode = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_SaveField = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_SaveGenCode = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приближениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отдалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.увеличитьСкоростьКамерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уменьшитьСкоростьКамерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ускоритьСимуляциюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.замедлитьСимуляциюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseLabel = new System.Windows.Forms.Label();
            this.panel_CellConstants = new System.Windows.Forms.Panel();
            this.checkBox_IsMutationEnabled = new System.Windows.Forms.CheckBox();
            this.label_IsMutationEnabled = new System.Windows.Forms.Label();
            this.label_MutationChance = new System.Windows.Forms.Label();
            this.nud_MutationChance = new System.Windows.Forms.NumericUpDown();
            this.label_OrganicEating = new System.Windows.Forms.Label();
            this.nud_OrganicEating = new System.Windows.Forms.NumericUpDown();
            this.label_CellEatingCoefficient = new System.Windows.Forms.Label();
            this.nud_CellEatingCoefficient = new System.Windows.Forms.NumericUpDown();
            this.label_MaxGenCodeValue = new System.Windows.Forms.Label();
            this.nud_MaxGenCodeValue = new System.Windows.Forms.NumericUpDown();
            this.label_OrganicExtraction = new System.Windows.Forms.Label();
            this.nud_OrganicExtraction = new System.Windows.Forms.NumericUpDown();
            this.label_ChargeExtraction = new System.Windows.Forms.Label();
            this.nud_ChargeExtraction = new System.Windows.Forms.NumericUpDown();
            this.label_EnergyDecreasement = new System.Windows.Forms.Label();
            this.nud_EnergyDecreasement = new System.Windows.Forms.NumericUpDown();
            this.label_MaxEnergyCapacity = new System.Windows.Forms.Label();
            this.nud_MaxEnergyCapacity = new System.Windows.Forms.NumericUpDown();
            this.button_CancelChangeParameters = new System.Windows.Forms.Button();
            this.button_SetNewParameters = new System.Windows.Forms.Button();
            this.label_ChargeIncrease = new System.Windows.Forms.Label();
            this.nud_ChargeIncrease = new System.Windows.Forms.NumericUpDown();
            this.label_OrganicIncrease = new System.Windows.Forms.Label();
            this.nud_OrganicIncrease = new System.Windows.Forms.NumericUpDown();
            this.label_ChargeRecoverySpeed = new System.Windows.Forms.Label();
            this.label_AverageCharge = new System.Windows.Forms.Label();
            this.label_ToxicLevel = new System.Windows.Forms.Label();
            this.nud_ChargeRecoverySpeed = new System.Windows.Forms.NumericUpDown();
            this.nud_AverageCharge = new System.Windows.Forms.NumericUpDown();
            this.nud_ToxicLevel = new System.Windows.Forms.NumericUpDown();
            this.nud_MaxSunLevel = new System.Windows.Forms.NumericUpDown();
            this.label_MaxSunLevel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.панельОбщихНастроекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_CellParamPanel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel_CellConstants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OrganicEating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CellEatingCoefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxGenCodeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OrganicExtraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ChargeExtraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_EnergyDecreasement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxEnergyCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ChargeIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OrganicIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ChargeRecoverySpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_AverageCharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ToxicLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxSunLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // screen
            // 
            this.screen.BackColor = System.Drawing.Color.Silver;
            this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screen.Location = new System.Drawing.Point(0, 24);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(800, 600);
            this.screen.TabIndex = 0;
            this.screen.TabStop = false;
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // renderTimer
            // 
            this.renderTimer.Enabled = true;
            this.renderTimer.Interval = 1;
            this.renderTimer.Tick += new System.EventHandler(this.renderTimer_Tick);
            // 
            // F3info
            // 
            this.F3info.AutoSize = true;
            this.F3info.BackColor = System.Drawing.Color.Transparent;
            this.F3info.Location = new System.Drawing.Point(-1, -1);
            this.F3info.Name = "F3info";
            this.F3info.Size = new System.Drawing.Size(19, 13);
            this.F3info.TabIndex = 1;
            this.F3info.Text = "F3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_File,
            this.видToolStripMenuItem,
            this.инструментыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMI_File
            // 
            this.TSMI_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Open,
            this.TSMI_Save});
            this.TSMI_File.Name = "TSMI_File";
            this.TSMI_File.Size = new System.Drawing.Size(48, 20);
            this.TSMI_File.Text = "Файл";
            // 
            // TSMI_Open
            // 
            this.TSMI_Open.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_OpenField,
            this.TSMI_OpenGenCode});
            this.TSMI_Open.Name = "TSMI_Open";
            this.TSMI_Open.Size = new System.Drawing.Size(180, 22);
            this.TSMI_Open.Text = "Открыть";
            // 
            // TSMI_OpenField
            // 
            this.TSMI_OpenField.Name = "TSMI_OpenField";
            this.TSMI_OpenField.Size = new System.Drawing.Size(180, 22);
            this.TSMI_OpenField.Text = "Поле";
            // 
            // TSMI_OpenGenCode
            // 
            this.TSMI_OpenGenCode.Name = "TSMI_OpenGenCode";
            this.TSMI_OpenGenCode.Size = new System.Drawing.Size(180, 22);
            this.TSMI_OpenGenCode.Text = "Генетический код";
            // 
            // TSMI_Save
            // 
            this.TSMI_Save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_SaveField,
            this.TSMI_SaveGenCode});
            this.TSMI_Save.Name = "TSMI_Save";
            this.TSMI_Save.Size = new System.Drawing.Size(180, 22);
            this.TSMI_Save.Text = "Сохранить";
            // 
            // TSMI_SaveField
            // 
            this.TSMI_SaveField.Name = "TSMI_SaveField";
            this.TSMI_SaveField.Size = new System.Drawing.Size(172, 22);
            this.TSMI_SaveField.Text = "Поле";
            // 
            // TSMI_SaveGenCode
            // 
            this.TSMI_SaveGenCode.Name = "TSMI_SaveGenCode";
            this.TSMI_SaveGenCode.Size = new System.Drawing.Size(172, 22);
            this.TSMI_SaveGenCode.Text = "Генетический код";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.приближениеToolStripMenuItem,
            this.отдалениеToolStripMenuItem,
            this.увеличитьСкоростьКамерыToolStripMenuItem,
            this.уменьшитьСкоростьКамерыToolStripMenuItem,
            this.ускоритьСимуляциюToolStripMenuItem,
            this.замедлитьСимуляциюToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // приближениеToolStripMenuItem
            // 
            this.приближениеToolStripMenuItem.Name = "приближениеToolStripMenuItem";
            this.приближениеToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.приближениеToolStripMenuItem.Text = "Приближение";
            // 
            // отдалениеToolStripMenuItem
            // 
            this.отдалениеToolStripMenuItem.Name = "отдалениеToolStripMenuItem";
            this.отдалениеToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.отдалениеToolStripMenuItem.Text = "Отдаление";
            // 
            // увеличитьСкоростьКамерыToolStripMenuItem
            // 
            this.увеличитьСкоростьКамерыToolStripMenuItem.Name = "увеличитьСкоростьКамерыToolStripMenuItem";
            this.увеличитьСкоростьКамерыToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.увеличитьСкоростьКамерыToolStripMenuItem.Text = "Увеличить скорость камеры";
            // 
            // уменьшитьСкоростьКамерыToolStripMenuItem
            // 
            this.уменьшитьСкоростьКамерыToolStripMenuItem.Name = "уменьшитьСкоростьКамерыToolStripMenuItem";
            this.уменьшитьСкоростьКамерыToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.уменьшитьСкоростьКамерыToolStripMenuItem.Text = "Уменьшить скорость камеры";
            // 
            // ускоритьСимуляциюToolStripMenuItem
            // 
            this.ускоритьСимуляциюToolStripMenuItem.Name = "ускоритьСимуляциюToolStripMenuItem";
            this.ускоритьСимуляциюToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.ускоритьСимуляциюToolStripMenuItem.Text = "Ускорить симуляцию";
            // 
            // замедлитьСимуляциюToolStripMenuItem
            // 
            this.замедлитьСимуляциюToolStripMenuItem.Name = "замедлитьСимуляциюToolStripMenuItem";
            this.замедлитьСимуляциюToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.замедлитьСимуляциюToolStripMenuItem.Text = "Замедлить симуляцию";
            // 
            // pauseLabel
            // 
            this.pauseLabel.AutoSize = true;
            this.pauseLabel.BackColor = System.Drawing.Color.Transparent;
            this.pauseLabel.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pauseLabel.Location = new System.Drawing.Point(729, -1);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(69, 25);
            this.pauseLabel.TabIndex = 3;
            this.pauseLabel.Text = "Pause";
            // 
            // panel_CellConstants
            // 
            this.panel_CellConstants.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel_CellConstants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_CellConstants.Controls.Add(this.checkBox_IsMutationEnabled);
            this.panel_CellConstants.Controls.Add(this.label_IsMutationEnabled);
            this.panel_CellConstants.Controls.Add(this.label_MutationChance);
            this.panel_CellConstants.Controls.Add(this.nud_MutationChance);
            this.panel_CellConstants.Controls.Add(this.label_OrganicEating);
            this.panel_CellConstants.Controls.Add(this.nud_OrganicEating);
            this.panel_CellConstants.Controls.Add(this.label_CellEatingCoefficient);
            this.panel_CellConstants.Controls.Add(this.nud_CellEatingCoefficient);
            this.panel_CellConstants.Controls.Add(this.label_MaxGenCodeValue);
            this.panel_CellConstants.Controls.Add(this.nud_MaxGenCodeValue);
            this.panel_CellConstants.Controls.Add(this.label_OrganicExtraction);
            this.panel_CellConstants.Controls.Add(this.nud_OrganicExtraction);
            this.panel_CellConstants.Controls.Add(this.label_ChargeExtraction);
            this.panel_CellConstants.Controls.Add(this.nud_ChargeExtraction);
            this.panel_CellConstants.Controls.Add(this.label_EnergyDecreasement);
            this.panel_CellConstants.Controls.Add(this.nud_EnergyDecreasement);
            this.panel_CellConstants.Controls.Add(this.label_MaxEnergyCapacity);
            this.panel_CellConstants.Controls.Add(this.nud_MaxEnergyCapacity);
            this.panel_CellConstants.Controls.Add(this.button_CancelChangeParameters);
            this.panel_CellConstants.Controls.Add(this.button_SetNewParameters);
            this.panel_CellConstants.Controls.Add(this.label_ChargeIncrease);
            this.panel_CellConstants.Controls.Add(this.nud_ChargeIncrease);
            this.panel_CellConstants.Controls.Add(this.label_OrganicIncrease);
            this.panel_CellConstants.Controls.Add(this.nud_OrganicIncrease);
            this.panel_CellConstants.Controls.Add(this.label_ChargeRecoverySpeed);
            this.panel_CellConstants.Controls.Add(this.label_AverageCharge);
            this.panel_CellConstants.Controls.Add(this.label_ToxicLevel);
            this.panel_CellConstants.Controls.Add(this.nud_ChargeRecoverySpeed);
            this.panel_CellConstants.Controls.Add(this.nud_AverageCharge);
            this.panel_CellConstants.Controls.Add(this.nud_ToxicLevel);
            this.panel_CellConstants.Controls.Add(this.nud_MaxSunLevel);
            this.panel_CellConstants.Controls.Add(this.label_MaxSunLevel);
            this.panel_CellConstants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_CellConstants.Location = new System.Drawing.Point(12, 37);
            this.panel_CellConstants.Name = "panel_CellConstants";
            this.panel_CellConstants.Size = new System.Drawing.Size(270, 459);
            this.panel_CellConstants.TabIndex = 4;
            this.panel_CellConstants.Visible = false;
            this.panel_CellConstants.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.panel_CellConstants_PreviewKeyDown);
            // 
            // checkBox_IsMutationEnabled
            // 
            this.checkBox_IsMutationEnabled.AutoSize = true;
            this.checkBox_IsMutationEnabled.Checked = true;
            this.checkBox_IsMutationEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_IsMutationEnabled.Location = new System.Drawing.Point(247, 373);
            this.checkBox_IsMutationEnabled.Name = "checkBox_IsMutationEnabled";
            this.checkBox_IsMutationEnabled.Size = new System.Drawing.Size(15, 14);
            this.checkBox_IsMutationEnabled.TabIndex = 32;
            this.checkBox_IsMutationEnabled.UseVisualStyleBackColor = true;
            // 
            // label_IsMutationEnabled
            // 
            this.label_IsMutationEnabled.AutoSize = true;
            this.label_IsMutationEnabled.Location = new System.Drawing.Point(3, 373);
            this.label_IsMutationEnabled.Name = "label_IsMutationEnabled";
            this.label_IsMutationEnabled.Size = new System.Drawing.Size(92, 13);
            this.label_IsMutationEnabled.TabIndex = 31;
            this.label_IsMutationEnabled.Text = "Mutation enabled:";
            // 
            // label_MutationChance
            // 
            this.label_MutationChance.AutoSize = true;
            this.label_MutationChance.Location = new System.Drawing.Point(3, 347);
            this.label_MutationChance.Name = "label_MutationChance";
            this.label_MutationChance.Size = new System.Drawing.Size(90, 13);
            this.label_MutationChance.TabIndex = 29;
            this.label_MutationChance.Text = "Mutation chance:";
            // 
            // nud_MutationChance
            // 
            this.nud_MutationChance.DecimalPlaces = 6;
            this.nud_MutationChance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_MutationChance.Location = new System.Drawing.Point(179, 345);
            this.nud_MutationChance.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_MutationChance.Name = "nud_MutationChance";
            this.nud_MutationChance.Size = new System.Drawing.Size(83, 20);
            this.nud_MutationChance.TabIndex = 28;
            // 
            // label_OrganicEating
            // 
            this.label_OrganicEating.AutoSize = true;
            this.label_OrganicEating.Location = new System.Drawing.Point(3, 321);
            this.label_OrganicEating.Name = "label_OrganicEating";
            this.label_OrganicEating.Size = new System.Drawing.Size(79, 13);
            this.label_OrganicEating.TabIndex = 27;
            this.label_OrganicEating.Text = "Organic eating:";
            // 
            // nud_OrganicEating
            // 
            this.nud_OrganicEating.Location = new System.Drawing.Point(179, 319);
            this.nud_OrganicEating.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_OrganicEating.Name = "nud_OrganicEating";
            this.nud_OrganicEating.Size = new System.Drawing.Size(83, 20);
            this.nud_OrganicEating.TabIndex = 26;
            // 
            // label_CellEatingCoefficient
            // 
            this.label_CellEatingCoefficient.AutoSize = true;
            this.label_CellEatingCoefficient.Location = new System.Drawing.Point(3, 295);
            this.label_CellEatingCoefficient.Name = "label_CellEatingCoefficient";
            this.label_CellEatingCoefficient.Size = new System.Drawing.Size(111, 13);
            this.label_CellEatingCoefficient.TabIndex = 25;
            this.label_CellEatingCoefficient.Text = "Cell eating coefficient:";
            // 
            // nud_CellEatingCoefficient
            // 
            this.nud_CellEatingCoefficient.DecimalPlaces = 4;
            this.nud_CellEatingCoefficient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_CellEatingCoefficient.Location = new System.Drawing.Point(179, 293);
            this.nud_CellEatingCoefficient.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_CellEatingCoefficient.Name = "nud_CellEatingCoefficient";
            this.nud_CellEatingCoefficient.Size = new System.Drawing.Size(83, 20);
            this.nud_CellEatingCoefficient.TabIndex = 24;
            // 
            // label_MaxGenCodeValue
            // 
            this.label_MaxGenCodeValue.AutoSize = true;
            this.label_MaxGenCodeValue.Location = new System.Drawing.Point(3, 269);
            this.label_MaxGenCodeValue.Name = "label_MaxGenCodeValue";
            this.label_MaxGenCodeValue.Size = new System.Drawing.Size(148, 13);
            this.label_MaxGenCodeValue.TabIndex = 23;
            this.label_MaxGenCodeValue.Text = "Maximum genetic code value:";
            // 
            // nud_MaxGenCodeValue
            // 
            this.nud_MaxGenCodeValue.Location = new System.Drawing.Point(179, 267);
            this.nud_MaxGenCodeValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_MaxGenCodeValue.Name = "nud_MaxGenCodeValue";
            this.nud_MaxGenCodeValue.Size = new System.Drawing.Size(83, 20);
            this.nud_MaxGenCodeValue.TabIndex = 22;
            // 
            // label_OrganicExtraction
            // 
            this.label_OrganicExtraction.AutoSize = true;
            this.label_OrganicExtraction.Location = new System.Drawing.Point(3, 243);
            this.label_OrganicExtraction.Name = "label_OrganicExtraction";
            this.label_OrganicExtraction.Size = new System.Drawing.Size(96, 13);
            this.label_OrganicExtraction.TabIndex = 21;
            this.label_OrganicExtraction.Text = "Organic extraction:";
            // 
            // nud_OrganicExtraction
            // 
            this.nud_OrganicExtraction.Location = new System.Drawing.Point(179, 241);
            this.nud_OrganicExtraction.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_OrganicExtraction.Name = "nud_OrganicExtraction";
            this.nud_OrganicExtraction.Size = new System.Drawing.Size(83, 20);
            this.nud_OrganicExtraction.TabIndex = 20;
            // 
            // label_ChargeExtraction
            // 
            this.label_ChargeExtraction.AutoSize = true;
            this.label_ChargeExtraction.Location = new System.Drawing.Point(3, 217);
            this.label_ChargeExtraction.Name = "label_ChargeExtraction";
            this.label_ChargeExtraction.Size = new System.Drawing.Size(93, 13);
            this.label_ChargeExtraction.TabIndex = 19;
            this.label_ChargeExtraction.Text = "Charge extraction:";
            // 
            // nud_ChargeExtraction
            // 
            this.nud_ChargeExtraction.Location = new System.Drawing.Point(179, 215);
            this.nud_ChargeExtraction.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_ChargeExtraction.Name = "nud_ChargeExtraction";
            this.nud_ChargeExtraction.Size = new System.Drawing.Size(83, 20);
            this.nud_ChargeExtraction.TabIndex = 18;
            // 
            // label_EnergyDecreasement
            // 
            this.label_EnergyDecreasement.AutoSize = true;
            this.label_EnergyDecreasement.Location = new System.Drawing.Point(3, 191);
            this.label_EnergyDecreasement.Name = "label_EnergyDecreasement";
            this.label_EnergyDecreasement.Size = new System.Drawing.Size(113, 13);
            this.label_EnergyDecreasement.TabIndex = 17;
            this.label_EnergyDecreasement.Text = "Energy decreasement:";
            // 
            // nud_EnergyDecreasement
            // 
            this.nud_EnergyDecreasement.Location = new System.Drawing.Point(179, 189);
            this.nud_EnergyDecreasement.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_EnergyDecreasement.Name = "nud_EnergyDecreasement";
            this.nud_EnergyDecreasement.Size = new System.Drawing.Size(83, 20);
            this.nud_EnergyDecreasement.TabIndex = 16;
            // 
            // label_MaxEnergyCapacity
            // 
            this.label_MaxEnergyCapacity.AutoSize = true;
            this.label_MaxEnergyCapacity.Location = new System.Drawing.Point(3, 165);
            this.label_MaxEnergyCapacity.Name = "label_MaxEnergyCapacity";
            this.label_MaxEnergyCapacity.Size = new System.Drawing.Size(132, 13);
            this.label_MaxEnergyCapacity.TabIndex = 15;
            this.label_MaxEnergyCapacity.Text = "Maximum energy capacity:";
            // 
            // nud_MaxEnergyCapacity
            // 
            this.nud_MaxEnergyCapacity.Location = new System.Drawing.Point(179, 163);
            this.nud_MaxEnergyCapacity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_MaxEnergyCapacity.Name = "nud_MaxEnergyCapacity";
            this.nud_MaxEnergyCapacity.Size = new System.Drawing.Size(83, 20);
            this.nud_MaxEnergyCapacity.TabIndex = 14;
            // 
            // button_CancelChangeParameters
            // 
            this.button_CancelChangeParameters.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_CancelChangeParameters.Location = new System.Drawing.Point(179, 429);
            this.button_CancelChangeParameters.Name = "button_CancelChangeParameters";
            this.button_CancelChangeParameters.Size = new System.Drawing.Size(75, 23);
            this.button_CancelChangeParameters.TabIndex = 13;
            this.button_CancelChangeParameters.Text = "Cancel";
            this.button_CancelChangeParameters.UseVisualStyleBackColor = true;
            // 
            // button_SetNewParameters
            // 
            this.button_SetNewParameters.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_SetNewParameters.Location = new System.Drawing.Point(98, 429);
            this.button_SetNewParameters.Name = "button_SetNewParameters";
            this.button_SetNewParameters.Size = new System.Drawing.Size(75, 23);
            this.button_SetNewParameters.TabIndex = 12;
            this.button_SetNewParameters.Text = "OK";
            this.button_SetNewParameters.UseVisualStyleBackColor = true;
            // 
            // label_ChargeIncrease
            // 
            this.label_ChargeIncrease.AutoSize = true;
            this.label_ChargeIncrease.Location = new System.Drawing.Point(3, 139);
            this.label_ChargeIncrease.Name = "label_ChargeIncrease";
            this.label_ChargeIncrease.Size = new System.Drawing.Size(87, 13);
            this.label_ChargeIncrease.TabIndex = 11;
            this.label_ChargeIncrease.Text = "Charge increase:";
            // 
            // nud_ChargeIncrease
            // 
            this.nud_ChargeIncrease.Location = new System.Drawing.Point(179, 137);
            this.nud_ChargeIncrease.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_ChargeIncrease.Name = "nud_ChargeIncrease";
            this.nud_ChargeIncrease.Size = new System.Drawing.Size(83, 20);
            this.nud_ChargeIncrease.TabIndex = 10;
            // 
            // label_OrganicIncrease
            // 
            this.label_OrganicIncrease.AutoSize = true;
            this.label_OrganicIncrease.Location = new System.Drawing.Point(3, 113);
            this.label_OrganicIncrease.Name = "label_OrganicIncrease";
            this.label_OrganicIncrease.Size = new System.Drawing.Size(90, 13);
            this.label_OrganicIncrease.TabIndex = 9;
            this.label_OrganicIncrease.Text = "Organic increase:";
            // 
            // nud_OrganicIncrease
            // 
            this.nud_OrganicIncrease.Location = new System.Drawing.Point(179, 111);
            this.nud_OrganicIncrease.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_OrganicIncrease.Name = "nud_OrganicIncrease";
            this.nud_OrganicIncrease.Size = new System.Drawing.Size(83, 20);
            this.nud_OrganicIncrease.TabIndex = 8;
            // 
            // label_ChargeRecoverySpeed
            // 
            this.label_ChargeRecoverySpeed.AutoSize = true;
            this.label_ChargeRecoverySpeed.Location = new System.Drawing.Point(3, 87);
            this.label_ChargeRecoverySpeed.Name = "label_ChargeRecoverySpeed";
            this.label_ChargeRecoverySpeed.Size = new System.Drawing.Size(120, 13);
            this.label_ChargeRecoverySpeed.TabIndex = 7;
            this.label_ChargeRecoverySpeed.Text = "Charge recovery speed:";
            // 
            // label_AverageCharge
            // 
            this.label_AverageCharge.AutoSize = true;
            this.label_AverageCharge.Location = new System.Drawing.Point(3, 61);
            this.label_AverageCharge.Name = "label_AverageCharge";
            this.label_AverageCharge.Size = new System.Drawing.Size(86, 13);
            this.label_AverageCharge.TabIndex = 6;
            this.label_AverageCharge.Text = "Average charge:";
            // 
            // label_ToxicLevel
            // 
            this.label_ToxicLevel.AutoSize = true;
            this.label_ToxicLevel.Location = new System.Drawing.Point(3, 35);
            this.label_ToxicLevel.Name = "label_ToxicLevel";
            this.label_ToxicLevel.Size = new System.Drawing.Size(61, 13);
            this.label_ToxicLevel.TabIndex = 5;
            this.label_ToxicLevel.Text = "Toxic level:";
            // 
            // nud_ChargeRecoverySpeed
            // 
            this.nud_ChargeRecoverySpeed.Location = new System.Drawing.Point(179, 85);
            this.nud_ChargeRecoverySpeed.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_ChargeRecoverySpeed.Name = "nud_ChargeRecoverySpeed";
            this.nud_ChargeRecoverySpeed.Size = new System.Drawing.Size(83, 20);
            this.nud_ChargeRecoverySpeed.TabIndex = 4;
            // 
            // nud_AverageCharge
            // 
            this.nud_AverageCharge.Location = new System.Drawing.Point(179, 59);
            this.nud_AverageCharge.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_AverageCharge.Name = "nud_AverageCharge";
            this.nud_AverageCharge.Size = new System.Drawing.Size(83, 20);
            this.nud_AverageCharge.TabIndex = 3;
            // 
            // nud_ToxicLevel
            // 
            this.nud_ToxicLevel.Location = new System.Drawing.Point(179, 33);
            this.nud_ToxicLevel.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_ToxicLevel.Name = "nud_ToxicLevel";
            this.nud_ToxicLevel.Size = new System.Drawing.Size(83, 20);
            this.nud_ToxicLevel.TabIndex = 2;
            // 
            // nud_MaxSunLevel
            // 
            this.nud_MaxSunLevel.Location = new System.Drawing.Point(179, 7);
            this.nud_MaxSunLevel.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_MaxSunLevel.Name = "nud_MaxSunLevel";
            this.nud_MaxSunLevel.Size = new System.Drawing.Size(83, 20);
            this.nud_MaxSunLevel.TabIndex = 1;
            // 
            // label_MaxSunLevel
            // 
            this.label_MaxSunLevel.AutoSize = true;
            this.label_MaxSunLevel.Location = new System.Drawing.Point(3, 9);
            this.label_MaxSunLevel.Name = "label_MaxSunLevel";
            this.label_MaxSunLevel.Size = new System.Drawing.Size(99, 13);
            this.label_MaxSunLevel.TabIndex = 0;
            this.label_MaxSunLevel.Text = "Maximum sun level:";
            // 
            // инструментыToolStripMenuItem
            // 
            this.инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.панельОбщихНастроекToolStripMenuItem,
            this.TSMI_CellParamPanel});
            this.инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            this.инструментыToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.инструментыToolStripMenuItem.Text = "Инструменты";
            // 
            // панельОбщихНастроекToolStripMenuItem
            // 
            this.панельОбщихНастроекToolStripMenuItem.Name = "панельОбщихНастроекToolStripMenuItem";
            this.панельОбщихНастроекToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.панельОбщихНастроекToolStripMenuItem.Text = "Панель общих настроек";
            // 
            // TSMI_CellParamPanel
            // 
            this.TSMI_CellParamPanel.Name = "TSMI_CellParamPanel";
            this.TSMI_CellParamPanel.Size = new System.Drawing.Size(208, 22);
            this.TSMI_CellParamPanel.Text = "Панель настроек поля";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 624);
            this.Controls.Add(this.panel_CellConstants);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.F3info);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "CellLifeApp 0.4";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainWindow_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_CellConstants.ResumeLayout(false);
            this.panel_CellConstants.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MutationChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OrganicEating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CellEatingCoefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxGenCodeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OrganicExtraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ChargeExtraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_EnergyDecreasement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxEnergyCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ChargeIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OrganicIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ChargeRecoverySpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_AverageCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ToxicLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxSunLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox screen;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer renderTimer;
        private System.Windows.Forms.Label F3info;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMI_File;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Open;
        private System.Windows.Forms.ToolStripMenuItem TSMI_OpenField;
        private System.Windows.Forms.ToolStripMenuItem TSMI_OpenGenCode;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Save;
        private System.Windows.Forms.ToolStripMenuItem TSMI_SaveField;
        private System.Windows.Forms.ToolStripMenuItem TSMI_SaveGenCode;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приближениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отдалениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem увеличитьСкоростьКамерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уменьшитьСкоростьКамерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ускоритьСимуляциюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem замедлитьСимуляциюToolStripMenuItem;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Panel panel_CellConstants;
        private System.Windows.Forms.Label label_MaxSunLevel;
        private System.Windows.Forms.NumericUpDown nud_ChargeRecoverySpeed;
        private System.Windows.Forms.NumericUpDown nud_AverageCharge;
        private System.Windows.Forms.NumericUpDown nud_ToxicLevel;
        private System.Windows.Forms.NumericUpDown nud_MaxSunLevel;
        private System.Windows.Forms.Label label_OrganicIncrease;
        private System.Windows.Forms.NumericUpDown nud_OrganicIncrease;
        private System.Windows.Forms.Label label_ChargeRecoverySpeed;
        private System.Windows.Forms.Label label_AverageCharge;
        private System.Windows.Forms.Label label_ToxicLevel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label_ChargeIncrease;
        private System.Windows.Forms.NumericUpDown nud_ChargeIncrease;
        private System.Windows.Forms.Button button_CancelChangeParameters;
        private System.Windows.Forms.Button button_SetNewParameters;
        private System.Windows.Forms.Label label_MaxEnergyCapacity;
        private System.Windows.Forms.NumericUpDown nud_MaxEnergyCapacity;
        private System.Windows.Forms.Label label_EnergyDecreasement;
        private System.Windows.Forms.NumericUpDown nud_EnergyDecreasement;
        private System.Windows.Forms.Label label_ChargeExtraction;
        private System.Windows.Forms.NumericUpDown nud_ChargeExtraction;
        private System.Windows.Forms.Label label_OrganicExtraction;
        private System.Windows.Forms.NumericUpDown nud_OrganicExtraction;
        private System.Windows.Forms.Label label_MaxGenCodeValue;
        private System.Windows.Forms.NumericUpDown nud_MaxGenCodeValue;
        private System.Windows.Forms.Label label_CellEatingCoefficient;
        private System.Windows.Forms.NumericUpDown nud_CellEatingCoefficient;
        private System.Windows.Forms.Label label_MutationChance;
        private System.Windows.Forms.NumericUpDown nud_MutationChance;
        private System.Windows.Forms.Label label_OrganicEating;
        private System.Windows.Forms.NumericUpDown nud_OrganicEating;
        private System.Windows.Forms.CheckBox checkBox_IsMutationEnabled;
        private System.Windows.Forms.Label label_IsMutationEnabled;
        private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem панельОбщихНастроекToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_CellParamPanel;
    }
}

