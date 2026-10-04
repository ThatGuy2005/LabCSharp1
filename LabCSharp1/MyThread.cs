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
        public MyThread(Action updateMover)
        {
            this.updateMoverPosition = updateMover;
            myThread = new Thread(runTextCallback);
            myThread.Start();
        }
        public MyThread(Action<int> updateProgressBar)
        {
            this.updateProgressBar = updateProgressBar;
            myThread = new Thread(runBarCallback);
            myThread.Start();
        }

        private void runText()
        {
            while (true)
            {   
                mainForm.updateMoverPosition();
                System.Threading.Thread.Sleep(100);
            }
        }

        private void runBar()
        {
            for (int i = 0; i <= 100; i++)
            {
                mainForm.updateProgressBar(i);
                System.Threading.Thread.Sleep(50);
            }
        }
        private void runBarCallback()
        {
            for (int i = 0; i <= 100; i++)
            {
                updateProgressBar(i);
                System.Threading.Thread.Sleep(50);
            }
        }

        private void runTextCallback()
        {
            while (true)
            {
                updateMoverPosition();
                System.Threading.Thread.Sleep(100);
            }
        }
        public void Abort()
        {
            myThread.Abort();
        }

        ~MyThread()
        {
            myThread.Abort();
        }
        private Form1 mainForm;
        private Action<int> updateProgressBar;
        private Action updateMoverPosition;

        private Thread myThread;
        
    }
}
