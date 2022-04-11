using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameForIIP
{
	public class GameModell
	{
		public const int ElementSize = 65;
		public const int SubMapSize = 12;
		public int Score = 0;
		public static Keys KeyPressed;
		public static Map Map { get; private set; }
		public static Map VisibleMap { get; private set; }
		public static int LengthX { get => Map.LengthX; }
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

		public static void UpdateScore()
        {
			var playerPos = VisibleMap.FindPlayerPos();
			var player = VisibleMap[playerPos.X, playerPos.Y] as Player;
			var macines = player.GetAllMachineAround(VisibleMap, playerPos);
            foreach (var item in macines)
				player.TakeMachineResourses(item);

			var chests = player.GetAllChestAround(VisibleMap, playerPos);
			foreach (var item in chests)
				player.CommitResourseToChest(item);
		}
	}
}
