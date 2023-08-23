using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using CellLifeApp.FieldClasses;
using CellLifeApp.PrintingClasses;
using CellLifeApp;

namespace CellLifeApp_0._4
{
    public partial class MainWindow : Form
    {
        private Dictionary<object, string> toolTipMessages;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private BinaryFormatter bf;
        private FileStream fs;
        private Stopwatch sw;
        private FieldPrinter printer;
        private int resolution;
        private int fps, fpsCounter;
        private double framesTime;
        private double saveTimeCount;

        private string lastfieldSave;
        private int autosaveTime;
        private int maxAutosaves;
        private int autosaveCounter;
        private int resolutionLevel;
        private int lifeSpeed;
        private float camX, camY;
        private int camSpeed;
        private string camMode;
        private CellParameters parameters;
        private Field field;

        public MainWindow()
        {
            bf = new BinaryFormatter();
            InitializeComponent();
            pauseLabel.Parent = screen;
            F3info.Parent = screen;
            LoadToolTipMessages();
            if (LoadLastExit() == false)
            {
                maxAutosaves = 10;
                autosaveCounter = 1;
                autosaveTime = 600;
                resolutionLevel = 5;
                lifeSpeed = 1;
                camX = 0.5f;
                camY = 0.5f;
                camSpeed = 10;
                camMode = "Default";
                parameters = new CellParameters();
                parameters.UpdateData();
                field = new Field(parameters);
                printer = new FieldPrinter(field, screen, resolutionLevel, camSpeed, camMode);
            }
            printer.SetCameraPosition(camX, camY);
            printer.CamSpeed = camSpeed;
            resolution = (int)Math.Pow(2, resolutionLevel);
            sw = new Stopwatch();

            FormClosing += (s, e) => Exit();
            ResizeEnd += (s, e) => printer.ScreenSizeChanged();
            TSMI_SaveField.Click += (s, e) => SaveField();
            TSMI_OpenField.Click += (s, e) => OpenField();
            TSMI_CellParamPanel.Click += (s, e) => ShowCellParamPanel();
            button_CancelChangeParameters.Click += (s, e) => HideCellParamPanel();
            button_SetNewParameters.Click += (s, e) => { 
                SetNewCellParameters();
                HideCellParamPanel(); 
            };

            sw.Start();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            field.UpdateField();
        }

