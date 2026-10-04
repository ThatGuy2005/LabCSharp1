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
        // The second solution is to use static
        // members for the controls and methods
        // that need to be accessed from the thread.
        public Form1()
        {
            InitializeComponent();
            Trace.Listeners.Clear();    
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            Trace.AutoFlush = true;
        }

        // On start create a new Thread
        private void start_Click(object sender, EventArgs e)
        {
            activatedThreadForBar = new MyThread(updateProgressBar);
            
            activatedThreadForText = new MyThread(updateMoverPosition);
            
        }

        // Update the progress bar value from the thread
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

        // Update the mover position from the thread
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

        // On stop abort the thread
        private void stop_Click(object sender, EventArgs e)
        {
            activatedThreadForBar?.Abort();
            activatedThreadForText?.Abort();
        }

        // On form closing abort the thread
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

        // On font color button click,
        // show a color dialog
        // and set the mover's font color
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
