using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    class LeafletCell : LifeCell, IRotateble, ICanGenerateEnergy
    {
        public Direct Direction { get; }

        public LeafletCell(Cell cell, int givedLife, Direct direct) 
            : base(cell, givedLife) 
        { Direction = direct; }

        private Cell WhatNearby(Direct direct)
        {
            Cell cell;
            switch (direct)
            {
                case Direct.Up:
                    cell = field[PosX, PosY - 1];
                    break;
                case Direct.Right:
                    cell = field[PosX + 1, PosY];
                    break;
                case Direct.Down:
                    cell = field[PosX, PosY + 1];
                    break;
                case Direct.Left:
                    cell = field[PosX - 1, PosY];
                    break;
                default:
                    cell = new Cell(0, 0);
                    break;
            }
            return cell;
        }
        private Direct GetDirect(int a)
        {
            Direct direct;
            switch (a % 3)
            {
                case 0:
                    direct = (Direct)((4 + (int)Direction - 1) % 4);
                    break;
                case 2:
                    direct = (Direct)(((int)Direction + 1) % 4);
                    break;
                default:
                    direct = Direction;
                    break;
            }
            return direct;
        }
        public int GetEnergy()
        {
            int energy = SunLevel;
            int energyDecrease = SunLevel / 4;
            Cell neighbour;
            for (int i = 0; i < 3; i++)
            {
                neighbour = WhatNearby(GetDirect(i));
                if (neighbour is LifeCell)
                {
                    energy -= energyDecrease;
                    if (neighbour is LeafletCell)
                        return 0;
                }
            }
            return energy;
        }
        public int GetEnergyOld()
        {
            int energy = SunLevel;
            int energyDecrease = SunLevel / 8;

            Cell cell = field[PosX - 1, PosY - 1];
            if (cell is LifeCell)
            {
                energy -= energyDecrease;
                if (cell is LeafletCell)
                    return 0;
            }

            cell = field[PosX, PosY - 1];
            if (cell is LifeCell)
            {
                energy -= energyDecrease;
                if (cell is LeafletCell)
                    return 0;
            }

            cell = field[PosX + 1, PosY - 1];
            if (cell is LifeCell)
            {
                energy -= energyDecrease;
                if (cell is LeafletCell)
                    return 0;
            }

            cell = field[PosX - 1, PosY];
            if (cell is LifeCell)
            {
                energy -= energyDecrease;
                if (cell is LeafletCell)
                    return 0;
            }

            cell = field[PosX + 1, PosY];
            if (cell is LifeCell)
            {
                energy -= energyDecrease;
                if (cell is LeafletCell)
                    return 0;
            }

            cell = field[PosX - 1, PosY + 1];
            if (cell is LifeCell)
            {
                energy -= energyDecrease;
                if (cell is LeafletCell)
                    return 0;
            }

            cell = field[PosX, PosY + 1];
            if (cell is LifeCell)
            {
                energy -= energyDecrease;
                if (cell is LeafletCell)
                    return 0;
            }

            cell = field[PosX + 1, PosY + 1];
            if (cell is LifeCell)
            {
                energy -= energyDecrease;
                if (cell is LeafletCell)
                    return 0;
            }

            return energy;
        }
    }
}