        private void MainWindow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var time = (float)sw.Elapsed.TotalSeconds;
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.Space:
                    StopSimulation();
                    break;
                case Keys.A:
                    printer.CamMove(Direct.Left, time);
                    break;
                case Keys.W:
                    printer.CamMove(Direct.Up, time);
                    break;
                case Keys.D:
                    printer.CamMove(Direct.Right, time);
                    break;
                case Keys.S:
                    printer.CamMove(Direct.Down, time);
                    break;
                case Keys.Z:
                    printer.ChangeViewMode();
                    break;
                case Keys.T:
                    field.TestPattern();
                    break;
                case Keys.Oemplus:
                    ChangeResolution(true);
                    break;
                case Keys.OemMinus:
                    ChangeResolution(false);
                    break;
                case Keys.Oemcomma:
                    ChangeLifeSpeed(lifeSpeed - 1);
                    break;
                case Keys.OemPeriod:
                    ChangeLifeSpeed(lifeSpeed + 1);
                    break;
                case Keys.ShiftKey:
                    printer.CamSpeed += 1;
                    break;
                case Keys.ControlKey:
                    printer.CamSpeed -= 1;
                    if (printer.CamSpeed < 1)
                        printer.CamSpeed = 1;
                    break;
                case Keys.F3:
                    if (F3info.Visible)
                        F3info.Visible = false;
                    else
                        F3info.Visible = true;
                    break;
                case Keys.F5:
                    AutoSave();
                    break;
                case Keys.F7:
                    LoadLastSave();
                    break;
                default:
                    break;
            }
        }
        private void panel_CellConstants_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                HideCellParamPanel();
        }

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            framesTime += sw.Elapsed.TotalSeconds;
            saveTimeCount += sw.Elapsed.TotalSeconds;
            sw.Restart();
            if (framesTime >= 1)
            {
                fps = fpsCounter;
                fpsCounter = 0;
                framesTime = 0;
            }
            fpsCounter++;

            if (saveTimeCount > autosaveTime)
            {
                saveTimeCount = 0;
                AutoSave();
            }

            var cell = field[(int)printer.CameraPosition.X, (int)printer.CameraPosition.Y];
            var energy = cell is LifeCell ? ((LifeCell)cell).Energy.ToString() : "Nan";
            var contacts = cell is IHaveContacts ? ((IHaveContacts)cell).Contacts.Count.ToString() : "Nan";
            var Organic = cell != null ? cell.Organic.ToString() : "Nan";
            var Charge = cell != null ? cell.Charge.ToString() : "Nan";
            var SunLevel = cell != null ? cell.SunLevel.ToString() : "Nan";
            var Type = cell != null ? cell.GetType().Name : "Nan";

            F3info.Text = 
                $"FPS - {fps}\n" +
                $"View mode - {printer.CamMode}\n" +
                $"Camera position - {printer.CameraPosition.X}, {printer.CameraPosition.Y}\n" +
                $"Camera speed - {printer.CamSpeed}\n" +
                $"Cell resolution - {resolution}\n" +
                $"Simulation speed - {lifeSpeed} updates/sec\n" +
                $"Generation - {field.Generation}\n" +
                $"Number of GeneticCells - {field.GeneticCellCount}\n" +
                $"All mutations - {GeneticCell.AllMutations}\n" +
                $"\n" +
                $"Selected Cell parameters:\n" +
                $"Organic - {Organic}, Charge - {Charge}, Sun level - {SunLevel}\n" +
                $"Type - {Type}, Contacts - {contacts}\n" +
                $"Energy - {energy}\n" +
                $"\n" +
                $"Field Parameters:\n" +
                $"Width - {field.Cols}, Height - {field.Rows}\n" +
                $"Organic increase - {parameters.OrganicIncrease}, Charge increase - {parameters.ChargeIncrease}\n" +
                $"Max energy capacity - {parameters.MaxEnergyCapacity}, Energy decreasement - {parameters.EnergyDecreasement}\n" +
                $"Max sun level - {parameters.MaxSunLevel}, Toxic level - {parameters.ToxicLevel}\n" +
                $"Average charge - {parameters.AverageCharge}, Charge recovery speed - {parameters.ChargeRecoverySpeed}";

            printer.PrintField();

        }

        private void StopSimulation()
        {
            if (updateTimer.Enabled)
            {
                updateTimer.Stop();
                pauseLabel.Visible = true;
            }
            else
            {
                updateTimer.Start();
                pauseLabel.Visible = false;
            }
        }
        private void LoadToolTipMessages()
        {
            label_MaxSunLevel.MouseHover += (s, e) => ShowToolTipMessage(s);
            label_ToxicLevel.MouseHover += (s, e) => ShowToolTipMessage(s);
            label_AverageCharge.MouseHover += (s, e) => ShowToolTipMessage(s);
            label_ChargeRecoverySpeed.MouseHover += (s, e) => ShowToolTipMessage(s);
            label_OrganicIncrease.MouseHover += (s, e) => ShowToolTipMessage(s);
            label_ChargeIncrease.MouseHover += (s, e) => ShowToolTipMessage(s);

            toolTipMessages = new Dictionary<object, string>
            {
                [label_MaxSunLevel] = 
                "Максимальный уровень солнца",
                [label_ToxicLevel] = 
                "Максимальный уровень загрязнения,\n" +
                "уровень при котором клетки не выживают\n" +
                "(могут выжить только клетки корня и антенны)",
                [label_AverageCharge] = 
                "Средний уровень заряда\n" +
                "(заряд в клетке постепенно восстанавливается до этого уровня)",
                [label_ChargeRecoverySpeed] = 
                "Скорость восстановления заряда",
                [label_OrganicIncrease] =
                "Повышение органики в соседних клетках на заданное значение\n" +
                "(при смерти живой клетки)",
                [label_ChargeIncrease] =
                "Повышение заряда в соседних клетках на заданное значение\n" +
                "(при смерти живой клетки)",
            };
        }
        private void ShowToolTipMessage(object s)
        {
            toolTip.SetToolTip((Control)s, toolTipMessages[s]);
        }
        private void ShowCellParamPanel()
        {
            ResetNUDValues();
            panel_CellConstants.Visible = true;
            panel_CellConstants.Enabled = true;
            panel_CellConstants.Focus();
        }
        private void HideCellParamPanel()
        {
            panel_CellConstants.Visible = false;
            panel_CellConstants.Enabled = false;
            Focus();
        }
        private void ResetNUDValues()
        {
            nud_MaxSunLevel.Value = parameters.MaxSunLevel;
            nud_ToxicLevel.Value = parameters.ToxicLevel;
            nud_AverageCharge.Value = parameters.AverageCharge;
            nud_ChargeRecoverySpeed.Value = parameters.ChargeRecoverySpeed;
            nud_OrganicIncrease.Value = parameters.OrganicIncrease;
            nud_ChargeIncrease.Value = parameters.ChargeIncrease;
            nud_MaxEnergyCapacity.Value = parameters.MaxEnergyCapacity;
            nud_EnergyDecreasement.Value = parameters.EnergyDecreasement;
            nud_ChargeExtraction.Value = parameters.MaxChargeExtraction;
            nud_OrganicExtraction.Value = parameters.MaxOrganicExtraction;
            nud_MaxGenCodeValue.Value = parameters.MaxGenCodeValue;
            nud_CellEatingCoefficient.Value = (decimal)parameters.CellEatingCoefficient;
            nud_OrganicEating.Value = parameters.OrganicEating;
            nud_MutationChance.Value = (decimal)parameters.MutationChance;
            checkBox_IsMutationEnabled.Checked = parameters.IsMutationEnabled;
        }
        private void SetNewCellParameters()
        {
            parameters.MaxSunLevel = (int)nud_MaxSunLevel.Value;
            parameters.ToxicLevel = (int)nud_ToxicLevel.Value;
            parameters.AverageCharge = (int)nud_AverageCharge.Value;
            parameters.ChargeRecoverySpeed = (int)nud_ChargeRecoverySpeed.Value;
            parameters.OrganicIncrease = (int)nud_OrganicIncrease.Value;
            parameters.ChargeIncrease = (int)nud_ChargeIncrease.Value;
            parameters.MaxEnergyCapacity = (int)nud_MaxEnergyCapacity.Value;
            parameters.EnergyDecreasement = (int)nud_EnergyDecreasement.Value;
            parameters.MaxChargeExtraction = (int)nud_ChargeExtraction.Value;
            parameters.MaxOrganicExtraction = (int)nud_OrganicExtraction.Value;
            parameters.MaxGenCodeValue = (int)nud_MaxGenCodeValue.Value;
            parameters.CellEatingCoefficient = (double)nud_CellEatingCoefficient.Value;
            parameters.OrganicEating = (int)nud_OrganicEating.Value;
            parameters.MutationChance = (double)nud_MutationChance.Value;
            parameters.IsMutationEnabled = checkBox_IsMutationEnabled.Checked;
            parameters.UpdateData();
        }
        private void ChangeResolution(bool isIncreace)
        {
            if (isIncreace)
            {
                resolutionLevel++;
                if (resolutionLevel > 8)
                    resolutionLevel = 8;
            }
            else
            {
                resolutionLevel--;
                if (resolutionLevel < 0)
                    resolutionLevel = 0;
            }
            printer.SetCellResolution(resolutionLevel);
            resolution = (int)Math.Pow(2, resolutionLevel);
        }
        private void ChangeLifeSpeed(int newLifeSpeed)
        {
            lifeSpeed = newLifeSpeed;
            if (lifeSpeed < 1)
                lifeSpeed = 1;
            updateTimer.Interval = 1000 / lifeSpeed;
        }

        private void AutoSave()
        {
            lastfieldSave = $"saves\\autosave{autosaveCounter++}.fld";
            fs = new FileStream(lastfieldSave, FileMode.Create, FileAccess.Write);
            bf.Serialize(fs, field);
            fs.Close();
            if (autosaveCounter > maxAutosaves)
                autosaveCounter = 1;
        }
        private void LoadLastSave()
        {
            fs = new FileStream(lastfieldSave, FileMode.Open, FileAccess.Read);
            field = (Field)bf.Deserialize(fs);
            fs.Close();
            parameters = field.Parameters;
            parameters.UpdateData();
            printer.SetField(field);
            Cell.field = field;
        }
        private bool LoadLastExit()
        {
            if (!File.Exists("exitSave.bin"))
                return false;
            fs = new FileStream("exitSave.bin", FileMode.Open, FileAccess.Read);
            maxAutosaves = (int)bf.Deserialize(fs);
            autosaveCounter = (int)bf.Deserialize(fs);
            autosaveTime = (int)bf.Deserialize(fs);
            resolutionLevel = (int)bf.Deserialize(fs);
            lifeSpeed = (int)bf.Deserialize(fs);
            camX = (float)bf.Deserialize(fs);
            camY = (float)bf.Deserialize(fs);
            camSpeed = (int)bf.Deserialize(fs);
            camMode = (string)bf.Deserialize(fs);
            parameters = (CellParameters)bf.Deserialize(fs);
            lastfieldSave = (string)bf.Deserialize(fs);
            fs.Close();
            printer = new FieldPrinter(null, screen, resolutionLevel, camSpeed, camMode);
            LoadLastSave();
            return true;
        }

        private void SaveField()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Field files (*.fld)|*.fld|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.DefaultExt = ".fld";
            saveFileDialog.Title = "Сохраненить поле";
            saveFileDialog.FileName = "Field";
            saveFileDialog.InitialDirectory = @"D:\C# проекты\CellLifeApp\CellLifeApp 0.4\bin\Debug\saves";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                lastfieldSave = saveFileDialog.FileName;
                fs = new FileStream(lastfieldSave, FileMode.Create, FileAccess.Write);
                bf.Serialize(fs, field);
                fs.Close();
            }
        }
        private void OpenField()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Field files (*.fld)|*.fld|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Загрузить поле";
            openFileDialog.InitialDirectory = @"D:\C# проекты\CellLifeApp\CellLifeApp 0.4\bin\Debug\saves";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var stream = openFileDialog.OpenFile();
                field = (Field)bf.Deserialize(stream);
                stream.Close();
                parameters = field.Parameters;
                parameters.UpdateData();
                printer.SetField(field);
                Cell.field = field;
            }
        }

        private void Exit()
        {
            AutoSave();
            fs = new FileStream("exitSave.bin", FileMode.Create, FileAccess.Write);
            bf.Serialize(fs, maxAutosaves);
            bf.Serialize(fs, autosaveCounter);
            bf.Serialize(fs, autosaveTime);
            bf.Serialize(fs, resolutionLevel);
            bf.Serialize(fs, lifeSpeed);
            bf.Serialize(fs, printer.CameraPosition.X);
            bf.Serialize(fs, printer.CameraPosition.Y);
            bf.Serialize(fs, printer.CamSpeed);
            bf.Serialize(fs, printer.CamMode);
            bf.Serialize(fs, parameters);
            bf.Serialize(fs, lastfieldSave);
            fs.Close();
            Close();
        }
    }
}
