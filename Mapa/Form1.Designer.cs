namespace Mapa
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
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCT_CANVAS.Location = new System.Drawing.Point(47, 64);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(885, 500);
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
            this.LBL_SCORE.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LBL_SCORE.Location = new System.Drawing.Point(175, 28);
            this.LBL_SCORE.Name = "LBL_SCORE";
            this.LBL_SCORE.Size = new System.Drawing.Size(57, 16);
            this.LBL_SCORE.TabIndex = 2;
            this.LBL_SCORE.Text = "SCORE:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1282, 753);
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
    }
}

