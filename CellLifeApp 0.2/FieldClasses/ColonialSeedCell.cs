using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    class ColonialSeedCell : GeneticCell, IHaveContacts
    {
        public List<LifeCell> Contacts { get; }

        public ColonialSeedCell(Cell cell, int givedLife, Direct direct, int[] genCode, int ccp, List<LifeCell> tail = null)
            : base(cell, givedLife, direct, genCode, ccp) 
        { Contacts = tail != null ? tail : new List<LifeCell>(1); }
        public ColonialSeedCell(ColonialHeadCell cell)
            : this(cell, cell.Energy, cell.Direction, cell.geneticCode, cell.CCP + 1, cell.Contacts)
        { field.DelReferences(cell, false); }

        public override void GenerateEnergy()
        {
            if (Contacts.Count == 1)
            {
                Energy += ((WoodCell)Contacts[0]).GetEnergy();
                if (Energy > maxEnergyCapacity)
                    Energy = maxEnergyCapacity;
            }
        }
        public void DelRef(LifeCell cell)
        {
            if (Contacts.Contains(cell))
            {
                Contacts.Remove(cell);
                Command_10_TurnIntoAnotherType();
            }
        }
        protected override bool TryStep()
        {
            bool result;
            switch (geneticCode[CCP])
            {
                case 12:
                    result = Command_12_Wait();
                    break;
                case 7:
                    result = Command_7_CheckEnergy();
                    break;
                case 9:
                    result = Command_9_CheckConnection();
                    break;
                case 11:
                    result = Command_10_TurnIntoAnotherType();
                    break;
                default:
                    result = Command_Default();
                    break;
            }
            return result;
        }
        internal bool Command_10_TurnIntoAnotherType()
        {
            new SingleSeedCell(this);
            return true;
        }
    }
}
