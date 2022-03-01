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
			timer.Interval = 1;
			timer.Tick += (sender, args) =>
			{
				time++;
				Invalidate();
			};
			timer.Start();

			Paint += (sender, args) =>
			{
				args.Graphics.FillRectangle(Brushes.Blue, Width - time, 0, size, size+100);
				args.Graphics.FillRectangle(Brushes.Blue, Width - time, Height - 300, size, size + 200);
				args.Graphics.ResetTransform();
			};
		}
	}
}
