using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class ColonialSeedCell : GeneticCell, IHaveContacts
    {
        public List<LifeCell> Contacts { get; }

        public ColonialSeedCell(ColonialHeadCell cell)
            : base(cell, cell.Energy, cell.Direction, cell.geneticCode, cell.CCP + 1)
        { Contacts = cell.Contacts; }

        public override void DoStep()
        {
            if (Contacts.Count == 1)
            {
                Energy += ((WoodCell)Contacts[0]).GetEnergy();
                if (Energy > parameters.MaxEnergyCapacity)
                    Energy = parameters.MaxEnergyCapacity;
            }
            base.DoStep();
        }
        public void DelRef(LifeCell cell)
        {
            if (Contacts.Contains(cell))
            {
                Contacts.Remove(cell);
                field.DelReferences(this, false);
                new SingleHeadCell(this, Energy, Direction, geneticCode, 0);
            }
        }
        protected override bool TryStep()
        {
            bool result;
            int param0 = geneticCode[CCP];
            switch (param0)
            {
                case 0:
                    result = Command_0_CCPplus1();
                    break;
                case 1:
                    result = Command_1_CCPincrease();
                    break;
                case 2:
                    result = Command_2_Wait();
                    break;
                case 8:
                    result = Command_8_ShootSeed_CSeed();
                    break;
                case 13:
                    result = Command_13_CheckEnergy();
                    break;
                default:
                    result = Command_2_Wait();
                    break;
            }
            return result;
        }
        protected virtual bool Command_8_ShootSeed_CSeed()
        {
            new SingleSeedCell(this, Energy, Direction, geneticCode, CCP + 1);
            field.DelReferences(this, false);
            return true;
        }
    }
}
