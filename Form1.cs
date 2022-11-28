using Pacman_KCK.Classes;
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
        private static BoardGenerator boardGenerator = new BoardGenerator();
        public Form1()
        {
            InitializeComponent();
        }
    }
}
