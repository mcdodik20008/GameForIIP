using System.Drawing;
using System.Windows.Forms;

namespace GameForIIP
{
    static class Program
    {
        static void Main()
        {
            var clientSize = new Size(800, 850);
            new GameModell(clientSize);
            Application.Run(new MainWindow()
            {
                ClientSize = clientSize,
                StartPosition = FormStartPosition.CenterScreen,
                MaximumSize = clientSize,
                MinimumSize = clientSize
            });
        }
    }
}
