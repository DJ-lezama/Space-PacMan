using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PacMan;
using static PacMan.Ghost;

namespace Mapa
{
    public partial class Form1 : Form
    {
        private Bitmap _bmp;
        private Canvas _canvas;
        private int _timerCounter;
        private bool _gameOver;
        private int _poweredUpDuration;
        private const int DefaultDuration = 100;
        
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            PCT_CANVAS.Image = _bmp;
            _canvas = new Canvas(_bmp);
            _poweredUpDuration = DefaultDuration;
            _gameOver = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    _canvas.pacman.NextDirection = Pacman.Direction.Left;
                    break;
                case Keys.Right:
                    _canvas.pacman.NextDirection = Pacman.Direction.Right;
                    break;
                case Keys.Up:
                    _canvas.pacman.NextDirection = Pacman.Direction.Up;
                    break;
                case Keys.Down:
                    _canvas.pacman.NextDirection = Pacman.Direction.Down;
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
            var newMap = new Map();
            _canvas.SetMap(newMap);

            //Re-initialize Pacman
            _canvas.InitializePacman();
            _canvas.pacman.lives = 3;

            //Re-initialize ghosts
            _canvas.ghosts.Clear();
            _canvas.InitializeGhosts();
            foreach (var ghost in _canvas.ghosts)
            {
                ghost.CurrentMode = GhostMode.Chase;
            }
            
            _canvas.map.Score = 0;
            _canvas.pacman.poweredUp = false;
            _gameOver = false;
        }

        private void PacmanAtePelletChecker()
        {
            if (!_canvas.pacman.poweredUp) return;
            // Change ghosts mode to Frightened mode
            foreach (var ghost in _canvas.ghosts)
            {
                ghost.CurrentMode = GhostMode.Frightened;
            }
                
            _poweredUpDuration--;

            if (_poweredUpDuration > 0) return;
            {
                //Deactivate Pacman powered up mode
                _canvas.pacman.poweredUp = false;
                    
                // Deactivate Frightened mode
                foreach (var ghost in _canvas.ghosts)
                {
                    ghost.CurrentMode = GhostMode.Chase;
                }
                    
                _poweredUpDuration = DefaultDuration;
            }
        }

        private void PacmanIsAliveChecker()
        {
            if (_canvas.pacman.isAlive)
            {
                _canvas.pacman.PacmanMove(_canvas.map);
                _canvas.map.GhostCollisions(_canvas.pacman, _canvas.ghosts);
            }
            else if (!_gameOver && _canvas.pacman.lives <= 0 && !_canvas.pacman.isAlive)
            {
                _gameOver = true;
                GameOver();
            }   
        }

        private void GhostStateChecker()
        {
            foreach (var ghost in _canvas.ghosts){
                if (ghost.isAlive)
                {
                    switch (ghost.CurrentMode)
                    {
                        case GhostMode.Scatter:
                            // Use the scatter mode behaviour
                            ghost.MoveBehaviour = new ScatterMode();
                            ghost.PerformMove(_canvas.map, _canvas);
                            break;
                        case GhostMode.Chase:
                            switch (ghost.Identifier)
                            {
                                case "blinky":
                                    ghost.MoveBehaviour = new BlinkyChaseMode();
                                    if (_timerCounter % 6 == 0)
                                    {
                                        ghost.PerformMove(_canvas.map, _canvas);
                                    }
                                    break;
                                case "pinky":
                                    ghost.MoveBehaviour = new PinkyChaseMode();
                                    ghost.PerformMove(_canvas.map, _canvas);
                                    break;
                                case "inky":
                                    ghost.MoveBehaviour = new InkyChaseMode();
                                    ghost.PerformMove(_canvas.map, _canvas);
                                    break;
                                case "clyde":
                                    ghost.MoveBehaviour = new ClydeChaseMode();
                                    ghost.PerformMove(_canvas.map, _canvas);
                                    break;
                            }
                            break;
                        case GhostMode.Frightened:
                            ghost.MoveBehaviour = new FrightenedMode();
                            ghost.PerformMove(_canvas.map, _canvas);
                            break;
                    }
                }
            }
        }

        private void ScatterModeChecker()
        {
            if (_timerCounter == 0 || _timerCounter % 80 != 0 || _canvas.map.CountPillsLeft() <= 20) return;
            // Change ghosts mode to Scatter mode
            foreach (var ghost in _canvas.ghosts.Where(ghost => ghost.CurrentMode != GhostMode.Frightened))
            {
                //Don't switch to Scatter mode if in Frightened mode
                ghost.CurrentMode = GhostMode.Scatter;
                if (!(ghost.MoveBehaviour is ScatterMode scatterMode)) continue;
                ghost.scatterCounter = 0;
                scatterMode.scatterModeHappenings++;
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Check if there are still Pills and/or Pellets on the map
            if (!_gameOver && !_canvas.map.ArePillsOrPelletsLeft())
            {
                _gameOver = true;
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
            
            _canvas.DrawMap(_timerCounter++);
            LBL_SCORE.Text = @"SCORE: " + _canvas.map.Score;
            LBL_LIVES_LEFT.Text = _canvas.pacman.lives.ToString();
            foreach(Ghost ghost in _canvas.ghosts)
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
