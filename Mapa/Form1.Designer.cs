﻿namespace PacMan
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BTNS_LABEL = new System.Windows.Forms.Label();
            this.LBL_SCORE = new System.Windows.Forms.Label();
            this.LBL_LIVES = new System.Windows.Forms.Label();
            this.LBL_LIVES_LEFT = new System.Windows.Forms.Label();
            this.LBL_GHOST_MODE_BLINKY = new System.Windows.Forms.Label();
            this.LBL_GHOST_MODE_PINKY = new System.Windows.Forms.Label();
            this.LBL_GHOTS_MODE_CLYDE = new System.Windows.Forms.Label();
            this.LBL_GHOST_MODE_INKY = new System.Windows.Forms.Label();
            this.LBL_TIMER_TICK = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCT_CANVAS.Location = new System.Drawing.Point(47, 64);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(880, 500);
            this.PCT_CANVAS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 80;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BTNS_LABEL
            // 
            this.BTNS_LABEL.AutoSize = true;
            this.BTNS_LABEL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BTNS_LABEL.Location = new System.Drawing.Point(29, 9);
            this.BTNS_LABEL.Name = "BTNS_LABEL";
            this.BTNS_LABEL.Size = new System.Drawing.Size(97, 16);
            this.BTNS_LABEL.TabIndex = 1;
            this.BTNS_LABEL.Text = "Button pressed";
            // 
            // LBL_SCORE
            // 
            this.LBL_SCORE.AutoSize = true;
            this.LBL_SCORE.BackColor = System.Drawing.Color.Black;
            this.LBL_SCORE.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LBL_SCORE.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LBL_SCORE.Location = new System.Drawing.Point(175, 28);
            this.LBL_SCORE.Name = "LBL_SCORE";
            this.LBL_SCORE.Size = new System.Drawing.Size(97, 26);
            this.LBL_SCORE.TabIndex = 2;
            this.LBL_SCORE.Text = "SCORE:";
            // 
            // LBL_LIVES
            // 
            this.LBL_LIVES.AutoSize = true;
            this.LBL_LIVES.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LBL_LIVES.ForeColor = System.Drawing.Color.Snow;
            this.LBL_LIVES.Location = new System.Drawing.Point(398, 28);
            this.LBL_LIVES.Name = "LBL_LIVES";
            this.LBL_LIVES.Size = new System.Drawing.Size(81, 26);
            this.LBL_LIVES.TabIndex = 3;
            this.LBL_LIVES.Text = "LIVES:";
            // 
            // LBL_LIVES_LEFT
            // 
            this.LBL_LIVES_LEFT.AutoSize = true;
            this.LBL_LIVES_LEFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LBL_LIVES_LEFT.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LBL_LIVES_LEFT.Location = new System.Drawing.Point(479, 28);
            this.LBL_LIVES_LEFT.Name = "LBL_LIVES_LEFT";
            this.LBL_LIVES_LEFT.Size = new System.Drawing.Size(0, 26);
            this.LBL_LIVES_LEFT.TabIndex = 4;
            // 
            // LBL_GHOST_MODE_BLINKY
            // 
            this.LBL_GHOST_MODE_BLINKY.AutoSize = true;
            this.LBL_GHOST_MODE_BLINKY.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LBL_GHOST_MODE_BLINKY.Location = new System.Drawing.Point(629, 28);
            this.LBL_GHOST_MODE_BLINKY.Name = "LBL_GHOST_MODE_BLINKY";
            this.LBL_GHOST_MODE_BLINKY.Size = new System.Drawing.Size(44, 16);
            this.LBL_GHOST_MODE_BLINKY.TabIndex = 5;
            this.LBL_GHOST_MODE_BLINKY.Text = "label1";
            // 
            // LBL_GHOST_MODE_PINKY
            // 
            this.LBL_GHOST_MODE_PINKY.AutoSize = true;
            this.LBL_GHOST_MODE_PINKY.ForeColor = System.Drawing.SystemColors.Control;
            this.LBL_GHOST_MODE_PINKY.Location = new System.Drawing.Point(728, 28);
            this.LBL_GHOST_MODE_PINKY.Name = "LBL_GHOST_MODE_PINKY";
            this.LBL_GHOST_MODE_PINKY.Size = new System.Drawing.Size(44, 16);
            this.LBL_GHOST_MODE_PINKY.TabIndex = 6;
            this.LBL_GHOST_MODE_PINKY.Text = "label1";
            // 
            // LBL_GHOTS_MODE_CLYDE
            // 
            this.LBL_GHOTS_MODE_CLYDE.AutoSize = true;
            this.LBL_GHOTS_MODE_CLYDE.ForeColor = System.Drawing.SystemColors.Control;
            this.LBL_GHOTS_MODE_CLYDE.Location = new System.Drawing.Point(829, 28);
            this.LBL_GHOTS_MODE_CLYDE.Name = "LBL_GHOTS_MODE_CLYDE";
            this.LBL_GHOTS_MODE_CLYDE.Size = new System.Drawing.Size(44, 16);
            this.LBL_GHOTS_MODE_CLYDE.TabIndex = 7;
            this.LBL_GHOTS_MODE_CLYDE.Text = "label1";
            // 
            // LBL_GHOST_MODE_INKY
            // 
            this.LBL_GHOST_MODE_INKY.AutoSize = true;
            this.LBL_GHOST_MODE_INKY.ForeColor = System.Drawing.SystemColors.Control;
            this.LBL_GHOST_MODE_INKY.Location = new System.Drawing.Point(922, 28);
            this.LBL_GHOST_MODE_INKY.Name = "LBL_GHOST_MODE_INKY";
            this.LBL_GHOST_MODE_INKY.Size = new System.Drawing.Size(44, 16);
            this.LBL_GHOST_MODE_INKY.TabIndex = 8;
            this.LBL_GHOST_MODE_INKY.Text = "label1";
            // 
            // LBL_TIMER_TICK
            // 
            this.LBL_TIMER_TICK.AutoSize = true;
            this.LBL_TIMER_TICK.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LBL_TIMER_TICK.Location = new System.Drawing.Point(1014, 27);
            this.LBL_TIMER_TICK.Name = "LBL_TIMER_TICK";
            this.LBL_TIMER_TICK.Size = new System.Drawing.Size(44, 16);
            this.LBL_TIMER_TICK.TabIndex = 9;
            this.LBL_TIMER_TICK.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.LBL_TIMER_TICK);
            this.Controls.Add(this.LBL_GHOST_MODE_INKY);
            this.Controls.Add(this.LBL_GHOTS_MODE_CLYDE);
            this.Controls.Add(this.LBL_GHOST_MODE_PINKY);
            this.Controls.Add(this.LBL_GHOST_MODE_BLINKY);
            this.Controls.Add(this.LBL_LIVES_LEFT);
            this.Controls.Add(this.LBL_LIVES);
            this.Controls.Add(this.LBL_SCORE);
            this.Controls.Add(this.BTNS_LABEL);
            this.Controls.Add(this.PCT_CANVAS);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label BTNS_LABEL;
        private System.Windows.Forms.Label LBL_SCORE;
        private System.Windows.Forms.Label LBL_LIVES;
        private System.Windows.Forms.Label LBL_LIVES_LEFT;
        private System.Windows.Forms.Label LBL_GHOST_MODE_BLINKY;
        private System.Windows.Forms.Label LBL_GHOST_MODE_PINKY;
        private System.Windows.Forms.Label LBL_GHOTS_MODE_CLYDE;
        private System.Windows.Forms.Label LBL_GHOST_MODE_INKY;
        private System.Windows.Forms.Label LBL_TIMER_TICK;
    }
}

