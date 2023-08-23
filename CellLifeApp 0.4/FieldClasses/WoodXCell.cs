using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class WoodXCell : WoodCell
    {

        public WoodXCell(GeneticCell cell, List<LifeCell> contacts)
            : base(cell, contacts) { }
    }
}
