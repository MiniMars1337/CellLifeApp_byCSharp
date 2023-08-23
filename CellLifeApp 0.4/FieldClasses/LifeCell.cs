using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    abstract class LifeCell : Cell, ICanDie
    {
        public int Energy { get; set; }

        public LifeCell(Cell cell, int givedEnergy) 
            : base(cell)
        { Energy = givedEnergy; }

        public override void UpdateCell()
        {
            base.UpdateCell();
            Energy -= parameters.EnergyDecreasement;
            if (Energy <= 0)
                Die();
            else if (!(this is RootCell) && Organic >= parameters.ToxicLevel)
                Die();
            else if (!(this is AntenaCell) && Charge >= parameters.ToxicLevel)
                Die();
        }
        public virtual void Die()
        {
            field.DelReferences(this, true);
            field.IncreaseToxic(this);
        }
    }
}
