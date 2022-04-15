using System.Linq;
using System.Windows.Forms;

namespace GameForIIP
{
    public static class Animations
    {
        public static void Act(this Map map)
        {
            var t = map.FindPlayerPos();
            map.SwapElementOnMap(t.X, t.Y);
        }

        public static void UpdateMachine(this Map map)
        {
            var playerPos = GameModell.VisibleMap.FindPlayerPos();
            var player = GameModell.VisibleMap[playerPos.X, playerPos.Y] as Player;
            var machine = player.GetAllMachineAround(GameModell.VisibleMap, playerPos).FirstOrDefault();
            switch (GameModell.KeyPressed)
            {
                case Keys.U:
                    if (machine != null)
                        machine.Update(player);
                    break;
            }
        }
    }
}
