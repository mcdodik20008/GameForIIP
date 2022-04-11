using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    public static class Animations
    {     
        public static void Act(this Map map)
        {
            var t = map.FindPlayerPos();
            map.SwapElementOnMap(t.X, t.Y);   
        }
    }
}
