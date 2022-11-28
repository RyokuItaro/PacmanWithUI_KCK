using Pacman_KCK.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_KCK.Classes
{
    public class Pacman
    {
        public int y = 0;
        public int x = 0;
        public int ySpawn = 0;
        public int xSpawn = 0;
        public Direction currDirection;
        public Direction nextDirection;
        public PictureBox pacmanSkin = new PictureBox();
        public ImageList pacmanLeftSprites = new ImageList();
        public ImageList pacmanRightSprites = new ImageList();
        public ImageList pacmanDownSprites = new ImageList();
        public ImageList pacmanUpSprites = new ImageList();
        public Timer timer = new Timer();
        public int spriteCounter = 0;

        public Pacman()
        {
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += new EventHandler(moveTick);

            pacmanDownSprites.Images.Add(Resource1.pacman0);
            pacmanDownSprites.Images.Add(Resource1.pacmanDown1);
            pacmanDownSprites.Images.Add(Resource1.pacmanDown2);
            pacmanDownSprites.Images.Add(Resource1.pacmanDown1);

            pacmanLeftSprites.Images.Add(Resource1.pacman0);
            pacmanLeftSprites.Images.Add(Resource1.pacmanLeft1);
            pacmanLeftSprites.Images.Add(Resource1.pacmanLeft2);
            pacmanLeftSprites.Images.Add(Resource1.pacmanLeft1);

            pacmanRightSprites.Images.Add(Resource1.pacman0);
            pacmanRightSprites.Images.Add(Resource1.pacmanRight1);
            pacmanRightSprites.Images.Add(Resource1.pacmanRight2);
            pacmanRightSprites.Images.Add(Resource1.pacmanRight1);

            pacmanUpSprites.Images.Add(Resource1.pacman0);
            pacmanUpSprites.Images.Add(Resource1.pacmanUp1);
            pacmanUpSprites.Images.Add(Resource1.pacmanUp2);
            pacmanUpSprites.Images.Add(Resource1.pacmanUp1);

            pacmanUpSprites.ImageSize = new Size(27, 28);
            pacmanRightSprites.ImageSize = new Size(27, 28);
            pacmanLeftSprites.ImageSize = new Size(27, 28);
            pacmanDownSprites.ImageSize = new Size(27, 28);
        }

        public void CreatePacman(Form form, int spawnX, int spawnY)
        {
            pacmanSkin.Name = "pacman";
            pacmanSkin.SizeMode = PictureBoxSizeMode.AutoSize;
            xSpawn = spawnX;
            ySpawn = spawnY;
            pacmanSkin.Image = Resource1.pacmanLeft1;
            currDirection = Direction.left;
            nextDirection = Direction.left;
            x = spawnX;
            y = spawnY;
            pacmanSkin.Location = new Point(x * 16 - 5, y * 16 - 5);
            form.Controls.Add(pacmanSkin);
            pacmanSkin.BringToFront();
        }

        private void moveTick(object sender, EventArgs e)
        {
            Move(currDirection);
        }

        public void Move(Direction direction)
        {
            bool isMovingPossible = CheckIfMovementIsPossible(nextDirection);

            if (!isMovingPossible) {
                isMovingPossible = CheckIfMovementIsPossible(currDirection);
                direction = currDirection; 
            } 
            else 
            { 
                direction = nextDirection; 
            }

            if (isMovingPossible) {
                currDirection = direction; 
            }

            if (isMovingPossible)
            {
                switch (direction)
                {
                    case Direction.up: 
                        pacmanSkin.Top -= 16; 
                        y--; 
                        break;
                    case Direction.right: 
                        pacmanSkin.Left += 16; 
                        x++; 
                        break;
                    case Direction.down: 
                        pacmanSkin.Top += 16; 
                        y++; 
                        break;
                    case Direction.left: 
                        pacmanSkin.Left -= 16; 
                        x--; 
                        break;
                }
                currDirection = direction;
                UpdatePacmanSprite();
                CheckIfPacmanScoredAPoint();
                //TODO: checking for ghosts collision
            }
        }

        private void CheckIfPacmanScoredAPoint()
        {
            if (Form1.boardGenerator.Map[y, x] == (int)Objects.point)
            {
                Form1.points.EatPoint(y,x);
            }
        }

        private bool CheckIfMovementIsPossible(Direction direction)
        {
            switch (direction)
            {
                case Direction.up:
                    return RenderAhead(x, y - 1);
                case Direction.right:
                    return RenderAhead(x + 1, y);
                case Direction.down:
                    return RenderAhead(x, y + 1);
                case Direction.left:
                    return RenderAhead(x - 1, y); 
            }
            return false;
        }

        private bool RenderAhead(int xx, int yy)
        {
            if (xx < 0) { 
                x = 27;
                return true; 
            }
            if (xx > 27) { 
                x = 0;
                return true; 
            }
            return Form1.boardGenerator.Map[yy, xx] != (int)Objects.wall;
        }

        private void UpdatePacmanSprite()
        {
            switch (currDirection)
            {
                case Direction.up:
                    pacmanSkin.Image = pacmanUpSprites.Images[spriteCounter++%4];
                    break;
                case Direction.down:
                    pacmanSkin.Image = pacmanDownSprites.Images[spriteCounter++%4];
                    break;
                case Direction.left:
                    pacmanSkin.Image = pacmanLeftSprites.Images[spriteCounter++%4];
                    break;
                case Direction.right:
                    pacmanSkin.Image = pacmanRightSprites.Images[spriteCounter++%4];
                    break;
            }
        }
    }
}
