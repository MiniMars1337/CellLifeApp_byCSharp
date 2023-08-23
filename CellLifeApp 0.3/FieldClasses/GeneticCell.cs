using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    abstract class GeneticCell : LifeCell, IRotateble
    {
        public Direct Direction { get; protected set; }
        internal int[] geneticCode;
        //CCP, Current Command Pointer, Указатель Текущей Команды
        private int localccp;
        public int CCP
        {
            get { return localccp; }
            protected set { localccp = value % geneticCode.Length; }
        }
        public const int maxGenCodeValue = 100;
        public const double toxicConstant = (double)toxicLevel / maxGenCodeValue;
        public const double energyConstant = (double)maxEnergyCapacity / maxGenCodeValue;
        public const double cellEatingConst = 0.5;
        public static readonly string[] eatableTypes = new string[]
        {
            "Cell",
            "LeafletCell",
            "AntenaCell",
            "SingleHeadCell",
            "ConnectedHeadCell",
            "SingleSeedCell",
            "ConnectedSeedCell",
        };
        public static readonly string[] typesToGrow = new string[]
        {
            "RootCell",
            "AntenaCell",
            "LeafletCell",
            "ColonialHeadCell",
            "ColonialSeedCell",
            "Cell",
        };
        public static readonly string[] geneticTypes = new string[]
        {
            "SingleHeadCell",
            "SingleSeedCell",
            "ColonialHeadCell",
            "ColonialSeedCell",
        };
        public static bool isMutationEnabled = true;

        public static readonly Random random = new Random();
        protected int stepCounter = 0;
        protected const int maxStepCount = 1000;

        public GeneticCell(Cell cell, int givedEnergy, Direct direct, int[] genCode, int ccp) 
            : base(cell, givedEnergy)
        {
            Direction = direct;
            geneticCode = genCode;
            CCP = ccp;
            field.addList.Add(this);
        }

        public virtual void GenerateEnergy() { }
        public virtual void DoStep() 
        {
            stepCounter = 0;
            bool result = false;
            while (!result && stepCounter != maxStepCount)
            {
                result = TryStep();
                stepCounter++;
            }
            if (stepCounter == maxStepCount) 
                Die();
            else if (isMutationEnabled && random.Next() % 10 == 1) 
                geneticCode[random.Next(geneticCode.Length)] = random.Next(1, maxGenCodeValue);
        }
        protected abstract bool TryStep();
        protected virtual bool Command_12_Wait()
        {
            CCP += 1;
            return true;
        }
        protected virtual bool Command_3_CheckNearby()
        {
            Cell cell = WhatNearby(GetDirect(Parametr(1)));
            CCP += cell is LifeCell ? Parametr(2) + 3 : Parametr(3) + 3;
            return false;
        }
        protected virtual bool Command_4_CheckOrganic()
        {
            Cell cell = WhatNearby(GetDirect(Parametr(1)));
            CCP += cell.Organic < Parametr(2) * toxicConstant ? Parametr(3) + 4 : Parametr(4) + 4;
            return false;
        }
        protected virtual bool Command_5_CheckCharge()
        {
            Cell cell = WhatNearby(GetDirect(Parametr(1)));
            CCP += cell.Charge < Parametr(2) * toxicConstant ? Parametr(3) + 4 : Parametr(4) + 4;
            return false;
        }
        protected virtual bool Command_6_CheckSunLevel()
        {
            Cell cell = WhatNearby(GetDirect(Parametr(1)));
            CCP += cell.SunLevel < Parametr(2) % maxSunLevel ? Parametr(3) + 4 : Parametr(4) + 4;
            return false;
        }
        protected virtual bool Command_7_CheckEnergy()
        {
            CCP += Energy < Parametr(1) * energyConstant ? Parametr(2) + 3 : Parametr(3) + 3;
            return false;
        }
        protected virtual bool Command_8_CreateBranches()
        {
            List<LifeCell> contacts = new List<LifeCell>();
            int growingGenetics = 0, growingNotGenetics = 1;
            string[] growingTypes = new string[] 
            {
                typesToGrow[Parametr(1) % typesToGrow.Length],
                typesToGrow[Parametr(2) % typesToGrow.Length],
                typesToGrow[Parametr(3) % typesToGrow.Length],
            };
            foreach (string type in growingTypes)
            {
                if (type == "Cell") continue;
                if (geneticTypes.Contains(type)) growingGenetics++;
                else growingNotGenetics++;
            }
            int givingNotGenEnergy = (int)(Parametr(4) * energyConstant) / growingNotGenetics;
            if (Energy < givingNotGenEnergy * growingNotGenetics)
            {
                givingNotGenEnergy = Energy / growingNotGenetics;
                Energy = 0;
            }
            int givingGenEnergy = growingGenetics != 0 ? (Energy - givingNotGenEnergy * growingNotGenetics) / growingGenetics : 0;
            LifeCell growedCell;
            for (int i = 0; i < 3; i++)
            {
                if (geneticTypes.Contains(growingTypes[i]))
                    growedCell = GrowCell(growingTypes[i], GetDirect(i), givingGenEnergy, CCP + 7 + Parametr(5+i));
                else
                    growedCell = GrowCell(growingTypes[i], GetDirect(i), givingNotGenEnergy);
                if (growedCell != null) { contacts.Add(growedCell); }
            }
            if (this is IHaveContacts) { contacts.AddRange(((IHaveContacts)this).Contacts); }
            growedCell = new WoodXCell(this, contacts);
            foreach (LifeCell cell in contacts)
                if (cell is IHaveContacts) { ((IHaveContacts)cell).Contacts.Add(growedCell); }
            return true;
        }
        protected virtual bool Command_9_CheckConnection()
        {
            CCP += this is IHaveContacts && ((IHaveContacts)this).Contacts.Count == 1 ? Parametr(1) : Parametr(2);
            return false;
        }
        protected virtual bool Command_Default()
        {
            CCP += geneticCode[CCP];
            return true;
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
        protected Direct GetDirect(int a)
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
        protected virtual int EatCell(Cell cell)
        {
            if (eatableTypes.Contains(cell.GetType().Name))
            {
                if (!(cell is LifeCell))
                    return 0;
                LifeCell Lcell = (LifeCell)cell;
                field.DelReferences(Lcell, true);
                return (int)(Lcell.Energy * cellEatingConst) + 1;
            }
            return int.MinValue;
        }
        protected LifeCell GrowCell(string type, Direct direct, int energy, int newCCP = 0)
        {
            Cell oldCell = WhatNearby(direct);
            LifeCell cell = null;
            switch (type)
            {
                case "Cell":
                    energy = 0;
                    break;
                case "RootCell":
                    if (!(oldCell is LifeCell) && Energy >= energy)
                        cell = new RootCell(oldCell, energy, direct);
                    break;
                case "AntenaCell":
                    if (!(oldCell is LifeCell) && Energy >= energy)
                        cell = new AntenaCell(oldCell, energy, direct);
                    break;
                case "LeafletCell":
                    if (!(oldCell is LifeCell) && Energy >= energy)
                        cell = new LeafletCell(oldCell, energy, direct);
                    break;
                case "ColonialHeadCell":
                    if (eatableTypes.Contains(oldCell.GetType().Name) && Energy >= energy)
                    {
                        int eatedEnergy = EatCell(oldCell);
                        if (eatedEnergy != int.MinValue)
                            cell = new ColonialHeadCell(oldCell, energy + eatedEnergy, direct, geneticCode, newCCP);
                        else
                            field.IncreaseToxic(oldCell);
                    }
                    break;
                case "ColonialSeedCell":
                    if (!(oldCell is LifeCell) && Energy >= energy)
                        cell = new ColonialSeedCell(oldCell, energy, direct, geneticCode, newCCP);
                    break;
                default:
                    break;
            }
            Energy -= energy;
            return cell;
        }
        protected int Parametr(int ccpincrease) => geneticCode[(CCP + ccpincrease) % geneticCode.Length];
    }
}
