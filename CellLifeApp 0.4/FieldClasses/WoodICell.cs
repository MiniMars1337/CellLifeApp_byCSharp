using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class WoodICell : WoodCell, IRotateble
    {
        public Direct Direction { get; }

        public WoodICell(GeneticCell cell, List<LifeCell> contacts, Direct direct) 
            : base(cell, contacts) 
        { Direction = direct; }
    }
}
