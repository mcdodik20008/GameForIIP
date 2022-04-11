namespace GameForIIP
{
    public class Command
    {
        public int DeltaX;
        public int DeltaY;
        public IEntity TransformTo;
        public static Command Passive = new Command() { DeltaX = 0, DeltaY = 0 };
    }
}
