using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    public abstract class Machine : IEntity
    {
        public int Storage = 100;
        public int ProductivityPerSecond = 1;
        public int Resourses = 0;

        public abstract Command Act(int x, int y);

        public abstract int GetLayer();

        public abstract string GetNameImage();

        public abstract void GetResources(Player player);

        public void Farming()
        {
            if (Resourses + ProductivityPerSecond <= Storage)
                Resourses += ProductivityPerSecond;
        }
    }
}
