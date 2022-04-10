using System.Drawing;
using System.Windows.Forms;

namespace GameForIIP
{
	public class GameModell
	{
		public const int ElementSize = 100;
		public static Keys KeyPressed;
		public static Map Map { get; private set; }
		public static int LengthX { get => Map.LengthX; }
		public static int LengthY { get => Map.LengthY; }
		public static int MinLength { get => Map.MinLength; }

		public GameModell(Size WindowSize)
		{
			Map = MapCreator.Create();
		}
	}
}
