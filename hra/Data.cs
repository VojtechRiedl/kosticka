using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hra
{
    internal class Data
    {
        int score;
        string name;
        string gameName;

        public Data(int score, string name, string gameName)
        {
            this.score = score;
            this.name = name;
            this.gameName = gameName;
        }

        public int Score { get => score; set => score = value; }
        public string Name { get => name; set => name = value; }
        public string GameName { get => gameName; set => gameName = value; }
    }
}
