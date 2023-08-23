using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    abstract class WoodCell : LifeCell, IHaveContacts, ICanGenerateEnergy
    {
        public List<LifeCell> Contacts { get; set; }
        private bool isEnergyGenerated = false;
        private Energy generatedEnergy;

        public WoodCell(GeneticCell cell, List<LifeCell> contacts) 
            : base(cell, cell.Energy)
        { 
            field.DelReferences(cell, false); 
            Contacts = contacts; 
        }

        public override void UpdateCell()
        {
            base.UpdateCell();
            isEnergyGenerated = false;
        }
        public int GetEnergy()
        {
            if (isEnergyGenerated)
                return generatedEnergy.GetClearEnergy();
            generatedEnergy = new Energy();
            foreach (var cell in Contacts)
            {
                if (cell is WoodCell)
                    ((WoodCell)cell).GetEnergy(this);
                else if (cell is ICanGenerateEnergy)
                    generatedEnergy.energy += ((ICanGenerateEnergy)cell).GetEnergy();
                else
                    generatedEnergy.consumers++;
            }
            SetEnergy(this);
            return generatedEnergy.GetClearEnergy();
        }
        internal void GetEnergy(WoodCell consumer)
        {
            generatedEnergy = consumer.generatedEnergy;
            foreach (var cell in Contacts)
            {
                if (cell.Equals(consumer))
                    continue;
                else if (cell is WoodCell)
                    ((WoodCell)cell).GetEnergy(this);
                else if (cell is ICanGenerateEnergy)
                    generatedEnergy.energy += ((ICanGenerateEnergy)cell).GetEnergy();
                else
                    generatedEnergy.consumers++;
            }
        }
        internal void SetEnergy(WoodCell setter)
        {
            generatedEnergy = setter.generatedEnergy;
            isEnergyGenerated = true;
            foreach (var cell in Contacts)
            {
                if (cell == null || cell.Equals(setter))
                    continue;
                else if (cell is WoodCell)
                    ((WoodCell)cell).SetEnergy(this);
            }
        }
        public void DelRef(LifeCell cell) => Contacts.Remove(cell);
    }
}
