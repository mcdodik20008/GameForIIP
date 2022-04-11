using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameForIIP
{
    public class Player : IEntity
    {
        public const int PocketCapacity = 50;
        public int Pocket;
        public Command Act(int x, int y)
        {
            int dx = 0, dy = 0;
            if (GameModell.KeyPressed == System.Windows.Forms.Keys.Up && x - 1 < GameModell.Map.LengthY)
            {
                dx = -1; dy = 0;
            }
            if (GameModell.KeyPressed == System.Windows.Forms.Keys.Down && x + 1 >= 0)
            {
                dx = 1; dy = 0;
            }
            if (GameModell.KeyPressed == System.Windows.Forms.Keys.Right && y + 1 < GameModell.Map.LengthY)
            {
                dx = 0; dy = 1;
            }
            if (GameModell.KeyPressed == System.Windows.Forms.Keys.Left && y - 1 >= 0)
            {
                dx = 0; dy = -1;
            }
            if (GameModell.Map[x + dx, y + dy] is Wall ||
                GameModell.Map[x + dx, y + dy] is EndMap ||
                GameModell.Map[x + dx, y + dy] is MacineLevel1 ||
                GameModell.Map[x + dx, y + dy] is Chest)
            {
                dx = 0; dy = 0;
            }
            return new Command()
            {
                DeltaX = dx,
                DeltaY = dy
            };
        }

        //положить ресы в сундук
        internal void CommitResourseToChest(Chest item)
        {
            throw new NotImplementedException();
        }

        public string GetNameImage() => "Player.png";

        public int GetLayer() => 1;

        public void TakeMachineResourses(Machine macine)
        {
            macine.GetResources(this);
        }
    }
    public static class PlayerExtentions
    {
        public static List<Machine> GetAllMachineAround(this Player p, Map map, Point pos)
        {
            var lM = new List<Machine>();
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if (Math.Abs(i) != Math.Abs(j) && map[pos.X + i, pos.Y + j] is Machine m)
                        lM.Add(m);
            return lM;
        }

        public static List<Chest> GetAllChestAround(this Player p, Map map, Point pos)
        {
            var lC = new List<Chest>();
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if (Math.Abs(i) != Math.Abs(j) && map[pos.X + i, pos.Y + j] is Chest c)
                        lC.Add(c);
            return lC;
        }
    }
}
