using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    class Player : IEntity
    { 
        public Command Act(int x, int y)
        {
            int dx = 0, dy = 0;
            if (GameModell.KeyPressed == System.Windows.Forms.Keys.Up && y + 1 < GameModell.Map.LengthY)
            {
                dx = -1; dy = 0;
            }
            if (GameModell.KeyPressed == System.Windows.Forms.Keys.Down && y - 1 >= 0)
            {
                dx = 1; dy = 0;
            }
            if (GameModell.KeyPressed == System.Windows.Forms.Keys.Right && x + 1 < GameModell.Map.LengthY)
            {
                dx = 0; dy = 1;
            }
            if (GameModell.KeyPressed == System.Windows.Forms.Keys.Left && x - 1 >= 0)
            {
                dx = 0; dy = -1;
            }
            if (GameModell.Map[x + dx, y + dy] != null && GameModell.Map[x + dx, y + dy].ToString() == "Digger.Sack")
            {
                dx = 0; dy = 0;
            }
            return new Command()
            {
                DeltaX = dx,
                DeltaY = dy
            };
        }

        public string GetNameImage() => "Player.png";

        public int GetLayer() => 1;
    }
}
