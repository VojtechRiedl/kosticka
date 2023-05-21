using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hra
{
    internal class DoubleClicksPanelPoint : PanelPoint
    {
        public DoubleClicksPanelPoint(GameForm gameForm, Point loc, int cooldown) : base(gameForm,loc,cooldown)
        {
            this.DoubleClick += DoubleClicksPanelPoint_DoubleClick;
            this.Click -= PanelPoint_Click;
            this.BackColor = Color.Brown;
        }

        private void DoubleClicksPanelPoint_DoubleClick(object? sender, EventArgs e)
        {
            this.Despawn();
            this.gameForm.Game.Player.Score += 1;
            this.gameForm.Game.Update();
            
        }

       
    }
}
