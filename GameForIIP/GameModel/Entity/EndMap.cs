using System;

namespace GameForIIP
{
    public class EndMap : IEntity
    {
        public Command Act(int x, int y)
        {
            return new Command() { DeltaX = 0, DeltaY = 0 };
        }

        public int GetLayer() => 1;

        public string GetNameImage() => "EndMap.png";
        
    }
}
