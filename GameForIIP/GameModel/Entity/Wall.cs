namespace GameForIIP
{
    class Wall : IEntity
    {
        public Command Act(int x, int y) => Command.Passive;
        public string GetNameImage() => "Wall.png";
        public int GetLayer() => 1;
        public static IEntity Create() => new Wall();
    }
}
