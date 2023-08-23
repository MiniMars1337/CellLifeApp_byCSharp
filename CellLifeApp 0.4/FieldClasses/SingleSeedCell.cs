using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class SingleSeedCell : GeneticCell
    {
        public SingleSeedCell(Cell cell, int givedLife, Direct direct, int[] genCode, int ccp)
            : base(cell, givedLife, direct, genCode, ccp) 
        { }

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
                case 5:
                    result = Command_5_StepForward_SSeed();
                    break;
                case 6:
                    result = Command_6_TurnIntoHead_SSeed();
                    break;
                default:
                    result = Command_5_StepForward_SSeed();
                    break;
            }
            return result;
        }
        protected virtual bool Command_5_StepForward_SSeed()
        {
            Cell forwardCell = WhatNearby(Direction);
            if (forwardCell is LifeCell)
                field.IncreaseToxic(forwardCell);
            else
                new SingleSeedCell(forwardCell, Energy, Direction, geneticCode, CCP + 1);
            field.DelReferences(this, true);
            return true;
        }
        protected virtual bool Command_6_TurnIntoHead_SSeed()
        {
            field.DelReferences(this, false);
            new SingleHeadCell(this, Energy, Direction, geneticCode, 0);
            return true;
        }
    }
}
