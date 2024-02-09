using System;
using System.Drawing;
using System.Windows.Forms;
using Mapa;
using static PacMan.Ghost;

namespace PacMan
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Canvas canvas;
        int _timerCounter;
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
                    canvas.pacman.NextDirection = Pacman.Direction.Left;
                    break;
                case Keys.Right:
                    canvas.pacman.NextDirection = Pacman.Direction.Right;
                    break;
                case Keys.Up:
                    canvas.pacman.NextDirection = Pacman.Direction.Up;
                    break;
                case Keys.Down:
                    canvas.pacman.NextDirection = Pacman.Direction.Down;
                    break;
            }

            Refresh();

            BTNS_LABEL.Text = keyData.ToString();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void GameOver()
        {
            var result = MessageBox.Show(@"You Lost! Do you want to play again?", @"Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ResetGame(); 
            }
            else
            {
                Close(); 
            }
        }

        private void WinningGameLogic()
        {
            var result = MessageBox.Show(@"You won! Do you want to play again?", @"You won", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ResetGame(); 
            }
            else
            {
                Close();
            }
            
        }

        private void ResetGame()
        {
            //Re-initialize map
            Map newMap = new Map();
            canvas.SetMap(newMap);

            //Re-initialize Pacman
            canvas.InitializePacman();
            canvas.pacman.lives = 3;

            //Re-initialize ghosts
            canvas.ghosts.Clear();
            canvas.InitializeGhosts();
            foreach (Ghost ghost in canvas.ghosts)
            {
                ghost.CurrentMode = GhostMode.Chase;
            }
            
            canvas.map.Score = 0;
            canvas.pacman.poweredUp = false;
            gameOver = false;
        }

        private void PacmanAtePelletChecker()
        {
            if (canvas.pacman.poweredUp)
            {
                // Change ghosts mode to Frightened mode
                foreach (Ghost ghost in canvas.ghosts)
                {
                    ghost.CurrentMode = GhostMode.Frightened;
                }
                
                poweredUpDuration--;
                
                if (poweredUpDuration <= 0)
                {
                    //Deactivate Pacman powered up mode
                    canvas.pacman.poweredUp = false;
                    
                    // Deactivate Frightened mode
                    foreach (Ghost ghost in canvas.ghosts)
                    {
                        ghost.CurrentMode = GhostMode.Chase;
                    }
                    
                    poweredUpDuration = defaultDuration;
                }
            }
        }

        private void PacmanIsAliveChecker()
        {
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
        }

        private void GhostStateChecker()
        {
            foreach (Ghost ghost in canvas.ghosts){
                if (ghost.isAlive)
                {
                    switch (ghost.CurrentMode)
                    {
                        case GhostMode.Scatter:
                            if (_timerCounter % 9 == 0)
                            {
                                ghost.MoveBehaviour = new ScatterMode();
                            }
                            ghost.PerformMove(canvas.map, canvas);
                            break;
                        case GhostMode.Chase:
                            switch (ghost.Identifier)
                            {
                                case "blinky":
                                    ghost.MoveBehaviour = new BlinkyChaseMode();
                                    if (_timerCounter % 4 == 0)
                                    {
                                        ghost.PerformMove(canvas.map, canvas);
                                    }
                                    break;
                                case "pinky":
                                    ghost.MoveBehaviour = new PinkyChaseMode();
                                    if (_timerCounter % 4 == 0)
                                    {
                                        ghost.PerformMove(canvas.map, canvas);
                                    }
                                    break;
                                case "inky":
                                    ghost.MoveBehaviour = new InkyChaseMode();
                                    if (_timerCounter % 4 == 0)
                                    {
                                        ghost.PerformMove(canvas.map, canvas);
                                    }
                                    break;
                                case "clyde":
                                    ghost.MoveBehaviour = new ClydeChaseMode();
                                    if (_timerCounter % 4 == 0)
                                    {
                                        
                                        ghost.PerformMove(canvas.map, canvas);
                                    }
                                    break;
                            }
                            break;
                        case GhostMode.Frightened:
                            ghost.MoveBehaviour = new FrightenedMode();
                            ghost.PerformMove(canvas.map, canvas);
                            break;
                    }
                }
            }
        }

        private void ScatterModeChecker()
        {
            if (_timerCounter != 0 && _timerCounter % 160 == 0  && canvas.map.CountPillsLeft() > 20) 
            {
                // Change ghosts mode to Scatter mode
                foreach (Ghost ghost in canvas.ghosts)
                {
                    if (ghost.CurrentMode != GhostMode.Frightened) //Don't switch to Scatter mode if in Frightened mode
                    {
                        ghost.CurrentMode = GhostMode.Scatter;
                        if (ghost.MoveBehaviour is ScatterMode scatterMode)
                        {
                            ghost.scatterCounter = 0;
                            scatterMode.scatterModeHappenings++;
                        }
                    } 
                }
            } 
            
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Check if there are still Pills and/or Pellets on the map
            if (!gameOver && !canvas.map.ArePillsOrPelletsLeft())
            {
                gameOver = true;
                WinningGameLogic();
            }
            
            //Check pacman ate a Pellet
            PacmanAtePelletChecker();
            
            //Check if Pacman is alive
            PacmanIsAliveChecker();
            
            //Check ghosts' states and modes
            GhostStateChecker();
            
            //Check if its time to activate the Scatter mode 
            ScatterModeChecker();
            
            canvas.DrawMap(_timerCounter++);
            LBL_SCORE.Text = @"SCORE: " + canvas.map.Score.ToString();
            LBL_LIVES_LEFT.Text = canvas.pacman.lives.ToString();
            foreach(Ghost ghost in canvas.ghosts)
            {
                switch (ghost.Identifier)
                {
                    case "blinky":
                        LBL_GHOST_MODE_BLINKY.Text = @"Blinky: " + ghost.CurrentMode;
                        break;
                    case "pinky":
                        LBL_GHOST_MODE_PINKY.Text = @"Pinky: " + ghost.CurrentMode;
                        break;
                    case "inky":
                        LBL_GHOST_MODE_INKY.Text = @"Inky: " + ghost.CurrentMode;
                        break;
                    case "clyde":
                        LBL_GHOTS_MODE_CLYDE.Text = @"Clyde: " + ghost.CurrentMode;
                        break;
                }
            }
            LBL_TIMER_TICK.Text = @"TIMER TICK: " + _timerCounter;
            Refresh();
        }
    }
}
