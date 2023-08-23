using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ALProject
{
    enum TextureNames
    {
        Default,
        Leaflet,
        Antena,
        Root,
        WoodX,
        WoodT,
        WoodV,
        WoodI,
        HeadO,
        HeadQ,
        SeedO,
        SeedQ,
        NoTexture,
    }
    struct EnergyCount
    {
        public int givenEnergy;
        public int geneticCellCount;

        public int GetCleanEnergy()
        {
            return givenEnergy / (geneticCellCount + 1);
        }
        public static EnergyCount Sum(EnergyCount a, EnergyCount b)
        {
            return new EnergyCount(a.givenEnergy + b.givenEnergy, a.geneticCellCount + b.geneticCellCount);
        }
        public static EnergyCount operator +(EnergyCount a, EnergyCount b) => Sum(a, b);
        public EnergyCount(int energy = 0, int count = 0)
        {
            givenEnergy = energy;
            geneticCellCount = count;
        }
    }

    class Field
    {
        private Cell[,] field;
        public List<GeneticCell> Heads;
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public void CreateNewField(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            field = new Cell[rows, cols];
            SetClearField();
        }
        public void DoSteps()
        {

        }
        public void UpdateField()
        {

        }
        public void SetClearField()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    field[i, j] = new EmptyCell(i, j);
                }
            }
        }
        public void KillCell(int i, int j)
        {
            field[i - 1, j].DeleteNeighbour(field[i, j]);
            field[i, j + 1].DeleteNeighbour(field[i, j]);
            field[i + 1, j].DeleteNeighbour(field[i, j]);
            field[i, j - 1].DeleteNeighbour(field[i, j]);
            field[i, j] = new EmptyCell(field[i, j]);
        }
        public void SetCell(Cell cell, int i, int j)
        {

        }
        public void RandomizeField() 
        {
            Random random = new Random();
            TextureNames cellname;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    cellname = (TextureNames)random.Next(13);
                    switch (cellname)
                    {
                        case TextureNames.Default:
                            field[i, j] = new EmptyCell(field[i, j]);
                            break;
                        case TextureNames.Leaflet:
                            field[i, j] = new LeafletCell(field[i, j], direct: (byte)random.Next(4));
                            break;
                        case TextureNames.Antena:
                            field[i, j] = new AntenaCell(field[i, j], direct: (byte)random.Next(4));
                            break;
                        case TextureNames.Root:
                            field[i, j] = new RootCell(field[i, j], direct: (byte)random.Next(4));
                            break;
                        case TextureNames.WoodX:
                            field[i, j] = new WoodCell(field[i, j], TextureNames.WoodX);
                            break;
                        case TextureNames.WoodT:
                            field[i, j] = new WoodCell(field[i, j], TextureNames.WoodT, (byte)random.Next(4));
                            break;
                        case TextureNames.WoodV:
                            field[i, j] = new WoodCell(field[i, j], TextureNames.WoodV, (byte)random.Next(4));
                            break;
                        case TextureNames.WoodI:
                            field[i, j] = new WoodCell(field[i, j], TextureNames.WoodI, (byte)random.Next(4));
                            break;
                        case TextureNames.HeadO:
                            if (field[i, j] is SeedCell)
                            {
                                field[i, j] = new HeadCell((SeedCell)field[i, j]);
                                break;
                            }
                            field[i, j] = new HeadCell(field[i, j], TextureNames.HeadO, (byte)random.Next(4));
                            break;
                        case TextureNames.HeadQ:
                            if (field[i, j] is SeedCell)
                            {
                                field[i, j] = new HeadCell((SeedCell)field[i, j]);
                                break;
                            }
                            field[i, j] = new HeadCell(field[i, j], TextureNames.HeadQ, (byte)random.Next(4));
                            break;
                        case TextureNames.SeedO:
                            if (field[i, j] is HeadCell)
                                field[i, j] = new SeedCell((HeadCell)field[i, j]);
                            break;
                        case TextureNames.SeedQ:
                            if (field[i, j] is HeadCell)
                                field[i, j] = new SeedCell((HeadCell)field[i, j]);
                            break;
                        case TextureNames.NoTexture:
                            field[i, j] = new EmptyCell(field[i, j], TextureNames.NoTexture);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void Testing()
        {
            EnergyCell[] neighbours;
            field[0, 0] = new LeafletCell(field[0, 0]);
            field[2, 0] = new RootCell(field[2, 0], direct: 2);
            neighbours = new EnergyCell[] { (EnergyCell)field[0, 0], (EnergyCell)field[2, 0] };
            field[1, 0] = new WoodCell(field[1, 0], TextureNames.WoodT, 0, neighbours);
            neighbours = new EnergyCell[] { (EnergyCell)field[1, 0] };
            field[1, 1] = new WoodCell(field[1, 1], TextureNames.WoodV, 1, neighbours);
            neighbours = new EnergyCell[] { (EnergyCell)field[1, 1] };
            field[2, 1] = new WoodCell(field[2, 1], TextureNames.WoodV, 3, neighbours);
            field[1, 2] = new AntenaCell(field[1, 2]);
            field[3, 2] = new LeafletCell(field[3, 2], direct: 2);
            neighbours = new EnergyCell[] { (EnergyCell)field[1, 2], (EnergyCell)field[3, 2], (EnergyCell)field[2, 1] };
            field[2, 2] = new WoodCell(field[2, 2], TextureNames.WoodX, 0, neighbours);
            field[2, 3] = new HeadCell(field[2, 3], TextureNames.HeadQ, 1, (EnergyCell)field[2,2]);

            ((HeadCell)field[2, 3]).GetEnergy();
            if (((HeadCell)field[2,3]).Energy >= 32)
            {
                field[2, 3] = new SeedCell((HeadCell)field[2, 3]);
            }
        }
        public Cell this[int i, int j]
        {
            get { return field[i, j]; }
            set { field[i, j] = value; }
        }
    }

    abstract class Cell
    {
        public static Field field;
        public static readonly int maxOrganic = 100, maxCharge = 100, defaultSun = 16, averageCharge = 20, ChargeRecoveryConst = 4;
        public readonly int PosI, PosJ;
        public TextureNames TextureName { get; protected set; }
        public int Organic { get; protected set; }
        public int Charge { get; protected set; }
        public int Sun { get; protected set; } = defaultSun;
        public byte Direction { get; protected set; }

        public virtual void CellUpdate()
        {
            //Charge update
            if (Charge < averageCharge - 3)
                Charge += ChargeRecoveryConst;
            else if (Charge > averageCharge + 3)
                Charge -= ChargeRecoveryConst;
        }
        public virtual void DeleteNeighbour(Cell neighbour) { }

        public Cell(int i, int j)
        {
            PosI = i;
            PosJ = j;
            Organic = 0;
            Charge = 0;
            TextureName = TextureNames.Default;
        }
        public Cell(Cell cell, TextureNames texturename = TextureNames.NoTexture)
        {
            Organic = cell.Organic;
            Charge = cell.Charge;
            TextureName = texturename;
        }
    }

    abstract class EnergyCell : Cell
    {
        protected List<EnergyCell> EnergyConsumers;
        protected byte lifeTime = 0;
        public readonly static byte maxLifeTime = 64;

        public override void CellUpdate()
        {
            base.CellUpdate();

            //LifeTime update
            lifeTime++;
        }

        public EnergyCell(Cell cell, TextureNames texturename, byte direct) 
            : base(cell, texturename)
        {
            Direction = direct;
        }
        public abstract EnergyCount GenerateEnergy();
    }
    abstract class GeneticCell : EnergyCell
    {
        protected byte[] _commands;
        protected byte _CCP = 0; //Current Command Pointer, Указатель Текущей Команды
        protected EnergyCell _neighbour;
        protected int _energy;
        protected static int _MaxEnergy = 1000;
        private static int _mutateChance = 100;
        protected static Random _random = new Random();
        public int Energy { get { return _energy; } }

        public override void DeleteNeighbour(Cell neighbour)
        {
            if (neighbour.Equals(_neighbour))
                _neighbour = null;
        }
        public void MutateTry()
        {
            if (_mutateChance == _random.Next(_mutateChance))
                _commands[_random.Next(_commands.Length)] = (byte)_random.Next(_commands.Length);
        }
        public override EnergyCount GenerateEnergy()
        {
            return new EnergyCount(count: 1);
        }
        public void GetEnergy()
        {
            _energy += (_neighbour?.GenerateEnergy().GetCleanEnergy() ?? 0);
        }
        public GeneticCell(Cell cell, TextureNames texturename, byte direct, EnergyCell neighbour, int energy = 0, byte[] commands = null)
            : base(cell, texturename, direct)
        {
            _neighbour = neighbour;
            _commands = commands;
            _energy = energy;
        }
        public GeneticCell(SeedCell cell) 
            : this(cell, cell.TextureName - 2, cell.Direction, cell._neighbour, cell._energy) 
        { _commands = cell._commands; }
        public GeneticCell(HeadCell cell) 
            : this(cell, cell.TextureName + 2, cell.Direction, cell._neighbour, cell._energy) 
        { _commands = cell._commands; }
    }

    class EmptyCell : Cell
    {
        public EmptyCell(int i, int j) : base(i, j) { }
        public EmptyCell(Cell DeadCell, TextureNames texturename = TextureNames.Default) 
            : base(DeadCell, texturename) { }
    }

    class LeafletCell : EnergyCell
    {
        public override EnergyCount GenerateEnergy() 
        {
            return new EnergyCount(Sun); 
        }
        public LeafletCell(Cell cell, TextureNames texturename = TextureNames.Leaflet, byte direct = 0) 
            : base(cell, texturename, direct) { }
    }
    class AntenaCell : EnergyCell
    {
        private static int _energyConst = 10;

        public override EnergyCount GenerateEnergy()
        {
            if (Charge>=_energyConst)
            {
                Charge -= _energyConst;
                return new EnergyCount(_energyConst);
            }
            return new EnergyCount();
        }
        public AntenaCell(Cell cell, TextureNames texturename = TextureNames.Antena, byte direct = 0) 
            : base(cell, texturename, direct) { }
    }
    class RootCell : EnergyCell
    {
        private static int _energyConst = 10;

        public override EnergyCount GenerateEnergy()
        {
            if (Organic>=_energyConst)
            {
                Organic -= _energyConst;
                return new EnergyCount(_energyConst);
            }
            return new EnergyCount();
        }
        public RootCell(Cell cell, TextureNames texturename = TextureNames.Root, byte direct = 0) 
            : base(cell, texturename, direct) { }
    }
    class WoodCell : EnergyCell
    {
        private EnergyCell[] _neighbours;

        public override void DeleteNeighbour(Cell neighbour)
        {
            for (int i = 0; i < _neighbours.Length; i++)
            {
                if (neighbour.Equals(_neighbours[i]))
                {
                    _neighbours[i] = null;
                }
            }
        }
        public override EnergyCount GenerateEnergy()
        {
            EnergyCount result = new EnergyCount();
            foreach (var cell in _neighbours)
                result += cell?.GenerateEnergy() ?? new EnergyCount();
            return result;
        }
        public WoodCell(Cell cell, TextureNames texturename = TextureNames.WoodX, byte direct = 0) 
            : base(cell, texturename, direct) { }
        public WoodCell(Cell cell, TextureNames texturename, byte direct, EnergyCell[] neighbours)
            : base(cell, texturename, direct)
        { _neighbours = neighbours; }
    }

    class HeadCell : GeneticCell
    {
        public HeadCell(Cell cell, TextureNames texturename = TextureNames.HeadO, byte direct = 0, EnergyCell neighbour = null)
            : base(cell, texturename, direct, neighbour) { }
        public HeadCell(SeedCell cell) : base(cell) { }
    }
    class SeedCell : GeneticCell
    {
        public SeedCell(HeadCell cell) : base(cell) { }
    }
}
