namespace GameForIIP
{
    public class Floor : IEntity
    {
        public Command Act(int x, int y)
        {
            return new Command() { DeltaX = 0, DeltaY = 0 };
        }

        public int GetLayer() => 2;

        public string GetNameImage() => "Floor.png";
    }
}
