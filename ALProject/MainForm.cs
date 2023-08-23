using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ALProject.Drawings;
using System.Threading;

namespace ALProject
{
    public partial class MainForm : Form
    {
        private int lifeSpeed;
        internal Field field;
        private DrawingField drawing;

        private Stopwatch sw = new Stopwatch();
        private long[] timeResult = new long[20];
        private int timeCount = 0;

        public MainForm()
        {
            InitializeComponent();
            field = new Field();
            Cell.field = field;
            field.CreateNewField((int)nudFieldRows.Value, (int)nudFieldCols.Value);
            drawing = new DrawingField(screen, field, (int)nudResolution.Value);
            SetNewLifeSpeed();
            sw.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            field.RandomizeField();
        }
        private void PrintTimer_Tick(object sender, EventArgs e)
        {
            drawing.PrintField();
            ShowFPS();
        }
        private void pause_button_Click(object sender, EventArgs e)
        {
            if (MainTimer.Enabled)
            {
                MainTimer.Stop();
                pause_button.Text = "Start";
            }
            else 
            {
                MainTimer.Start();
                pause_button.Text = "Stop";
            }
        }
        private void random_button_Click(object sender, EventArgs e)
        {
            field.RandomizeField();
        }
        private void nudResolution_ValueChanged(object sender, EventArgs e)
        {
            drawing.SetNewCellResolution((int)nudResolution.Value);
        }
        private void nudLifeSpeed_ValueChanged(object sender, EventArgs e)
        {
            SetNewLifeSpeed();
        }
        private void SetFSize_button_Click(object sender, EventArgs e)
        {
            field.CreateNewField((int)nudFieldRows.Value, (int)nudFieldCols.Value);
            field.Testing();
        }
        private void ShowFPS()
        {
            sw.Stop();
            timeResult[timeCount++] = sw.ElapsedMilliseconds;
            if (timeCount == timeResult.Length)
            {
                Text = (1000 / timeResult.Average()).ToString();
                //Text = timeResult.Average().ToString();
                timeCount = 0;
            }
            sw.Restart();
        }
        private void SetNewLifeSpeed()
        {
            lifeSpeed = (int)nudLifeSpeed.Value;
            MainTimer.Interval = 1000 / lifeSpeed;
        }
        private void clear_button_Click(object sender, EventArgs e)
        {
            field.SetClearField();
        }
        private void MainForm_ClientSizeChanged(object sender, EventArgs e)
        {
            drawing.ScreenUpdate();
        }
    }
}
