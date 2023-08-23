using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class SingleHeadCell : GeneticCell
    {
        internal static int organicEating;

        public SingleHeadCell(Cell cell, int givedLife, Direct direct, int[] genCode, int ccp) 
            : base(cell, givedLife, direct, genCode, ccp) { }

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
                case 3:
                    result = Command_3_StepForward_SHead();
                    break;
                case 4:
                    result = Command_4_Turn_SHead();
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
                case 75:
                    result = Command_75_EatOrganic();
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
        protected virtual bool Command_3_StepForward_SHead()
        {
            Cell forwardCell = WhatNearby(Direction);
            int eatedEnergy = EatCell(forwardCell);
            if (eatedEnergy != int.MinValue)
                new SingleHeadCell(forwardCell, Energy + eatedEnergy, Direction, geneticCode, CCP + 1);
            else
                field.IncreaseToxic(forwardCell);
            field.DelReferences(this, true);
            return true;
        }
        protected virtual bool Command_4_Turn_SHead()
        {
            switch (Parametr(1) % 2)
            {
                case 0:
                    Direction = (Direct)((4 + (int)Direction - 1) % 4);
                    break;
                case 1:
                    Direction = (Direct)(((int)Direction + 1) % 4);
                    break;
            }
            CCP += 2;
            return true;
        }
        protected virtual bool Command_75_EatOrganic()
        {
            if (Organic > organicEating)
            {
                Organic -= organicEating;
                Energy += organicEating;
            }
            else
            {
                Energy += Organic;
                Organic = 0;
            }
            return true;
        }
    }
}
