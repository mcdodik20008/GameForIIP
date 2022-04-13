using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    public class EShop : IEntity
    {
        public Command Act(int x, int y) => Command.Passive;

        public int GetLayer() => 2;

        public string GetNameImage() => "Shop.png";
    }
}
