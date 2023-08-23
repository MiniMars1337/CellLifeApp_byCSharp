using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace CellLifeApp.FieldClasses
{
    class Field
    {
        private Cell[,] field;
        public List<GeneticCell> geneticCells = new List<GeneticCell>();
        private const int organicIncreaseConst = 2, chargeIncreaseConst = 2;
        public int Cols { get; private set; }
        public int Rows { get; private set; }
        public Cell this[int x, int y]
        {
            get 
            {
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
                x %= Cols;
                y %= Rows;
                if (x < 0)
                    x += Cols;
                if (y < 0)
                    y += Rows;
                field[x, y] = value; 
            }
        }
        public GeneticCell this[int i]
        {
            get { return geneticCells[i]; }
            set { geneticCells[i] = value; }
        }
        internal List<GeneticCell> removeList = new List<GeneticCell>();
        internal List<GeneticCell> addList = new List<GeneticCell>();
        private Random random = new Random();

        public Field() { Cell.SetField(this); }

        public void SetFieldSize(int cols, int rows)
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
            this[cell.PosX - 1, cell.PosY - 1].AddOrganicAndCharge(organicIncreaseConst, chargeIncreaseConst);
            this[cell.PosX, cell.PosY - 1].AddOrganicAndCharge(organicIncreaseConst, chargeIncreaseConst);
            this[cell.PosX + 1, cell.PosY - 1].AddOrganicAndCharge(organicIncreaseConst, chargeIncreaseConst);
            this[cell.PosX - 1, cell.PosY].AddOrganicAndCharge(organicIncreaseConst, chargeIncreaseConst);
            this[cell.PosX, cell.PosY].AddOrganicAndCharge(organicIncreaseConst, chargeIncreaseConst);
            this[cell.PosX + 1, cell.PosY].AddOrganicAndCharge(organicIncreaseConst, chargeIncreaseConst);
            this[cell.PosX - 1, cell.PosY + 1].AddOrganicAndCharge(organicIncreaseConst, chargeIncreaseConst);
            this[cell.PosX, cell.PosY + 1].AddOrganicAndCharge(organicIncreaseConst, chargeIncreaseConst);
            this[cell.PosX + 1, cell.PosY + 1].AddOrganicAndCharge(organicIncreaseConst, chargeIncreaseConst);
        }
        public void UpdateField()
        {
            foreach (GeneticCell cell in geneticCells)
                cell.DoStep();
            foreach (GeneticCell cell in geneticCells)
                if (!removeList.Contains(cell))
                    addList.Add(cell);
            geneticCells = addList;
            addList = new List<GeneticCell>();
            removeList.Clear();
            foreach (GeneticCell cell in geneticCells)
                cell.GenerateEnergy();
            foreach (Cell cell in field)
                cell.UpdateCell();
        }
        public void TestPattern() => TestPattern3();
        public void TestPattern0()
        {
            SetFieldSize(100, 100);
            SetClearField();
            SingleHeadCell cell;
            int startEnergy = 200;
            GeneticCell.isMutationEnabled = false;

            int[] genCode = new int[]
            {
                12,7,99,1,26,7,18,63,1,8,
                2,3,2,18,99,2,99,12,7,6,
                67,1,8,5,3,5,6,99,43,99,
                8,3,3,3,20,1,17,1,8,5,
                3,5,20,99,1,99,8,2,3,2,
                60,99,56,99,7,40,9,1,8,5,
                3,5,30,99,60,99,12,7,99,67,31
            };

            //int[] genCode = new int[100];
            //for (int i = 0; i < genCode.Length; i++)
            //{
            //    genCode[i] = random.Next(1, GeneticCell.maxGenCodeValue + 1);
            //    //if (i % 7 == 0) { genCode[i] = 8; }
            //}

            cell = new SingleHeadCell(field[50, 50], startEnergy, (Direct)random.Next(4), genCode, 0);
            geneticCells.Add(cell);
            addList.Clear();
            //SetWalls();
        }
        public void TestPattern1()
        {
            SetFieldSize(100, 100);
            SetClearField();
            SingleHeadCell cell;
            int[] genCode = new int[300];
            int cellRate = 10;
            int startEnergy = 700;

            for (int i = 0; i < genCode.Length; i++)
            {
                if (random.Next() % 2 == 0)
                    genCode[i] = random.Next(1, 20);
                else
                    genCode[i] = random.Next(1, GeneticCell.maxGenCodeValue + 1);
                if (i % 7 == 0) { genCode[i] = 8; }
            }

            for (int x = 1; x < Cols; x += cellRate)
            {
                for (int y = 1; y < Rows; y += cellRate)
                {
                    for (int i = 0; i < genCode.Length; i++)
                    {
                        if (random.Next() % 2 == 0)
                            genCode[i] = random.Next(1, GeneticCell.maxGenCodeValue + 1);
                    }
                    cell = new SingleHeadCell(field[x, y], startEnergy, (Direct)random.Next(4), genCode, 0);
                    geneticCells.Add(cell);
                    Thread.Sleep(1);
                }
            }
            addList.Clear();
            SetWalls();
        }
        public void TestPattern2()
        {
            SetFieldSize(100, 10000);
            SetClearField();
            int[] genCode = new int[1000];
            int cellRate = 10;
            int startEnergy = 1000;

            //for (int i = 0; i < genCode.Length; i++)
            //{
            //    if (random.Next() % 2 == 0)
            //        genCode[i] = random.Next(1, 20);
            //    else
            //        genCode[i] = random.Next(1, GeneticCell.maxGenCodeValue + 1);
            //    if (i % 7 == 0) { genCode[i] = 8; }
            //}

            for (int x = 1; x < Cols; x += cellRate)
            {
                for (int y = 1; y < Rows; y += cellRate)
                {
                    for (int i = 0; i < genCode.Length; i++)
                    {
                        genCode[i] = random.Next(1, GeneticCell.maxGenCodeValue);
                    }
                    geneticCells.Add(new SingleHeadCell(field[x, y], startEnergy, (Direct)random.Next(4), genCode, 0));
                    //Thread.Sleep(10);
                }
            }
            addList.Clear();
        }
        public void TestPattern3()
        {
            Size sectorSize = new Size(100, 100);
            Point sectorCount = new Point(1, 1);
            SetFieldSize(sectorSize.Width * sectorCount.X, sectorSize.Height * sectorCount.Y);
            SetClearField();
            SetSectorWalls(sectorSize, new Point(1, 1));

            int[] genCode = new int[100];
            int cellRate = 10;
            int startEnergy = 1000;
            GeneticCell.isMutationEnabled = true;

            for (int x = 1; x < Cols; x += cellRate)
            {
                for (int y = 1; y < Rows; y += cellRate)
                {
                    Thread.Sleep(1);
                    random = new Random();
                    for (int i = 0; i < genCode.Length; i++)
                    {
                        genCode[i] = random.Next(1, 20);
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
                field[x, 0] = new Cell(x,0,11000,0);
                field[x, Rows-1] = new Cell(x, Rows-1, 11000, 0);
            }
            for (int y = 0; y < Rows; y++)
            {
                field[0, y] = new Cell(0, y, 11000, 0);
                field[Cols-1, y] = new Cell(Cols-1, y, 11000, 0);
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
