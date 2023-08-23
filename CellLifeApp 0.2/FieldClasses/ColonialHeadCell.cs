using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    class ColonialHeadCell : GeneticCell, IHaveContacts
    {
        public List<LifeCell> Contacts { get; }

        public ColonialHeadCell(Cell cell, int givedLife, Direct direct, int[] genCode, int ccp, List<LifeCell> tail = null)
            : base(cell, givedLife, direct, genCode, ccp) 
        { Contacts = tail != null ? tail : new List<LifeCell>(1); }

        public override void GenerateEnergy()
        {
            if (Contacts.Count == 1)
            {
                Energy += ((WoodCell)Contacts[0]).GetEnergy();
                if (Energy > maxEnergyCapacity)
                    Energy = maxEnergyCapacity;
            }
        }
        public void DelRef(LifeCell cell) => Contacts.Remove(cell);
        protected override bool TryStep()
        {
            bool result;
            switch (geneticCode[CCP])
            {
                case 12:
                    result = Command_12_Wait();
                    break;
                case 3:
                    result = Command_3_CheckNearby();
                    break;
                case 4:
                    result = Command_4_CheckOrganic();
                    break;
                case 5:
                    result = Command_5_CheckCharge();
                    break;
                case 6:
                    result = Command_6_CheckSunLevel();
                    break;
                case 7:
                    result = Command_7_CheckEnergy();
                    break;
                case 8:
                    result = Command_8_CreateBranches();
                    break;
                case 9:
                    result = Command_9_CheckConnection();
                    break;
                case 10:
                    result = Command_10_TurnIntoAnotherType();
                    break;
                default:
                    result = Command_Default();
                    break;
            }
            return result;
        }
        protected bool Command_10_TurnIntoAnotherType()
        {
            ColonialSeedCell cell = new ColonialSeedCell(this);
            if (Contacts.Count == 1)
                ((WoodCell)Contacts[0]).Contacts.Add(cell);
            return true;
        }
    }
}
