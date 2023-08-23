using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class Energy
    {
        public int energy = 0, consumers = 0;

        public Energy() { }

        public int GetClearEnergy()
        {
            if (consumers == 0)
                return 0;
            return energy / consumers;
        }
    }
}
