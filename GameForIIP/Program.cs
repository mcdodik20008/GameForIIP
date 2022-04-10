using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameForIIP
{
    static class Program
    {
        static void Main()
        {
            var clientSize = new Size(800, 600);
            var game = new GameModel(clientSize);
            Application.Run(new MainWindow(game) { 
                ClientSize = clientSize, 
                StartPosition = FormStartPosition.CenterScreen,
                MaximumSize = clientSize,
                MinimumSize = clientSize
            });
        }
    }
}
