using System;

namespace GameForIIP
{
    public class MacineLevel1 : Machine
    {
        public override Command Act(int x, int y) => Command.Passive;

        public override int GetLayer() => 2;

        public override string GetNameImage() => "Machine.png";

        public override void GetResources(Player player)
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
