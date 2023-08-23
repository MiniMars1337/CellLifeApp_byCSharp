using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class Cell
    {
        internal static Field field;
        internal static CellParameters parameters;

        public int PosX { get; protected set; }
        public int PosY { get; protected set; }
        public int Organic { get; internal set; }
        public int Charge { get; internal set; }
        public int SunLevel { get; internal set; }

        public Cell(int x, int y, int organic = 0, int charge = 0, int sunLevel = -1)
        {
            field[x, y] = this;
            PosX = x;
            PosY = y;
            Organic = organic;
            Charge = charge;
            if (sunLevel < 0 || sunLevel > parameters.MaxSunLevel)
                SunLevel = parameters.MaxSunLevel;
            else
                SunLevel = sunLevel;
        }
        public Cell(Cell cell)
            : this(cell.PosX, cell.PosY, cell.Organic, cell.Charge, cell.SunLevel) 
        { }

        public virtual void UpdateCell()
        {
            if (Charge <= parameters.AverageCharge - parameters.ChargeRecoverySpeed)
                Charge += parameters.ChargeRecoverySpeed;
            else if (Charge >= parameters.AverageCharge + parameters.ChargeRecoverySpeed)
                Charge -= parameters.ChargeRecoverySpeed;
        }
        public void AddOrganicAndCharge(int organic, int charge)
        {
            Organic += organic;
            Charge += charge;
        }
        protected Cell WhatNearby(Direct direct)
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
        protected static Direct GetDirect(Direct cellDirect, int a)
        {
            Direct direct;
            switch (a % 3)
            {
                case 0:
                    direct = (Direct)((4 + (int)cellDirect - 1) % 4);
                    break;
                case 2:
                    direct = (Direct)(((int)cellDirect + 1) % 4);
                    break;
                default:
                    direct = cellDirect;
                    break;
            }
            return direct;
        }
    }
}
