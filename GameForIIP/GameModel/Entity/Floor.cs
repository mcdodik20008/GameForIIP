namespace GameForIIP
{
    public class Floor : IEntity
    {
        public Command Act(int x, int y) => Command.Passive;
        public static IEntity Create() => new Floor();
        public int GetLayer() => 2;
        public string GetNameImage() => "Floor.png";
    }
}
