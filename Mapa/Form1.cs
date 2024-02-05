using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapa
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Canvas canvas;
        int timer_counter;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            PCT_CANVAS.Image = bmp;
            canvas = new Canvas(bmp);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int deltaX = 0;
            int deltaY = 0; 

            switch (keyData)
            {
                case Keys.Left:
                    deltaX -= 1;
                    break;
                case Keys.Right:
                    deltaX += 1;
                    break;
                case Keys.Up:
                    deltaY -= 1;
                    break;
                case Keys.Down:
                    deltaY += 1;
                    break;
            }

            canvas.pacman.PacmanMove(deltaX, deltaY, canvas.map);
            canvas.DrawMap(timer_counter);

            this.Refresh();

            BTNS_LABEL.Text = keyData.ToString();
            LBL_SCORE.Text = "SCORE: " + canvas.map.Score.ToString();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_counter++;
            canvas.DrawMap(timer_counter);
            Refresh();
        }

    }
}
