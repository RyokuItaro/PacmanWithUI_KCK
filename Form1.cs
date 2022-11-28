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
        public static BoardGenerator boardGenerator = new BoardGenerator();
        public static Pacman pacman = new Pacman();
        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            boardGenerator.CreateMapOnForm(this);
            boardGenerator.InitializeMap();

            var pacmanSpawnpoint = boardGenerator.SetSpawnPoint(1, 1);
            pacman.CreatePacman(this, pacmanSpawnpoint.Item1, pacmanSpawnpoint.Item2);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch(e.KeyCode){
                case Keys.Up:
                    pacman.nextDirection = Direction.up;
                    pacman.Move(Direction.up);
                    break;
                case Keys.Down:
                    pacman.nextDirection = Direction.down;
                    pacman.Move(Direction.down);
                    break;
                case Keys.Left:
                    pacman.nextDirection = Direction.left;
                    pacman.Move(Direction.left);
                    break;
                case Keys.Right:
                    pacman.nextDirection = Direction.right;
                    pacman.Move(Direction.right);
                    break;
            }
        }
    }
}
