using System;
using System.Drawing;
using System.Windows.Forms;
using Mapa;

namespace PacMan
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Canvas canvas;
        int timer_counter;
        private Boolean gameOver;
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
            gameOver = false;
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
        
        private void GameOver()
        {
            var result = MessageBox.Show("You Lost! Do you want to play again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ResetGame(); 
            }
            else
            {
                this.Close(); 
            }
        }

        private void WinningGameLogic()
        {
            var result = MessageBox.Show("You won! Do you want to play again?", "You won", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ResetGame(); 
            }
            else
            {
                this.Close();
            }
            
        }

        private void ResetGame()
        {
            
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!gameOver && !canvas.map.ArePillsOrPelletsLeft())
            {
                gameOver = true;
                WinningGameLogic();
                
            }
            
            if (canvas.pacman.poweredUp)
            {
                // Change ghosts mode to Frightened mode
                foreach (Ghost ghost in canvas.ghosts)
                {
                    ghost.CurrentMode = Ghost.GhostMode.Frightened;
                }
                
                poweredUpDuration--;
                if (poweredUpDuration <= 0)
                {
                    canvas.pacman.poweredUp = false;
                    
                    // Deactivate Frightened mode
                    foreach (Ghost ghost in canvas.ghosts)
                    {
                        ghost.CurrentMode = Ghost.GhostMode.Chase;
                    }
                    
                    poweredUpDuration = defaultDuration;
                }
            }
            
            if (canvas.pacman.isAlive)
            {
                canvas.pacman.PacmanMove(canvas.map);
                canvas.map.GhostCollisions(canvas.pacman, canvas.ghosts);
            }
            else if (!gameOver && canvas.pacman.lives <= 0 && !canvas.pacman.isAlive)
            {
                gameOver = true;
                GameOver();
            }

            foreach (Ghost ghost in canvas.ghosts){
                if (ghost.isAlive)
                {
                    switch (ghost.CurrentMode)
                    {
                        case Ghost.GhostMode.Scatter:
                            ghost.MoveBehaviour = new ScatterMode();
                            ghost.PerformMove(canvas.map);
                            break;
                        case Ghost.GhostMode.Chase:
                            switch (ghost.Identifier)
                            {
                                case "blinky":
                                    ghost.MoveBehaviour = new BlinkyChaseMode();
                                    ghost.PerformMove(canvas.map);
                                    break;
                                case "pinky":
                                    ghost.MoveBehaviour = new PinkyChaseMode();
                                    ghost.PerformMove(canvas.map);
                                    break;
                                case "inky":
                                    ghost.MoveBehaviour = new InkyChaseMode();
                                    ghost.PerformMove(canvas.map);
                                    break;
                                case "clyde":
                                    ghost.MoveBehaviour = new ClydeChaseMode();
                                    ghost.PerformMove(canvas.map);
                                    break;
                            }
                            break;
                        case Ghost.GhostMode.Frightened:
                            ghost.MoveBehaviour = new FrightenedMode();
                            ghost.PerformMove(canvas.map);
                            break;
                    }
                }
            }
            
            canvas.DrawMap(timer_counter++);
            LBL_SCORE.Text = "SCORE: " + canvas.map.Score.ToString();
            LBL_LIVES_LEFT.Text = canvas.pacman.lives.ToString();
            Refresh();
        }

    }
}
