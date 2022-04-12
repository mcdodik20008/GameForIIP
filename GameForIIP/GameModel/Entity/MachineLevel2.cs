using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    class MachineLevel2 : Machine
    {
        public MachineLevel2(int resourse, int x, int y)
        {
            X = x; Y = y;
            Storage = 200;
            ProductivityPerSecond = 5;
            Resourses = resourse;
        }
        public override Command Act(int x, int y) => Command.Passive;

        public override int GetLayer() => 2;

        public override string GetNameImage() => "Machine2.png";

        public override Machine Update(Player player) => this;
        
    }
}
