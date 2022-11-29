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
    public class Points
    {
        public PictureBox[,] points = new PictureBox[30, 27];
        public int count = 0;

        public void InitializePointsOnMap(Form form)
        {
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 27; x++)
                {
                    if (Form1.boardGenerator.Map[y,x] == (int)Objects.point)
                    {
                        points[y, x] = new PictureBox();
                        points[y, x].SizeMode = PictureBoxSizeMode.AutoSize;
                        points[y, x].Location = new Point(x * 16 - 5, y * 16 - 5);
                        points[y, x].Image = Resource1.point;
                        form.Controls.Add(points[y, x]);
                        points[y, x].BringToFront();
                        count++;
                    }
                }
            }
        }

        public void EatPoint(int y, int x)
        {
            Form1.boardGenerator.Map[y, x] = (int)Objects.empty;
            points[y, x].Visible = false;
            count--;
            if(count == 0)
            {
                throw new Exception("won");
            }
        }
    }
}
