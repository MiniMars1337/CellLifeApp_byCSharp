using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    abstract class LifeCell : Cell, ICanDie
    {
        protected const int maxEnergyCapacity = 1000;
        protected const int energyDecreasement = 1;
        public int Energy { get; set; }

        public LifeCell(Cell cell, int givedEnergy) 
            : base(cell)
        { Energy = givedEnergy; }

        public override void UpdateCell()
        {
            base.UpdateCell();
            Energy -= energyDecreasement;
            if (Energy <= 0)
                Die();
            else if (!(this is RootCell) && Organic >= toxicLevel)
                Die();
            else if (!(this is AntenaCell) && Charge >= toxicLevel)
                Die();
        }
        public virtual void Die()
        {
            field.DelReferences(this, true);
            field.IncreaseToxic(this);
        }
    }
}
