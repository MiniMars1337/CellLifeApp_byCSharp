using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    class Cell
    {
        protected static Field field;
        public const int maxSunLevel = 16;
        public const int toxicLevel = 1000;
        public static readonly int averageCharge = 50, chargeRecoverySpeed = 2;

        public int PosX { get; protected set; }
        public int PosY { get; protected set; }
        public int Organic { get; protected set; }
        public int Charge { get; protected set; }
        public int SunLevel { get; protected set; }

        public Cell(int x, int y, int organic = 0, int charge = 0, int sunLevel = maxSunLevel)
        {
            field[x, y] = this;
            PosX = x;
            PosY = y;
            Organic = organic;
            Charge = charge;
            SunLevel = sunLevel;
        }
        public Cell(Cell cell)
            : this(cell.PosX, cell.PosY, cell.Organic, cell.Charge, cell.SunLevel) 
        { }

        public static void SetField(Field newField) => field = newField;
        public virtual void UpdateCell()
        {
            if (Charge <= averageCharge - chargeRecoverySpeed)
                Charge += chargeRecoverySpeed;
            else if (Charge >= averageCharge + chargeRecoverySpeed)
                Charge -= chargeRecoverySpeed;
        }
        public void AddOrganicAndCharge(int organic, int charge)
        {
            Organic += organic;
            Charge += charge;
        }
    }
}
