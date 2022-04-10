using System.Drawing;
using System.Windows.Forms;

namespace GameForIIP
{
	public class GameModel
	{
		public static Keys KeyPressed;
		public static Map Map { get; private set; }
		public readonly Size SizeCell;
		public int LengthX { get => Map.LengthX; }
		public int LengthY { get => Map.LengthY; }
		public int MinLength { get => Map.MinLength; }

		public GameModel(Size WindowSize)
		{
			Map = MapCreator.Create();
			SizeCell = new Size(WindowSize.Width / Map.LengthX, WindowSize.Height / Map.LengthY);
		}
	}
}
