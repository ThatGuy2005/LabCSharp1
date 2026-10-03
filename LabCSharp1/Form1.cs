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
            activatedThread = new System.Threading.Thread(run);
            activatedThread.Start();
        }

        private void run()
        {
            
            for (int i = 0; i <= 100; i++)
            {
                
                bar.Value = i;
                System.Threading.Thread.Sleep(50);
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            activatedThread.Join();
        }
    }
}
