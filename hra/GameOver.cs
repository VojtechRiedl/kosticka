using Newtonsoft.Json;
using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hra
{
    public partial class GameOver : Form
    {
        string gameName;
        Player player;

        SimpleTcpClient client;

        public GameOver(string gameName, Player player)
        {
            InitializeComponent();
            this.gameName = gameName;
            this.player = player;
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient("127.0.0.1:9000");
            client.Connect();

            if (client.IsConnected)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    Console.WriteLine("client connected");

                    string jsonData = JsonConvert.SerializeObject(new Data(player.Score, player.Name, gameName));
                   

                    client.Send(jsonData);

                    Console.WriteLine("client sent data");
                });
            }


            label2.Text = "Jméno: " + player.Name;
            label3.Text = "Score: " + player.Score;
        }


    }
}
