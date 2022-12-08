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
    public partial class Form2 : Form
    {
        public static int menuOption = 0;
        public Form2()
        {
            InitializeComponent();
            LabelGenerator.menuForm = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 game = new Form1();
            game.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
