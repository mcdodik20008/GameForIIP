using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameForIIP
{
    public class Player : IEntity
    {
        public const int PocketCapacity = 50;
        public int Pocket;
        public bool isWalking = false;
        public Command Act(int x, int y)
        {
            isWalking = true;
            switch (GameModell.KeyPressed)
            {
                case System.Windows.Forms.Keys.Up:
                    if (x - 1 < GameModell.Map.LengthY && GameModell.Map[x - 1, y] is Floor)
                        return new Command() { DeltaX = -1, DeltaY = 0 };
                    break;
                case System.Windows.Forms.Keys.Down:
                    if (x + 1 >= 0 && GameModell.Map[x + 1, y] is Floor)
                        return new Command() { DeltaX = 1, DeltaY = 0 };
                    break;
                case System.Windows.Forms.Keys.Right:
                    if (y + 1 < GameModell.Map.LengthY && GameModell.Map[x, y + 1] is Floor)
                        return new Command() { DeltaX = 0, DeltaY = 1 };
                    break;
                case System.Windows.Forms.Keys.Left:
                    if (y - 1 >= 0 && GameModell.Map[x, y - 1] is Floor)
                        return new Command() { DeltaX = 0, DeltaY = -1 };
                    break;
            }
            isWalking = false;
            return new Command() { DeltaX = 0, DeltaY = 0 };
        }

        public void CommitResourseToChest(Chest item) => 
            item.SaveResourse(this);
        
        public string GetNameImage() => "Player.png";

        public int GetLayer() => 1;

        public void TakeMachineResourses(Machine macine) =>
            macine.GetResources(this);
        
        public static IEntity Create() => new Player();
    }
    public static class PlayerExtentions
    {
        public static List<Machine> GetAllMachineAround(this Player p, Map map, Point pos) => GetAllTAround<Machine>(p, map, pos);

        public static List<Chest> GetAllChestAround(this Player p, Map map, Point pos) => GetAllTAround<Chest>(p, map, pos);

        private static List<T> GetAllTAround<T>(this Player p, Map map, Point pos)
            where T : IEntity
        {
            var lC = new List<T>();
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if (Math.Abs(i) != Math.Abs(j) && map[pos.X + i, pos.Y + j] is T c)
                        lC.Add(c);
            return lC;
        }
    }
}
