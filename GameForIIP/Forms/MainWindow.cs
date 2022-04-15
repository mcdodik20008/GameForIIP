using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GameForIIP
{
    class MainWindow : Form
    {
        private readonly HashSet<Keys> pressedKeys = new HashSet<Keys>();
        private readonly DirectoryInfo imagesDirectory = null;
        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        int timerTick = 0;
        public static Timer timer = new Timer();

        public MainWindow()
        {
            DoubleBuffered = true;
            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo(@"..\..\Images");
            foreach (var e in imagesDirectory.GetFiles("*.png"))
                bitmaps[e.Name] = (Bitmap)Image.FromFile(e.FullName);

            timer.Interval = 100;
            timer.Tick += TimerTick;
            timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(
                Brushes.Black, 0, 0, GameModell.ElementSize * GameModell.Map.LengthX,
                GameModell.ElementSize * GameModell.Map.LengthY);

            var Position = new Point(0, GameModell.ElementSize);
            for (int x = 0; x < GameModell.SubMapSize; x++)
            {
                for (int y = 1; y < GameModell.SubMapSize + 1; y++)
                {
                    e.Graphics.DrawImage(bitmaps[GameModell.VisibleMap[x, y - 1].GetNameImage()], Position);
                    Position = new Point(Position.X + GameModell.ElementSize, Position.Y);
                }
                Position = new Point(0, Position.Y + GameModell.ElementSize);
            }
            e.Graphics.DrawString(GameModell.Score.All.ToString(), new Font("Arial", 32), Brushes.Gray, 0, GameModell.ElementSize / 3);
            e.Graphics.DrawString(GameModell.Score.Player.ToString(), new Font("Arial", 32), Brushes.White, GameModell.ElementSize, GameModell.ElementSize / 3);
            e.Graphics.DrawString(GameModell.Score.Chest.ToString(), new Font("Arial", 32), Brushes.Brown, GameModell.ElementSize * 2, GameModell.ElementSize / 3);
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
            GameModell.VisibleMap.GetSubMap(GameModell.Map, GameModell.Map.FindPlayerPos());
            GameModell.Map.Act();
            if (timerTick % 10 == 0)
                GameModell.MachineFarming();
            GameModell.UpdateScore();
            GameModell.Map.UpdateMachine();
            Invalidate();
            timerTick++;
        }
    }
}
