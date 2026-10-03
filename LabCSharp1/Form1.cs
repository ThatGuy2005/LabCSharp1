using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabCSharp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            activatedThreadForBar = new System.Threading.Thread(runBar);
            activatedThreadForBar.Start();
            activatedThreadForText = new System.Threading.Thread(runText);
            activatedThreadForText.Start();
        }

        private void runText()
        {
            while (true)
            {
                updateMoverPosition();
                System.Threading.Thread.Sleep(100);
            }
        }

        private void runBar()
        {
            
            for (int i = 0; i <= 100; i++)
            {
                updateProgressBar(i);
                updateMoverPosition();
                System.Threading.Thread.Sleep(50);
            }
        }

        private void updateProgressBar(int value)
        {
            if (bar.InvokeRequired)
            {
                bar.BeginInvoke(new Action<int>(updateProgressBar), value);
            }
            else
            {
                bar.Value = value;
            }
        }

        private void updateMoverPosition()
        {
            Random rand = new Random();
            if (mover.InvokeRequired)
            {
                mover.BeginInvoke(new Action(updateMoverPosition));
            }
            else
            {
                mover.Location = new Point(rand.Next(0, 800), rand.Next(0, 600));
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            activatedThreadForBar?.Abort();
            activatedThreadForText?.Abort();
        }

        private void backgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            colorDialog.Color = this.BackColor;

            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog.Color;
            }
        }

        private void fontColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            colorDialog.Color = this.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                mover.ForeColor = colorDialog.Color;
            }
        }
    }
}
