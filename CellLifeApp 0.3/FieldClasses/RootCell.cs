using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    class RootCell : LifeCell, IRotateble, ICanGenerateEnergy
    {
        public Direct Direction { get; }
        private static int maxOrganicExtraction = 2;

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
