using Pacman_KCK.Classes;
using Pacman_KCK.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_KCK
{
    public partial class Form1 : Form
    {
        public bool keyReleased = false;
        public static BoardGenerator boardGenerator = new BoardGenerator();
        public static Points points = new Points();
        public static Pacman pacman = new Pacman();
        public static Ghost ghosts = new Ghost();
        public Form1()
        {
            InitializeComponent();
            LabelGenerator.form = this;
            Task.Delay(5000);
            StartGame();
        }

        private void StartGame()
        {
            boardGenerator.CreateMapOnForm(this);
            boardGenerator.InitializeMap();
            points.InitializePointsOnMap(this);

            var pacmanSpawnpoint = boardGenerator.SetSpawnPoint(1, 1);
            pacman.CreatePacman(this, pacmanSpawnpoint.Item1, pacmanSpawnpoint.Item2);

            ghosts.CreateGhosts(this);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (keyReleased)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        pacman.nextDirection = Direction.up;
                        pacman.Move(Direction.up);
                        keyReleased = false;
                        break;
                    case Keys.Down:
                        pacman.nextDirection = Direction.down;
                        pacman.Move(Direction.down);
                        keyReleased = false;
                        break;
                    case Keys.Left:
                        pacman.nextDirection = Direction.left;
                        pacman.Move(Direction.left);
                        keyReleased = false;
                        break;
                    case Keys.Right:
                        pacman.nextDirection = Direction.right;
                        pacman.Move(Direction.right);
                        keyReleased = false;
                        break;
                }
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            keyReleased = true;
        }
    }
}
