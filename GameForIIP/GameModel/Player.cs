using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    public interface ICreature
    {
        string GetImageFileName();
        int GetDrawingPriority();
        CreatureCommand Act(int x, int y);
        bool DeadInConflict(ICreature conflictedObject);
    }

    public class CreatureCommand
    {
        public int DeltaX;
        public int DeltaY;
        public ICreature TransformTo;
    }

    class Player
    {
        public string GetImageFileName()
        {
            return "Digger.png";
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public CreatureCommand Act(int x, int y)
        {
            int dx = 0, dy = 0;
            if (GameModel.KeyPressed == System.Windows.Forms.Keys.Down && y + 1 < GameModel.Map.LengthY)
            {
                dx = 0; dy = 1;
            }
            if (GameModel.KeyPressed == System.Windows.Forms.Keys.Up && y - 1 >= 0)
            {
                dx = 0; dy = -1;
            }
            if (GameModel.KeyPressed == System.Windows.Forms.Keys.Right && x + 1 < GameModel.Map.LengthY)
            {
                dx = 1; dy = 0;
            }
            if (GameModel.KeyPressed == System.Windows.Forms.Keys.Left && x - 1 >= 0)
            {
                dx = -1; dy = 0;
            }
            if (GameModel.Map[x + dx, y + dy] != MapCell.Wall && GameModel.Map[x + dx, y + dy].ToString() == "Digger.Sack")
            {
                dx = 0; dy = 0;
            }
            return new CreatureCommand()
            {
                DeltaX = dx,
                DeltaY = dy
            };
        }
    }
}
