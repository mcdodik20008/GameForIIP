using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameForIIP
{
    public class GameModell
    {
        public const int ElementSize = 65;
        public const int SubMapSize = 12;
        public static ScoreOnModel Score = new ScoreOnModel();
        public static Keys KeyPressed;
        public static Map Map { get; private set; }
        public static Map VisibleMap { get; private set; }
        public static int LengthX { get => Map.LengthX; }// можно убрать, так-то смысла нет в этом
        public static int LengthY { get => Map.LengthY; }
        public static int MinLength { get => Map.MinLength; }
        public static List<Machine> Machines { get; private set; }

        public GameModell(Size WindowSize)
        {
            Map = MapCreator.Create();
            VisibleMap = new Map(SubMapSize);
            VisibleMap.GetSubMap(Map, Map.FindPlayerPos());
            Machines = Map.GetAllMacine();
        }

        public static void MachineFarming()
        {
            foreach (var item in Machines)
                item.Farming();
        }

        static readonly List<Keys> GoodButtons = new List<Keys>() { Keys.P, Keys.G };
        public static void UpdateScore()
        {
            var playerPos = VisibleMap.FindPlayerPos();
            var player = VisibleMap[playerPos.X, playerPos.Y] as Player;
            Score.Player = player.Pocket;
            if (GoodButtons.Any(key => key == KeyPressed))
            {
                var machine = player.GetAllMachineAround(VisibleMap, playerPos).FirstOrDefault();
                var chest = player.GetAllChestAround(VisibleMap, playerPos).FirstOrDefault();

                switch (KeyPressed)
                {
                    case Keys.P:
                        if (chest != null)
                            player.CommitResourseToChest(chest);
                        break;
                    case Keys.G:
                        if (machine != null)
                            player.TakeMachineResourses(machine);
                        if (chest != null)
                            chest.GiveResourse(player);
                        break;
                }

                Score.Chest = chest != null ? chest.Resourses : Score.Chest;
                Score.All = player.Pocket + Score.Chest;
            }
        }
    }
}
