using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    public interface IPeople : IObject
    {
        bool DeadInConflict(IPeople conflictedObject);
        IObject Shoot();
        Point Move();
    }
}
