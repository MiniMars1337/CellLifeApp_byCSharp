using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    class SingleSeedCell : GeneticCell
    {
        public SingleSeedCell(Cell cell, int givedLife, Direct direct, int[] genCode, int ccp)
            : base(cell, givedLife, direct, genCode, ccp) 
        { }
        public SingleSeedCell(ColonialSeedCell cell)
            : base(cell, cell.Energy, cell.Direction, cell.geneticCode, cell.CCP + 1) 
        { field.DelReferences(cell, false); }

        protected override bool TryStep()
        {
            bool result;
            switch (geneticCode[CCP])
            {
                case 12:
                    result = Command_12_Wait();
                    break;
                case 1:
                    result = Command_1_StepForward();
                    break;
                case 7:
                    result = Command_7_CheckEnergy();
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
        protected bool Command_1_StepForward()
        {
            Cell forwardCell = WhatNearby(Direction);
            if (forwardCell is LifeCell)
                field.IncreaseToxic(forwardCell);
            else
                new SingleSeedCell(forwardCell, Energy, Direction, geneticCode, CCP + 1);
            field.DelReferences(this, true);
            return true;
        }
        protected bool Command_10_TurnIntoAnotherType()
        {
            field.DelReferences(this, false);
            new SingleHeadCell(this);
            return true;
        }
    }
}
