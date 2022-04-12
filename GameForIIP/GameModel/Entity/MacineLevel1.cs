using System;
using System.Windows.Forms;

namespace GameForIIP
{
    public class MacineLevel1 : Machine
    {

        public MacineLevel1(int x, int y)
        {
            X = x; Y = y;
        }
        public override Command Act(int x, int y) => Command.Passive;

        public override int GetLayer() => 2;

        public override string GetNameImage() => "Machine.png";

        public override Machine Update(Player player)
        {
            if (player.Pocket >= ResoursesToUpdate)
            {
                player.Pocket -= ResoursesToUpdate;
                return new MachineLevel2(Resourses, X, Y);
            }
            //else
            //    new Message().ShowDialog();
            return this;
        }
    }
}
