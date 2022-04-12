using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    public abstract class Machine : IEntity
    {
        public int X;
        public int Y;
        public int Storage = 100;
        public int ProductivityPerSecond = 1;
        public int Resourses = 0;
        public int ResoursesToUpdate = 10;

        public abstract Command Act(int x, int y);

        public abstract int GetLayer();

        public abstract string GetNameImage();

        public abstract Machine Update(Player player);

        public void Farming()
        {
            if (Resourses + ProductivityPerSecond <= Storage)
                Resourses += ProductivityPerSecond;
        }

        public void GetResources(Player player)
        {
            if (player.Pocket + Resourses > Player.PocketCapacity)
            {
                Resourses -= Player.PocketCapacity - player.Pocket;
                player.Pocket = Player.PocketCapacity;
                return;
            }
            player.Pocket += Resourses;
            Resourses = 0;
        }   
    }
}
