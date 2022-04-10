using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GameForIIP
{
	class MainWindow : Form
	{
		GameModel game;
		TableLayoutPanel table;
		private int tickCount;
		private readonly HashSet<Keys> pressedKeys = new HashSet<Keys>();

		public MainWindow(GameModel game)
		{
			//BackColor = Color.Black;
			
			this.game = game;
			table = new TableLayoutPanel();
			for (int i = 0; i < game.LengthX; i++)
				table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / game.LengthX));

			for (int i = 0; i < game.LengthY; i++)
				table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / game.LengthY));

			var timer = new Timer();
			timer.Interval = 15;
			timer.Tick += TimerTick;
			timer.Start();

		}
		static Dictionary<MapCell, Brush> MapCellToBrush = new Dictionary<MapCell, Brush>()
		{
			[MapCell.EndMap] = Brushes.Black,
			[MapCell.Foolr] = Brushes.Blue,
			[MapCell.Player] = Brushes.Green,
			[MapCell.Wall] = Brushes.Brown,
			[MapCell.Null] = null
		};
        protected override void OnPaint(PaintEventArgs e)
        {
			var graphics = e.Graphics;
			var Position = new Point(0, 0);
			for (int x = 0; x < game.LengthX; x++)
			{
				for (int y = 0; y < game.LengthY; y++)
				{
					if (MapCellToBrush[GameModel.Map[x, y]] != null)
						graphics.FillRectangle(MapCellToBrush[GameModel.Map[x, y]], new Rectangle(Position, game.SizeCell));
					Position = new Point(Position.X + game.SizeCell.Width, Position.Y);
				}
				Position = new Point(0, Position.Y + game.SizeCell.Height);
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			pressedKeys.Add(e.KeyCode);
			GameModel.KeyPressed = e.KeyCode;
		}

		private void TimerTick(object sender, EventArgs args)
		{

		}
	}
}
