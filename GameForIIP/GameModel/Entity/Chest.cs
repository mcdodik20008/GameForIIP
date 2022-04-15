using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    public class Chest : IEntity
    {
        public static int AllResourses = 0;
        public const int ChestCapasity = 1000;
        public int Resourses = 0;
        public static Chest LincChest = new Chest();
        public Command Act(int x, int y) => Command.Passive;
        public static IEntity Create() => LincChest;
        public int GetLayer() => 2;
        public string GetNameImage() => "Chest.png";

        public void SaveResourse(Player player)
        {
            if (Resourses + player.Pocket < ChestCapasity)
            {
                Resourses += player.Pocket;
                player.Pocket = 0;
                return;
            }
            player.Pocket -= (ChestCapasity - Resourses);
            Resourses = ChestCapasity;

        }

        public void GiveResourse(Player player)
        {
            if (GameModell.KeyPressed == System.Windows.Forms.Keys.G)
            {
                if (player.Pocket + Resourses < Player.PocketCapacity)
                {
                    player.Pocket += Resourses;
                    Resourses = 0;
                    return;
                }
                Resourses -= Player.PocketCapacity - player.Pocket;
                player.Pocket = Player.PocketCapacity;

            }  
        }
    }
}
