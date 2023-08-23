using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    class SingleHeadCell : GeneticCell
    {
        public const int organicEatingConst = 10;

        public SingleHeadCell(Cell cell, int givedLife, Direct direct, int[] genCode, int ccp) 
            : base(cell, givedLife, direct, genCode, ccp) { }
        public SingleHeadCell(SingleSeedCell cell)
            : base(cell, cell.Energy, cell.Direction, cell.geneticCode, 0)
        { field.DelReferences(cell, false); }

        public override void GenerateEnergy()
        {
            if (Organic > organicEatingConst)
            {
                Organic -= organicEatingConst;
                Energy += organicEatingConst;
            }
            else
            {
                Energy += Organic;
                Organic = 0;
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
                case 1:
                    result = Command_1_StepForward();
                    break;
                case 2:
                    result = Command_2_Turn();
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
                default:
                    result = Command_Default();
                    break;
            }
            return result;
        }
        protected bool Command_1_StepForward()
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
        protected bool Command_2_Turn()
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
    }
}
