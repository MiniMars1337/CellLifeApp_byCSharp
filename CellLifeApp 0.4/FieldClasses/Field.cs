using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    class Field
    {
        private Cell[,] field;
        private HashSet<GeneticCell> geneticCells = new HashSet<GeneticCell>();
        internal HashSet<GeneticCell> removeList = new HashSet<GeneticCell>();
        internal HashSet<GeneticCell> addList = new HashSet<GeneticCell>();
        private Random random = new Random();
        public CellParameters Parameters { get; private set; }
        public int Generation { get; set; }
        public int Cols { get; private set; }
        public int Rows { get; private set; }
        public int GeneticCellCount { get { return geneticCells.Count; } }
        public Cell this[int x, int y]
        {
            get 
            {
                if (Cols == 0 || Rows == 0)
                    return null;
                x %= Cols;
                y %= Rows;
                if (x < 0)
                    x += Cols;
                if (y < 0)
                    y += Rows;
                return field[x, y]; 
            }
            set
            {
                if (Cols == 0 || Rows == 0)
                    return;
                x %= Cols;
                y %= Rows;
                if (x < 0)
                    x += Cols;
                if (y < 0)
                    y += Rows;
                field[x, y] = value; 
            }
        }

        public Field(CellParameters parameters)
        {
            Parameters = parameters;
            Cell.field = this;
            TestPattern();
        }

        private void SetFieldSize(int rows, int cols)
        {
            Cols = cols;
            Rows = rows;
            field = new Cell[cols, rows];
        }
        public void SetClearField()
        {
            for (int x = 0; x < Cols; x++)
                for (int y = 0; y < Rows; y++)
                    field[x, y] = new Cell(x, y);
            geneticCells.Clear();
            removeList.Clear();
            addList.Clear();
            GeneticCell.AllMutations = 0;
            Generation = 0;
        }
        public void DelReferences(LifeCell cell, bool shouldSetNewCell)
        {
            Cell neighbour = this[cell.PosX - 1, cell.PosY];
            if (neighbour is IHaveContacts)
                ((IHaveContacts)neighbour).DelRef(cell);
            neighbour = this[cell.PosX, cell.PosY + 1];
            if (neighbour is IHaveContacts)
                ((IHaveContacts)neighbour).DelRef(cell);
            neighbour = this[cell.PosX + 1, cell.PosY];
            if (neighbour is IHaveContacts)
                ((IHaveContacts)neighbour).DelRef(cell);
            neighbour = this[cell.PosX, cell.PosY - 1];
            if (neighbour is IHaveContacts)
                ((IHaveContacts)neighbour).DelRef(cell);

            if (cell is GeneticCell)
                removeList.Add((GeneticCell)cell);

            if (shouldSetNewCell)
                new Cell(cell);
        }
        public void IncreaseToxic(Cell cell)
        {
            this[cell.PosX - 1, cell.PosY - 1].AddOrganicAndCharge(Parameters.OrganicIncrease, Parameters.ChargeIncrease);
            this[cell.PosX, cell.PosY - 1].AddOrganicAndCharge(Parameters.OrganicIncrease, Parameters.ChargeIncrease);
            this[cell.PosX + 1, cell.PosY - 1].AddOrganicAndCharge(Parameters.OrganicIncrease, Parameters.ChargeIncrease);
            this[cell.PosX - 1, cell.PosY].AddOrganicAndCharge(Parameters.OrganicIncrease, Parameters.ChargeIncrease);
            this[cell.PosX, cell.PosY].AddOrganicAndCharge(Parameters.OrganicIncrease, Parameters.ChargeIncrease);
            this[cell.PosX + 1, cell.PosY].AddOrganicAndCharge(Parameters.OrganicIncrease, Parameters.ChargeIncrease);
            this[cell.PosX - 1, cell.PosY + 1].AddOrganicAndCharge(Parameters.OrganicIncrease, Parameters.ChargeIncrease);
            this[cell.PosX, cell.PosY + 1].AddOrganicAndCharge(Parameters.OrganicIncrease, Parameters.ChargeIncrease);
            this[cell.PosX + 1, cell.PosY + 1].AddOrganicAndCharge(Parameters.OrganicIncrease, Parameters.ChargeIncrease);
        }
        public void UpdateField()
        {
            foreach (Cell cell in field)
                cell.UpdateCell();
            foreach (GeneticCell cell in geneticCells)
                if (!removeList.Contains(cell))
                    addList.Add(cell);
            geneticCells = addList;
            addList = new HashSet<GeneticCell>();
            removeList.Clear();
            foreach (GeneticCell cell in geneticCells)
                cell.DoStep();
            Generation++;
        }
        public void TestPattern() => TestPattern1();
        public void TestPattern1()
        {
            SetFieldSize(200, 200);
            SetClearField();
            var sectorSize = new Size(100, 100);
            var sectors = new Point(2, 2);
            for (int x = 1; x < sectors.X + 1; x++)
                for (int y = 1; y < sectors.Y + 1; y++)
                    SetSectorWalls(sectorSize, new Point(x, y));
            var cellRate = 10;
            var startEnergy = 500;
            int[] genCode;
            for (int x = 2; x < Cols; x += cellRate)
            {
                for (int y = 2; y < Rows; y += cellRate)
                {
                    genCode = new int[100];
                    for (int i = 0; i < genCode.Length; i++)
                    {
                        genCode[i] = random.Next(1, Parameters.MaxGenCodeValue);
                    }
                    geneticCells.Add(new SingleHeadCell(field[x, y], startEnergy, (Direct)random.Next(4), genCode, 0));
                }
            }
            addList.Clear();
        }
        public void SetWalls()
        {
            for (int x = 0; x < Cols; x++)
            {
                new Cell(x, 0, 11000, 0);
                new Cell(x, Rows-1, 11000, 0);
            }
            for (int y = 0; y < Rows; y++)
            {
                new Cell(0, y, 11000, 0);
                new Cell(Cols-1, y, 11000, 0);
            }
        }
        public void SetSectorWalls(Size sectorSize, Point sectorPos)
        {
            for (int x = 0; x < sectorSize.Width; x++)
            {
                new Cell(x, sectorSize.Height * (sectorPos.Y - 1), 11000);
                new Cell(x, sectorSize.Height * sectorPos.Y - 1, 11000);
            }
            for (int y = 0; y < sectorSize.Height; y++)
            {
                new Cell(sectorSize.Width * (sectorPos.X - 1), y, 11000);
                new Cell(sectorSize.Width * sectorPos.X - 1, y, 11000);
            }
        }
    }
}
