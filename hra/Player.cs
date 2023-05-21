using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hra
{
    public class Player
    {
        private string name;
        private int score;
        private int lives;

        public Player(string name)
        {
            this.lives = 3;
            this.score = 0;
            this.name = name;
        }

        public string Name { get => name; }
        public int Score { get => score; set => score = value; }
        public int Lives { get => lives; set => lives = value; }
    }
}
