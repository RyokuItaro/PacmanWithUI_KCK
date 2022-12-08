using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_KCK.Classes
{
    public static class LabelGenerator
    {
        public static Form form;
        public static Form menuForm;
        public static Label label = new Label();

        public static async void GameLost()
        {
            label.Text = "Przegrałeś";
            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;
            label.ForeColor = Color.White;
            form.Controls.Add(label);
            label.BringToFront();
            await Task.Delay(5000);
            form.Hide();
            menuForm.Show();
        }

        public static async void GameWon()
        {
            label.Text = "Wygrałeś";
            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;
            label.ForeColor = Color.White;
            form.Controls.Add(label);
            label.BringToFront();
            await Task.Delay(5000);
            form.Hide();
            menuForm.Show();
        }
    }
}
