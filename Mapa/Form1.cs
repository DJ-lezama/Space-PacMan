using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
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
            
            switch (keyData)
            {
                case Keys.Left:
                    canvas.pacman.CurrentDirection = Pacman.Direction.Left;
                    break;
                case Keys.Right:
                    canvas.pacman.CurrentDirection = Pacman.Direction.Right;
                    break;
                case Keys.Up:
                    canvas.pacman.CurrentDirection = Pacman.Direction.Up;
                    break;
                case Keys.Down:
                    canvas.pacman.CurrentDirection = Pacman.Direction.Down;
                    break;
            }

            this.Refresh();

            BTNS_LABEL.Text = keyData.ToString();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_counter++;
            canvas.pacman.PacmanMove(canvas.map);
            canvas.DrawMap(timer_counter);
            LBL_SCORE.Text = "SCORE: " + canvas.map.Score.ToString();
            Refresh();
        }

    }
}
