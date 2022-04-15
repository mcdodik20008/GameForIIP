namespace GameForIIP
{
    public class Machine : IEntity
    {
        const int maxLevel = 2;
        public int Storage = 100;
        public int ProductivityPerSecond = 1;
        public int Resourses = 0;
        public int ResoursesToUpdate = 10;
        private int level = 1;

        public Command Act(int x, int y) => Command.Passive;

        public int GetLayer() => 2;

        public string GetNameImage() => $"Machine{level}.png";

        public void Update(Player player)
        {
            if (player.Pocket >= ResoursesToUpdate && level + 1 <= maxLevel)
            {
                player.Pocket = player.Pocket - ResoursesToUpdate;
                ProductivityPerSecond *= 2;
                ResoursesToUpdate *= 2;
                Storage *= 2;
                level++;
            }
        }

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

        public static IEntity Create() => new Machine();
    }
}
