using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System;

namespace GameForIIP
{
	public class GameModell
	{
		public const int ElementSize = 65;
		public const int SubMapSize = 12;
		public static int Score = 0;
		public static int ScorePlayer = 0;
		public static int ScoreChest = 0;
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

		static List<Keys> GoodButtons = new List<Keys>()
			{ Keys.P, Keys.G };
		public static void UpdateScore()
		{
			if (GoodButtons.Any(key => key == KeyPressed))
			{
				var playerPos = VisibleMap.FindPlayerPos();
				var player = VisibleMap[playerPos.X, playerPos.Y] as Player;
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

				ScorePlayer = player.Pocket;
				ScoreChest = chest != null ? chest.Resourses : ScoreChest; //тут ошибка, если 2 сундука, то сломатется
				Score = player.Pocket + ScoreChest;
			}
		}

        internal static void UpdateMachine()
        {
			var playerPos = VisibleMap.FindPlayerPos();
			var player = VisibleMap[playerPos.X, playerPos.Y] as Player;
			var machine = player.GetAllMachineAround(VisibleMap, playerPos).FirstOrDefault();
			switch (KeyPressed)
			{
				case Keys.U:
					if (machine != null)
						Map[machine.X, machine.Y] = machine.Update(player);
					break;
			}
			Machines = Map.GetAllMacine();
		}
    }
}
