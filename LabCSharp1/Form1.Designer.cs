using System.Diagnostics;
using System.IO;

namespace LabCSharp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            activatedThreadForBar?.Abort();
            activatedThreadForText?.Abort();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.bar = new System.Windows.Forms.ProgressBar();
            this.mover = new System.Windows.Forms.Label();
            this.backgroundColor = new System.Windows.Forms.Button();
            this.fontColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(343, 99);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(91, 46);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(343, 230);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(91, 44);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // bar
            // 
            this.bar.Location = new System.Drawing.Point(230, 346);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(335, 23);
            this.bar.TabIndex = 2;
            // 
            // mover
            // 
            this.mover.AutoSize = true;
            this.mover.Location = new System.Drawing.Point(597, 391);
            this.mover.Name = "mover";
            this.mover.Size = new System.Drawing.Size(113, 20);
            this.mover.TabIndex = 3;
            this.mover.Text = "I like to move it";
            // 
            // backgroundColor
            // 
            this.backgroundColor.Location = new System.Drawing.Point(577, 99);
            this.backgroundColor.Name = "backgroundColor";
            this.backgroundColor.Size = new System.Drawing.Size(120, 80);
            this.backgroundColor.TabIndex = 4;
            this.backgroundColor.Text = "Set Background Color";
            this.backgroundColor.UseVisualStyleBackColor = true;
            this.backgroundColor.Click += new System.EventHandler(this.backgroundColor_Click);
            // 
            // fontColor
            // 
            this.fontColor.Location = new System.Drawing.Point(587, 220);
            this.fontColor.Name = "fontColor";
            this.fontColor.Size = new System.Drawing.Size(96, 65);
            this.fontColor.TabIndex = 5;
            this.fontColor.Text = "Set Font Color";
            this.fontColor.UseVisualStyleBackColor = true;
            this.fontColor.Click += new System.EventHandler(this.fontColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fontColor);
            this.Controls.Add(this.backgroundColor);
            this.Controls.Add(this.mover);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;

        private System.Threading.Thread activatedThreadForBar;

        private System.Threading.Thread activatedThreadForText;
        private System.Windows.Forms.ProgressBar bar;
        private System.Windows.Forms.Label mover;
        private System.Windows.Forms.Button backgroundColor;
        private System.Windows.Forms.Button fontColor;
        private FileStream logFile;
        private TextWriterTraceListener logListener;
        
    }
}

