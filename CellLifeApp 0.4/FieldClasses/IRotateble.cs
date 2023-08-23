using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    enum Direct
    {
        Up,
        Right,
        Down,
        Left,
    }
    interface IRotateble
    {
        Direct Direction { get; }
    }
}
