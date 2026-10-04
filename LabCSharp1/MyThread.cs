using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Principal;

using ProgressBar = System.Windows.Forms.ProgressBar;
using Label = System.Windows.Forms.Label;
using Thread = System.Threading.Thread;

namespace LabCSharp1
{
    enum ThreadType
    {
        ProgressBarThread,
        MoverThread
    }
    internal class MyThread
    {
        public MyThread(ThreadType type, object widget)
        {
            myThread = new Thread(() =>
            {
                if (type == ThreadType.ProgressBarThread)
                {
                    runBar();
                }
                else if (type == ThreadType.MoverThread)
                {
                    runText();
                }
            });
        }

        private void runText(Label text)
        {
            while (true)
            {
                updateMoverPosition(text);
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
        private void updateProgressBar(int value, ProgressBar bar)
        {
            if (bar.InvokeRequired)
            {
                bar.BeginInvoke(new Action<int, ProgressBar>(updateProgressBar), value, bar);
            }
            else
            {
                bar.Value = value;
            }
        }

        private void updateMoverPosition(Label mover)
        {
            Random rand = new Random();
            if (mover.InvokeRequired)
            {
                mover.BeginInvoke(new Action<Label>(updateMoverPosition), mover);
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

        Thread myThread;
        private static BooleanSwitch logSwitch = new BooleanSwitch("logSwitch", "Log Switch");
    }
}
