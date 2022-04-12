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

        public Command Act(int x, int y) => Command.Passive;


        public int GetLayer() => 2;

        public string GetNameImage() => "Chest.png";

        //сделай
        public void SaveResourse(Player player) //не забудь про ёмкость
        {
            if (Resourses + player.Pocket < ChestCapasity)
            {
                Resourses += player.Pocket;
                player.Pocket = 0;
            }
            else
            {
                player.Pocket -= (ChestCapasity - Resourses);
                Resourses = ChestCapasity;
            }
        }

        public void GiveResourse(Player player)
        {
            if (GameModell.KeyPressed == System.Windows.Forms.Keys.G) 
            { 
                if (player.Pocket + Resourses < Player.PocketCapacity)
                    player.Pocket += Resourses;
                else
                {
                    Resourses -= Player.PocketCapacity - player.Pocket;
                    player.Pocket = Player.PocketCapacity;   
                }
            }    
        }
    }
}
