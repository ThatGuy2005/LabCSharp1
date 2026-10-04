using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;

namespace LabCSharp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Trace.Listeners.Clear();    
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            Trace.AutoFlush = true;
        }

        private void start_Click(object sender, EventArgs e)
        {
            activatedThreadForBar = new MyThread(updateProgressBar);
            
            activatedThreadForText = new MyThread(updateMoverPosition);
            
        }

        public void updateProgressBar(int value)
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

        public void updateMoverPosition()
        {
            Random rand = new Random();
            if (mover.InvokeRequired)
            {
                mover.BeginInvoke(new Action(updateMoverPosition));
                return;
            }
            else
            {

                if (logSwitch.Enabled)
                {
                    Trace.WriteLine($"[{DateTime.Now}]Updating mover position");
                }
                mover.Location = new Point(rand.Next(0, 800), rand.Next(0, 600));
            }
        }
        public ProgressBar getBar { get { return this.bar; } }
        public Label getMover { get { return this.mover; } }
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
