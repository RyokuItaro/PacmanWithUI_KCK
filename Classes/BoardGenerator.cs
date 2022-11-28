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
    public class BoardGenerator
    {
        public PictureBox Board = new PictureBox();
        public int[,] Map = new int[30,27];
        public Tuple<int, int> SpawnPoint;
        public void CreateMapOnForm(Form form)
        {
            Board.Name = "PacMan";
            Board.SizeMode = PictureBoxSizeMode.AutoSize;
            Board.Location = new Point(0, 0);
            Board.Image = Resource1.board;
            form.Controls.Add(Board);
        }

        public void InitializeMap()
        {
            Map = new int[,]
            {
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.point,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.point,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.empty,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.empty,(int)Objects.empty,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.point,(int)Objects.wall },
                { (int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall,(int)Objects.wall }
            };
        }

        public Tuple<int, int> SetSpawnPoint(int x, int y)
        {
            SpawnPoint = new Tuple<int, int>(x, y);
            return SpawnPoint;
        }
    }
}
//LEVEL DESIGN FROM CONSOLE VERSION
//############################
//#************##************#
//#*####*#####*##*#####*####*#
//#*####*#####*##*#####*####*#
//#*####*#####*##*#####*####*#
//#**************************#
//#*####*##*########*##*####*#
//#*####*##*########*##*####*#
//#******##****##****##******#
//######*##### ## #####*######
//######*##### ## #####*######
//######*##          ##*######
//######*## ######## ##*######
//######*## ######## ##*######
//       *  ########   *      
//#######*# ######## ##*######
//#######*# ######## ##*######
//#######*#          ##*######
//#######*# ######## ##*######
//#######*# ######## ##*######
//#************##************#
//#*####*#####*##*#####*####*#
//#*####*#####*##*#####*####*#
//#***##****************##***#
//###*##*##*########*##*##*###
//###*##*##*########*##*##*###
//#******##****##****##******#
//#*##########*##*##########*#
//#*##########*##*##########*#
//#**************************#
//############################