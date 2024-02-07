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
        public int poweredUpDuration;
        public const int defaultDuration = 100;

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
            poweredUpDuration = defaultDuration;
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
            if (canvas.pacman.poweredUp)
            {
                poweredUpDuration--;
                if (poweredUpDuration <= 0)
                {
                    canvas.pacman.poweredUp = false;
                    poweredUpDuration = defaultDuration;
                }
            }

            
            if (canvas.pacman.isAlive)
            {
                canvas.pacman.PacmanMove(canvas.map);
                canvas.map.GhostCollisions(canvas.pacman, canvas.ghosts);
            }
            else if (canvas.pacman.lives <= 0 && !canvas.pacman.isAlive)
            {
                 // Implement Game Over logic here

            }
            

            canvas.DrawMap(timer_counter++);
            LBL_SCORE.Text = "SCORE: " + canvas.map.Score.ToString();
            Console.WriteLine("Lives: " + canvas.pacman.lives);
            LBL_LIVES_LEFT.Text = canvas.pacman.lives.ToString();
            Refresh();
        }

    }
}
