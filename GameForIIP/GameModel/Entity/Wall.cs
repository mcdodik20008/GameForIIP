namespace GameForIIP
{
    class Wall : IEntity
    {
        public Command Act(int x, int y)
        {
            return new Command() { DeltaX = 0, DeltaY = 0 };
        }

        public bool DeadInConflict(IEntity conflictedObject)
        {
            return true;
        }

        public string GetNameImage() => "Wall.png";
        
        public int GetLayer() => 1;
        
    }
}
