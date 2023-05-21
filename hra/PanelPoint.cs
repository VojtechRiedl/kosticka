using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hra
{
    public class PanelPoint : Panel
    {
        protected int cooldown;
        protected GameForm gameForm;

        public int Cooldown { get => cooldown; }

        public PanelPoint(GameForm gameForm,Point loc, int cooldown)
        {
            this.Location = loc;
            this.Size = new Size(20, 20);
            this.BackColor = Color.Green;
            this.cooldown = cooldown;
            this.gameForm = gameForm;
            gameForm.panel1.Controls.Add(this);
            this.Click += PanelPoint_Click;
        }

        protected void PanelPoint_Click(object? sender, EventArgs e)
        {
            Despawn();
            gameForm.Game.Player.Score += 1;
            gameForm.Game.Update();

       

        }

        public virtual void UpdateSquare()
        {
            cooldown -= 1;
            if (cooldown == 3)
            {
                this.BackColor = Color.Yellow;
            }else if(cooldown == 1)
            {
                this.BackColor = Color.Red;
            }
        }
        public void Despawn()
        {
            gameForm.panel1.Controls.Remove(this);
            gameForm.Game.RemovePoint(this);
        }

    }
}
