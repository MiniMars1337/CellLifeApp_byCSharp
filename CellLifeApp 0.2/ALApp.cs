using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using CellLifeApp.FieldClasses;
using CellLifeApp.PrintingClasses;

namespace CellLifeApp
{
    public partial class ALApp : Form
    {
        private Field field;
        private FieldPrinter printer;
        private Stopwatch sw = new Stopwatch();
        private long[] timeResult = new long[20];
        private int timeCount = 0;
        private bool isPrinting = true;

        private int timeFPS = 0, fps = 0;

        private int generation = 0;

        public ALApp()
        {
            InitializeComponent();
            field = new Field();
            field.TestPattern();
            //printer = new FieldPrinter(field, splitContainer1.Panel2, resolutionTrackBar.Value);
            printer = new FieldPrinter(field, screen, resolutionTrackBar.Value);
            printer.CamSpeed = (int)nudCamSpeed.Value;
            LifeTimer.Interval = 1000 / (int)nudLifeSpeed.Value;
            camModeBox.SelectedItem = camModeBox.Items[0];
            printer.CamMode = (string)camModeBox.SelectedItem;

            SizeChanged += (s, e) => printer = new FieldPrinter(field, screen, resolutionTrackBar.Value);
            pause_button.Click += (s, e) => StopLife();
            //clear_button.Click += (s, e) => field.SetClearField();
            clear_button.Click += (s, e) => field.TestPattern();
            LifeTimer.Tick += (s, e) => LifeTick();
            SetFSize_button.Click += (s, e) => field.SetFieldSize((int)nudFieldCols.Value, (int)nudFieldRows.Value);
            resolutionTrackBar.ValueChanged += (s, e) => printer.SetCellResolution(resolutionTrackBar.Value);
            nudCamSpeed.ValueChanged += (s, e) => printer.CamSpeed = (int)nudCamSpeed.Value;
            nudLifeSpeed.ValueChanged += (s, e) => LifeTimer.Interval = 1000 / (int)nudLifeSpeed.Value;
            camModeBox.SelectedIndexChanged += (s, e) => printer.CamMode = (string)camModeBox.SelectedItem;

            saveButton.Click += (s, e) => SaveButtonClick();

            KeyDown += (s, e) => CheckKeyPress(e);

            sw.Start();
        }

        private void StopLife()
        {
            if (LifeTimer.Enabled)
            {
                LifeTimer.Stop();
                pause_button.Text = "Start";
            }
            else
            {
                LifeTimer.Start();
                pause_button.Text = "Stop";
            }
        }
        private void PrintingTick()
        {
            label1.Text = ((int)printer.camPos.Y).ToString();
            label2.Text = ((int)printer.camPos.X).ToString();
            labelOrganic.Text = (field[(int)printer.camPos.X, (int)printer.camPos.Y]?.Organic ?? null).ToString();
            labelCharge.Text = (field[(int)printer.camPos.X, (int)printer.camPos.Y]?.Charge ?? null).ToString();
            labelCellType.Text = (field[(int)printer.camPos.X, (int)printer.camPos.Y]?.GetType().Name ?? null);
            labelCountOfGen.Text = field.geneticCells.Count.ToString();
            if (field[(int)printer.camPos.X, (int)printer.camPos.Y] is LifeCell)
                labelEnergy.Text = (((LifeCell)field[(int)printer.camPos.X, (int)printer.camPos.Y]).Energy).ToString();
            else labelEnergy.Text = "NaN";
            if (isPrinting)
                printer.PrintField();
        }
        private void LifeTick()
        {
            labelGeneration.Text = generation.ToString();
            generation++;
            field.UpdateField();
        }
        private void SaveButtonClick()
        {
            saveFileDialog1.ShowDialog();
        }
        private void CheckKeyPress(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.E:
                    isPrinting = !isPrinting;
                    break;
                case Keys.W:
                    printer.CamMove(Direct.Up);
                    break;
                case Keys.D:
                    printer.CamMove(Direct.Right);
                    break;
                case Keys.S:
                    printer.CamMove(Direct.Down);
                    break;
                case Keys.A:
                    printer.CamMove(Direct.Left);
                    break;
                case Keys.Oemplus:
                    if (resolutionTrackBar.Maximum > resolutionTrackBar.Value)
                        resolutionTrackBar.Value += resolutionTrackBar.SmallChange;
                    break;
                case Keys.OemMinus:
                    if (resolutionTrackBar.Minimum < resolutionTrackBar.Value)
                        resolutionTrackBar.Value -= resolutionTrackBar.SmallChange;
                    break;
                default:
                    break;
            }
        }

        private void PrintTimer_Tick(object sender, EventArgs e)
        {
            sw.Stop();
            timeFPS += (int)sw.ElapsedMilliseconds;
            fps++;
            if (timeFPS >= 1000)
            {
                Text = $"CellLifeApp V0.2     FPS: {fps}";
                timeFPS = 0;
                fps = 0;
            }


            label1.Text = ((int)printer.camPos.Y).ToString();
            label2.Text = ((int)printer.camPos.X).ToString();
            labelOrganic.Text = (field[(int)printer.camPos.X, (int)printer.camPos.Y]?.Organic ?? null).ToString();
            labelCharge.Text = (field[(int)printer.camPos.X, (int)printer.camPos.Y]?.Charge ?? null).ToString();
            labelCellType.Text = (field[(int)printer.camPos.X, (int)printer.camPos.Y]?.GetType().Name ?? null);
            labelCountOfGen.Text = field.geneticCells.Count.ToString();
            if (field[(int)printer.camPos.X, (int)printer.camPos.Y] is LifeCell)
                labelEnergy.Text = (((LifeCell)field[(int)printer.camPos.X, (int)printer.camPos.Y]).Energy).ToString();
            else labelEnergy.Text = "NaN";

            sw.Restart();
            if (isPrinting)
                printer.PrintField();
        }
    }
}
