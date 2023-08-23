using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class LeafletCell : LifeCell, IRotateble, ICanGenerateEnergy
    {
        public Direct Direction { get; }

        public LeafletCell(Cell cell, int givedLife, Direct direct) 
            : base(cell, givedLife) 
        { Direction = direct; }

        public int GetEnergy()
        {
            int energy = SunLevel;
            int energyDecrease = SunLevel / 4;
            Cell neighbour;
            for (int i = 0; i < 3; i++)
            {
                neighbour = WhatNearby(GetDirect(Direction, i));
                if (neighbour is LifeCell)
                {
                    energy -= energyDecrease;
                    if (neighbour is LeafletCell)
                        return 0;
                }
            }
            return energy;
        }
    }
}
