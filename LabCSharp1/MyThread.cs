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
        // The first solution is to pass the Form1 instance
        // to the MyThread constructor and use it to access the controls.
        // This way, you can avoid using static
        // members and still update the UI from the thread.
        public MyThread(ThreadType type, Form1 form)
        {
            mainForm = form;
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
            myThread.Start();
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
                System.Threading.Thread.Sleep(50);
            }
        }
        private void updateProgressBar(int value)
        {
            if (mainForm.getBar.InvokeRequired)
            {
                mainForm.getBar.BeginInvoke(new Action<int>(updateProgressBar), value);
            }
            else
            {
                mainForm.getBar.Value = value;
            }
        }

        private void updateMoverPosition()
        {
            Random rand = new Random();
            if (mainForm.getMover.InvokeRequired)
            {
                mainForm.getMover.BeginInvoke(new Action(updateMoverPosition), mainForm.getMover);
            }
            else
            {

                if (logSwitch.Enabled)
                {
                    Trace.WriteLine($"[{DateTime.Now}]Updating mover position");
                }
                mainForm.getMover.Location = new Point(rand.Next(0, 800), rand.Next(0, 600));
            }
        }
        ~MyThread()
        {
            if (logSwitch.Enabled)
            {
                Trace.WriteLine($"[{DateTime.Now}]Thread destroyed");
            }
            myThread.Abort();
        }
        Form1 mainForm;
        Thread myThread;
        private static BooleanSwitch logSwitch = new BooleanSwitch("logSwitch", "Log Switch");
    }
}
