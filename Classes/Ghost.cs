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
    public class Ghost
    {
        public int[] y = new int[4];
        public int[] x = new int[4];
        public Direction[] currDirection = new Direction[4];
        public PictureBox[] ghosts = new PictureBox[4];
        public Image ghostStay = Resource1.ghost0;
        public ImageList ghostLeftSprites = new ImageList();
        public ImageList ghostRightSprites = new ImageList();
        public ImageList ghostDownSprites = new ImageList();
        public ImageList ghostUpSprites = new ImageList();
        public Timer timer = new Timer();
        private Random rnd = new Random();
        public int spriteCounter = 0;

        public Ghost()
        {
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += new EventHandler(moveTick);

            ghostLeftSprites.Images.Add(Resource1.ghostLeft1);
            ghostLeftSprites.Images.Add(Resource1.ghostLeft2);
            ghostLeftSprites.Images.Add(Resource1.ghostLeft1);
            ghostLeftSprites.ImageSize = new Size(27,28);

            ghostRightSprites.Images.Add(Resource1.ghostRight1);
            ghostRightSprites.Images.Add(Resource1.ghostRight2);
            ghostRightSprites.Images.Add(Resource1.ghostRight1);
            ghostRightSprites.ImageSize = new Size(27,28);

            ghostUpSprites.Images.Add(Resource1.ghostUp1);
            ghostUpSprites.Images.Add(Resource1.ghostUp2);
            ghostUpSprites.Images.Add(Resource1.ghostUp1);
            ghostUpSprites.ImageSize = new Size(27, 28);

            ghostDownSprites.Images.Add(Resource1.ghostDown1);
            ghostDownSprites.Images.Add(Resource1.ghostDown2);
            ghostDownSprites.Images.Add(Resource1.ghostDown1);
            ghostDownSprites.ImageSize = new Size(27,28);
        }

        public void CreateGhosts(Form form)
        {
            for(int c = 0; c < 4; c++)
            {
                ghosts[c] = new PictureBox();
                ghosts[c].SizeMode = PictureBoxSizeMode.AutoSize;
                form.Controls.Add(ghosts[c]);
                ghosts[c].BringToFront();
            }
            PlaceGhostsAtSpawnPoints();
        }

        private void PlaceGhostsAtSpawnPoints()
        {
            //1st ghost
            y[0] = 11;
            x[0] = 11;
            
            //2nd ghost
            y[1] = 11;
            x[1] = 13;

            //3rd ghost
            y[2] = 11;
            x[2] = 15;

            //4th ghost
            y[3] = 11;
            x[3] = 17;

            for(int c = 0; c < 4; c++)
            {
                ghosts[c].Location = new Point(x[c] * 16 - 5, y[c] * 16 - 5);
                ghosts[c].Image = ghostStay;
                currDirection[c] = Direction.left;
            }
        }

        private void moveTick(object sender, EventArgs e)
        {
            for(int ghost = 0; ghost < 4; ghost++)
            {
                MoveGhosts(ghost);
            }
        }

        private void MoveGhosts(int ghostNum)
        {
            var isMovingPossible = CheckIfMovementIsPossible(currDirection[ghostNum], ghostNum);

            while (!isMovingPossible)
            {
                currDirection[ghostNum] = (Direction)rnd.Next(0, 4);
                isMovingPossible = CheckIfMovementIsPossible(currDirection[ghostNum], ghostNum);
            }

            switch (currDirection[ghostNum])
            {
                case Direction.up:
                    ghosts[ghostNum].Top -= 16;
                    y[ghostNum]--;
                    break;
                case Direction.right:
                    ghosts[ghostNum].Left += 16;
                    x[ghostNum]++;
                    break;
                case Direction.down:
                    ghosts[ghostNum].Top += 16;
                    y[ghostNum]++;
                    break;
                case Direction.left:
                    ghosts[ghostNum].Left -= 16;
                    x[ghostNum]--;
                    break;
            }
            UpdateGhostSprite(ghostNum);
            CheckPacmanCollision(ghostNum);
        }

        private void CheckPacmanCollision(int ghostNum)
        {
            if ((x[ghostNum] == Form1.pacman.x 
                || x[ghostNum] == Form1.pacman.x + 1
                || x[ghostNum] == Form1.pacman.x - 1)
                && 
                (y[ghostNum] == Form1.pacman.y
                || y[ghostNum] == Form1.pacman.y + 1
                || y[ghostNum] == Form1.pacman.y - 1)
                )
            {
                LabelGenerator.GameLost();
            }
        }

        private bool CheckIfMovementIsPossible(Direction direction, int ghostNum)
        {
            switch (direction)
            {
                case Direction.up:
                    return RenderAhead(x[ghostNum], y[ghostNum] - 1, ghostNum);
                case Direction.right:
                    return RenderAhead(x[ghostNum] + 1, y[ghostNum], ghostNum);
                case Direction.down:
                    return RenderAhead(x[ghostNum], y[ghostNum] + 1, ghostNum);
                case Direction.left:
                    return RenderAhead(x[ghostNum] - 1, y[ghostNum], ghostNum);
            }
            return false;
        }

        private bool RenderAhead(int xx, int yy, int ghostNum)
        {
            if (xx < 0)
            {
                x[ghostNum] = 27;
                return true;
            }
            if (xx > 27)
            {
                x[ghostNum] = 0;
                return true;
            }
            return Form1.boardGenerator.Map[yy, xx] != (int)Objects.wall && !CheckCollisionWithOtherGhosts(yy,xx,ghostNum);
        }

        private bool CheckCollisionWithOtherGhosts(int yy, int xx, int ghostNum)
        {
            var collision = false;
            for(int i = 0; i < 4; i++)
            {
                if(i != ghostNum)
                {
                    collision = xx == x[ghostNum] && yy == y[ghostNum];
                }
            }
            return collision;
        }

        private void UpdateGhostSprite(int ghostNum)
        {
            switch (currDirection[ghostNum])
            {
                case Direction.up:
                    ghosts[ghostNum].Image = ghostUpSprites.Images[spriteCounter++ % 3];
                    break;
                case Direction.down:
                    ghosts[ghostNum].Image = ghostDownSprites.Images[spriteCounter++ % 3];
                    break;
                case Direction.left:
                    ghosts[ghostNum].Image = ghostLeftSprites.Images[spriteCounter++ % 3];
                    break;
                case Direction.right:
                    ghosts[ghostNum].Image = ghostRightSprites.Images[spriteCounter++ % 3];
                    break;
            }
        }
    }
}
