using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace GameForIIP
{
	class MainWindow : Form
	{
		private readonly HashSet<Keys> pressedKeys = new HashSet<Keys>();
		DirectoryInfo imagesDirectory = null;
		Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
		Animations gameState;
		int tickCount = 0;
		public MainWindow()
		{
			DoubleBuffered = true;
			gameState = new Animations();
			if (imagesDirectory == null)
				imagesDirectory = new DirectoryInfo(@"C:\Users\Админ\source\repos\GameForIIP\GameForIIP\Imajes");
			foreach (var e in imagesDirectory.GetFiles("*.png"))
				bitmaps[e.Name] = (Bitmap)Image.FromFile(e.FullName);

			var timer = new Timer();
			timer.Interval = 1000/8;
			timer.Tick += TimerTick;
			timer.Start();
		}

        protected override void OnPaint(PaintEventArgs e)
        {
			e.Graphics.FillRectangle(
				Brushes.Black, 0, 0, GameModell.ElementSize * GameModell.Map.LengthX,
				GameModell.ElementSize * GameModell.Map.LengthY);

			var Position = new Point(0, 0);
			for (int x = 0; x < GameModell.LengthX; x++)
			{
				for (int y = 0; y < GameModell.LengthY; y++)
				{
					e.Graphics.DrawImage(bitmaps[GameModell.Map[x,y].GetNameImage()], Position);
					Position = new Point(Position.X + GameModell.ElementSize, Position.Y);
				}
				Position = new Point(0, Position.Y + GameModell.ElementSize);
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			pressedKeys.Add(e.KeyCode);
			GameModell.KeyPressed = e.KeyCode;
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			pressedKeys.Remove(e.KeyCode);
			GameModell.KeyPressed = pressedKeys.Any() ? pressedKeys.Min() : Keys.None;
		}

		private void TimerTick(object sender, EventArgs args)
		{
			if (tickCount == 0) gameState.BeginAct();
			if (tickCount == 7)
				gameState.EndAct();
			tickCount++;
			if (tickCount == 8) 
				tickCount = 0;
			Invalidate();
		}
	}
}
