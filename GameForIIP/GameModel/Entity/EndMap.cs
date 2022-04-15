namespace GameForIIP
{
    public class EndMap : IEntity
    {
        public Command Act(int x, int y) => Command.Passive;
        public static IEntity Create() => new EndMap();
        public int GetLayer() => 1;
        public string GetNameImage() => "EndMap.png";

    }
}
