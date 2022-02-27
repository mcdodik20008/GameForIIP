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
		public MainWindow()
		{
			// Включает двойную буферизацию, чтобы изображение не мерцало при перерисовке.
			// В таком режиме OnPaint рисует не сразу на окне, а сначала на невидимой картинке (shadow buffer),
			// а потом одномоментно подменяет текущее изображение дорисованной картинкой.
			// Так окно не дорисованную картинку даже не показывает, что предотвращает мерцание.
			DoubleBuffered = true;
			ClientSize = new Size(600, 600);
			var centerX = ClientSize.Width / 2;
			var centerY = ClientSize.Height / 2;
			var size = 100;
			var radius = Math.Min(ClientSize.Width, ClientSize.Height) / 3;

			var time = 0;
			var timer = new Timer();
			timer.Interval = 500;
			timer.Tick += (sender, args) =>
			{
				time++;
				Invalidate();
			};
			timer.Start();

			Paint += (sender, args) =>
			{
				for (int i = 0; i <= time; i++)
				{
					args.Graphics.TranslateTransform(centerX, centerY);
					args.Graphics.RotateTransform(i * 360f / 10);
					args.Graphics.FillEllipse(Brushes.Blue, radius - size / 2, -size / 2, size, size);
					args.Graphics.ResetTransform();
				}
			};
		}
	}
}
