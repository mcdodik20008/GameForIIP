namespace GameForIIP
{
    public interface IEntity
    {
        string GetNameImage();
        int GetLayer();
        Command Act(int x, int y);
    }
}
