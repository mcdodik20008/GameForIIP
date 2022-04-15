using System.Drawing;

namespace GameForIIP
{
    public static class Swapper
    {
        public static bool SwapElementOnMap(this Map map, int x, int y)
        {
            var sup = map[x, y].Act(x, y);
            var nextPos = new Point(x + sup.DeltaX, y + sup.DeltaY);
            var supEl = map[x, y];
            map[x, y] = map[nextPos.X, nextPos.Y];
            map[nextPos.X, nextPos.Y] = supEl;
            return map[nextPos.X, nextPos.Y] is Player;
        }
    }
}
