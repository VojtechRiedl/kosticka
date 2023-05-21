using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace hra
{
    public class Game
    {
        private GameForm gameform;
        private Random rd = new Random();
        Player player;
        HashSet<PanelPoint> panelPoints = new HashSet<PanelPoint>();

        public Player Player { get => player; }

        public Game(GameForm gameForm, Player player) 
        {
            this.gameform = gameForm;
            this.player = player;
        }



        public void SpawnPoint()
        {
            panelPoints.Add(getRandomPoint());
        }

        public Point GetRandomPosition()
        {
            return new(GetRandomCor(gameform.panel1.Size.Width,20), GetRandomCor(gameform.panel1.Size.Height, 20));
        }

        public int GetRandomCor(int size, int panelSize)
        {
            return rd.Next(0, size - panelSize);
        }

        public void Cooldown()
        {
            SpawnPoint();
            foreach (var point in panelPoints)
            {
                point.UpdateSquare();
                if(point.Cooldown <= 0)
                {
                    point.Despawn();
                    Console.WriteLine("despawned");
                    if (panelPoints.Remove(point)) 
                    {
                        Console.WriteLine("removed" + point.Location);
                    };
                    Player.Lives--;
                    if (Player.Lives <= 0)
                    {
                        GameOver();
                    }
                    LoadHp();
                }
            }
            Update();
        }

        public void Update()
        {
            gameform.label1.Text = "Score: " + player.Score;
           
        }

        public void LoadHp()
        {
            gameform.flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < player.Lives; i++)
            {
                PictureBox p = new PictureBox();
                p.BackgroundImageLayout = ImageLayout.Stretch;
                p.BackgroundImage = Properties.Resources.heart;
                gameform.flowLayoutPanel1.Controls.Add(p);
            }
        }

        private void GameOver()
        {
            gameform.timer1.Enabled = false;
            foreach (var point in panelPoints)
            {
                point.Despawn();
                panelPoints.Remove(point);
            }

            Utils.Instance.ChangeForm(gameform, new GameOver(gameform.Text, player));
        }

        public void RemovePoint(PanelPoint point)
        {
            panelPoints.Remove(point);
        }


        public PanelPoint getRandomPoint()
        {
            int value = rd.Next(1,4);
            if(value == 1)
            {
                return new PanelPoint(gameform, GetRandomPosition(), 5);
            }else if(value == 2)
            {
                return new DoubleClicksPanelPoint(gameform, GetRandomPosition(), 5);
            }else
            {
                return new DoubleTimePanelPoint(gameform, GetRandomPosition(),10);
            }
        }
    }
}
