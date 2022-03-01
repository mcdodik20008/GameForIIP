using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameForIIP
{
    public static class Game
    {
        private const string firstMap = @"
P   
 P  
  P 
   P";

        public static IObject[,] Map;
        public static int Scores;
        public static bool IsOver;

        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);

        public static void CreateMap()
        {
            Map = MapCreator.CreateMap(firstMap);
        }
    }
}
