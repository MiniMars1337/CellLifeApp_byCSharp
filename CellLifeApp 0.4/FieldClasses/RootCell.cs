using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class RootCell : LifeCell, IRotateble, ICanGenerateEnergy
    {
        public Direct Direction { get; }
        internal static int maxOrganicExtraction;

        public RootCell(Cell cell, int givedLife, Direct direct) 
            : base(cell, givedLife) 
        { Direction = direct; }

        public int GetEnergy()
        {
            if (Organic > maxOrganicExtraction)
            {
                Organic -= maxOrganicExtraction;
                return maxOrganicExtraction;
            }
            int energy = Organic;
            Organic = 0;
            return energy;
        }
    }
}
