using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hra
{
    public partial class GameForm : Form
    {
        private Game game;       
        public Game Game { get => game; }

        public GameForm(Player player)
        {
            InitializeComponent();
            game = new Game(this, player);
            this.Text = "Klikací hra " + player.Name;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            game.LoadHp();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.Cooldown();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
