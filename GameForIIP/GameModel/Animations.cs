using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameForIIP
{
    public static class Animations
    {     
        public static void Act(this Map map, HashSet<Keys> keys)
        {
            var t = map.FindPlayerPos();
            map.SwapElementOnMap(t.X, t.Y);   
        }

		public static void UpdateMachine(this Map map, HashSet<Keys> keys)
		{
			var playerPos = GameModell.VisibleMap.FindPlayerPos();
			var player = GameModell.VisibleMap[playerPos.X, playerPos.Y] as Player;
			var machine = player.GetAllMachineAround(GameModell.VisibleMap, playerPos).FirstOrDefault();
			switch (GameModell.KeyPressed)
			{
				case Keys.U:
					if (machine != null)
						GameModell.Map[machine.X, machine.Y] = machine.Update(player);
					break;
			}
			GameModell.Machines = GameModell.Map.GetAllMacine();
		}

		public static void Openshop(this Map map, HashSet<Keys> keys)
		{
			foreach (var item in keys)
			{
				switch (item)
				{
					case Keys.O:
						MainWindow.timer.Stop();
						new Shop().ShowDialog();
						MainWindow.timer.Start();
						break;
				}
			}
		}
	}
}
