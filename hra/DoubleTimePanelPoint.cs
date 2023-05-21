using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hra
{
    internal class DoubleTimePanelPoint : PanelPoint
    {
        public DoubleTimePanelPoint(GameForm gameForm, Point loc, int cooldown) : base(gameForm, loc, cooldown)
        {
            this.cooldown = 2 * cooldown;
            this.BackColor = Color.Black;
        }


        public override void UpdateSquare()
        {
            cooldown -= 1;
            if (cooldown == 6)
            {
                this.BackColor = Color.Blue;
            }
            else if (cooldown == 3)
            {
                this.BackColor = Color.Violet;
            }
        }




    }
}
