using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    public interface IObject
    {
        string GetImageFileName();
        int GetDrawingPriority();
    }
}
