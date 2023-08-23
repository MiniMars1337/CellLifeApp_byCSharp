using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class AntenaCell : LifeCell, IRotateble, ICanGenerateEnergy
    {
        public Direct Direction { get; }
        internal static int maxChargeExtraction;

        public AntenaCell(Cell cell, int givedLife, Direct direct) 
            : base(cell, givedLife) 
        { Direction = direct; }

        public int GetEnergy()
        {
            if (Charge >= maxChargeExtraction)
            {
                Charge -= maxChargeExtraction;
                return maxChargeExtraction;
            }
            int energy = Charge;
            Charge = 0;
            return energy;
        }
    }
}
