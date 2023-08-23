using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class ColonialHeadCell : GeneticCell, IHaveContacts
    {
        public List<LifeCell> Contacts { get; }

        public ColonialHeadCell(Cell cell, int givedLife, Direct direct, int[] genCode, int ccp, List<LifeCell> tail = null)
            : base(cell, givedLife, direct, genCode, ccp) 
        { Contacts = tail != null ? tail : new List<LifeCell>(1); }

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
        public void DelRef(LifeCell cell) => Contacts.Remove(cell);
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
                case 7:
                    result = Command_7_TurnIntoSeed_CHead();
                    break;
                case 9:
                    result = Command_9_CheckNearby();
                    break;
                case 10:
                    result = Command_10_CheckOrganic();
                    break;
                case 11:
                    result = Command_11_CheckCharge();
                    break;
                case 12:
                    result = Command_12_CheckSunLevel();
                    break;
                case 13:
                    result = Command_13_CheckEnergy();
                    break;
                default:
                    if (param0 > 13 && param0 < 75)
                    {
                        result = Commands_14to74_CreateBranches();
                        break;
                    }
                    result = Command_Default();
                    break;
            }
            return result;
        }
        protected virtual bool Command_7_TurnIntoSeed_CHead()
        {
            field.DelReferences(this, false);
            if (Contacts.Count != 0)
                ((WoodCell)Contacts[0]).Contacts.Add(new ColonialSeedCell(this));
            else
                CCP += 1;
            return true;
        }
    }
}
