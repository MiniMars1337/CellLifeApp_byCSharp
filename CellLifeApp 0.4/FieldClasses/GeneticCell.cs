using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    [Serializable]
    abstract class GeneticCell : LifeCell, IRotateble
    {
        internal int[] geneticCode;
        internal static double energyConstant;
        internal static double toxicConstant;
        internal static readonly string[] eatableTypes = new string[]
        {
            "Cell",
            "LeafletCell",
            "AntenaCell",
            "SingleHeadCell",
            "ColonialHeadCell",
            "SingleSeedCell",
            "ColonialSeedCell",
        };
        internal static readonly string[] typesToGrow = new string[]
        {
            "Cell",
            "RootCell",
            "AntenaCell",
            "LeafletCell",
        };
        internal static readonly string[] geneticTypes = new string[]
        {
            "SingleHeadCell",
            "SingleSeedCell",
            "ColonialHeadCell",
            "ColonialSeedCell",
        };
        public static readonly Random random = new Random();
        protected int stepCounter;
        private const int maxStepCount = 1000;
        private int localccp; //CCP, Current Command Pointer, Указатель Текущей Команды
        public int CCP
        {
            get { return localccp; }
            protected set { localccp = value % geneticCode.Length; }
        }
        public Direct Direction { get; protected set; }
        public static int AllMutations { get; set; }

        public GeneticCell(Cell cell, int givedEnergy, Direct direct, int[] genCode, int ccp) 
            : base(cell, givedEnergy)
        {
            Direction = direct;
            geneticCode = genCode;
            CCP = ccp;
            field.addList.Add(this);
        }

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
            else if (parameters.IsMutationEnabled && random.NextDouble() < parameters.MutationChance)
            {
                geneticCode[random.Next(geneticCode.Length)] = random.Next(1, parameters.MaxGenCodeValue);
                AllMutations++;
            }
        }
        protected abstract bool TryStep();
        protected virtual bool Command_0_CCPplus1()
        {
            CCP++;
            return false;
        }
        protected virtual bool Command_1_CCPincrease()
        {
            CCP += Parametr(1) + 1;
            return false;
        }
        protected virtual bool Command_2_Wait()
        {
            CCP += 1;
            return true;
        }
        protected virtual bool Command_9_CheckNearby()
        {
            Cell cell = WhatNearby(GetDirect(Direction, Parametr(1)));
            CCP += cell is LifeCell ? Parametr(2) + 3 : Parametr(3) + 3;
            return true;
        }
        protected virtual bool Command_10_CheckOrganic()
        {
            Cell cell = WhatNearby(GetDirect(Direction, Parametr(1)));
            CCP += cell.Organic < Parametr(2) * toxicConstant ? Parametr(3) + 4 : Parametr(4) + 4;
            return true;
        }
        protected virtual bool Command_11_CheckCharge()
        {
            Cell cell = WhatNearby(GetDirect(Direction, Parametr(1)));
            CCP += cell.Charge < Parametr(2) * toxicConstant ? Parametr(3) + 4 : Parametr(4) + 4;
            return true;
        }
        protected virtual bool Command_12_CheckSunLevel()
        {
            Cell cell = WhatNearby(GetDirect(Direction, Parametr(1)));
            CCP += cell.SunLevel < Parametr(2) % parameters.MaxSunLevel ? Parametr(3) + 4 : Parametr(4) + 4;
            return true;
        }
        protected virtual bool Command_13_CheckEnergy()
        {
            CCP += Energy < Parametr(1) * energyConstant ? Parametr(2) + 3 : Parametr(3) + 3;
            return true;
        }
        protected virtual bool Commands_14to74_CreateBranches()
        {
            List<LifeCell> contacts = new List<LifeCell>();
            LifeCell growedCell;
            var param0 = geneticCode[CCP] - 14;
            if (param0 < 48)
            {
                var a = Parametr(1) * energyConstant;
                if (Parametr(1) * energyConstant > Energy)
                    return Command_Sys_1_Wait_NotIncreaseCCP();
                int direct = param0 / 16;
                growedCell = GrowCell("ColonialHeadCell", GetDirect(Direction, direct), (int)(Parametr(1) * energyConstant), CCP + 2 + Parametr(2));
                if (growedCell != null)
                    contacts.Add(growedCell);
                var toGrowtype = typesToGrow[param0 % 16 / 4];
                var energyDivider = toGrowtype == "Cell" ? 2 : 3;
                growedCell = GrowCell(toGrowtype, GetDirect(Direction, direct + 1), Energy / energyDivider);
                if (growedCell != null)
                    contacts.Add(growedCell);
                growedCell = GrowCell(typesToGrow[param0 % 4], GetDirect(Direction, direct + 2), Energy / energyDivider);
                if (growedCell != null)
                    contacts.Add(growedCell);
            }
            else if (param0 < 60)
            {
                if (Parametr(1) * energyConstant + Parametr(3) * energyConstant > Energy)
                    return Command_Sys_1_Wait_NotIncreaseCCP();
                param0 -= 48;
                int direct = param0 / 4;
                growedCell = GrowCell("ColonialHeadCell", GetDirect(Direction, direct), (int)(Parametr(1) * energyConstant), CCP + 4 + Parametr(2));
                if (growedCell != null)
                    contacts.Add(growedCell);
                growedCell = GrowCell("ColonialHeadCell", GetDirect(Direction, direct + 1), (int)(Parametr(3) * energyConstant), CCP + 4 + Parametr(4));
                if (growedCell != null)
                    contacts.Add(growedCell);
                growedCell = GrowCell(typesToGrow[param0 % 4], GetDirect(Direction, direct + 2), Energy / 2);
                if (growedCell != null)
                    contacts.Add(growedCell);
            }
            else
            {
                if (Parametr(1) * energyConstant + Parametr(3) * energyConstant + Parametr(5) * energyConstant > Energy)
                    return Command_Sys_1_Wait_NotIncreaseCCP();
                growedCell = GrowCell("ColonialHeadCell", Direct.Left, (int)(Parametr(1) * energyConstant), CCP + 6 + Parametr(2));
                if (growedCell != null)
                    contacts.Add(growedCell);
                growedCell = GrowCell("ColonialHeadCell", Direct.Up, (int)(Parametr(3) * energyConstant), CCP + 6 + Parametr(4));
                if (growedCell != null)
                    contacts.Add(growedCell);
                growedCell = GrowCell("ColonialHeadCell", Direct.Right, (int)(Parametr(5) * energyConstant), CCP + 6 + Parametr(6));
                if (growedCell != null)
                    contacts.Add(growedCell);
                if (param0 == 61)
                    throw new SystemException("Подправь 62 команду (её не должно быть)");
            }
            if (this is IHaveContacts)
                contacts.AddRange(((IHaveContacts)this).Contacts);
            growedCell = new WoodXCell(this, contacts);
            foreach (LifeCell cell in contacts)
                if (cell is IHaveContacts)
                    ((IHaveContacts)cell).Contacts.Add(growedCell);
            return true;
        }
        protected virtual bool Command_Sys_1_Wait_NotIncreaseCCP()
        {
            return true;
        }

        //protected virtual bool Command_14_CreateBranches()
        //{
        //    List<LifeCell> contacts = new List<LifeCell>();
        //    int growingGenetics = 0, growingNotGenetics = 1;
        //    string[] growingTypes = new string[] 
        //    {
        //        typesToGrow[Parametr(1) % typesToGrow.Length],
        //        typesToGrow[Parametr(2) % typesToGrow.Length],
        //        typesToGrow[Parametr(3) % typesToGrow.Length],
        //    };
        //    foreach (string type in growingTypes)
        //    {
        //        if (type == "Cell") continue;
        //        if (geneticTypes.Contains(type)) growingGenetics++;
        //        else growingNotGenetics++;
        //    }
        //    int givingNotGenEnergy = (int)(Parametr(4) * energyConstant) / growingNotGenetics;
        //    if (Energy < givingNotGenEnergy * growingNotGenetics)
        //    {
        //        givingNotGenEnergy = Energy / growingNotGenetics;
        //        Energy = 0;
        //    }
        //    int givingGenEnergy = growingGenetics != 0 ? (Energy - givingNotGenEnergy * growingNotGenetics) / growingGenetics : 0;
        //    LifeCell growedCell;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        if (geneticTypes.Contains(growingTypes[i]))
        //            growedCell = GrowCell(growingTypes[i], GetDirect(Direction, i), givingGenEnergy, CCP + 7 + Parametr(5+i));
        //        else
        //            growedCell = GrowCell(growingTypes[i], GetDirect(Direction, i), givingNotGenEnergy);
        //        if (growedCell != null) { contacts.Add(growedCell); }
        //    }
        //    if (this is IHaveContacts) { contacts.AddRange(((IHaveContacts)this).Contacts); }
        //    growedCell = new WoodXCell(this, contacts);
        //    foreach (LifeCell cell in contacts)
        //        if (cell is IHaveContacts) { ((IHaveContacts)cell).Contacts.Add(growedCell); }
        //    return true;
        //}
        protected virtual bool Command_Default()
        {
            CCP += geneticCode[CCP];
            return false;
        }
        protected virtual int EatCell(Cell cell)
        {
            if (eatableTypes.Contains(cell.GetType().Name))
            {
                if (cell.GetType() == typeof(Cell))
                    return 0;
                LifeCell Lcell = (LifeCell)cell;
                field.DelReferences(Lcell, true);
                return (int)(Lcell.Energy * parameters.CellEatingCoefficient) + 1;
            }
            return int.MinValue;
        }
        protected LifeCell GrowCell(string type, Direct direct, int energy, int newCCP = 0)
        {
            if (type == "Cell")
                return null;
            Energy -= energy;
            Cell oldCell = WhatNearby(direct);
            if (oldCell.Organic >= parameters.ToxicLevel || oldCell.Charge >= parameters.ToxicLevel)
            {
                field.IncreaseToxic(oldCell);
                return null;
            }
            switch (type)
            {
                case "RootCell":
                    if (oldCell.GetType().Name == "Cell")
                        return new RootCell(oldCell, energy, direct);
                    break;
                case "AntenaCell":
                    if (oldCell.GetType().Name == "Cell")
                        return new AntenaCell(oldCell, energy, direct);
                    break;
                case "LeafletCell":
                    if (oldCell.GetType().Name == "Cell")
                        return new LeafletCell(oldCell, energy, direct);
                    break;
                case "ColonialHeadCell":
                    if (eatableTypes.Contains(oldCell.GetType().Name))
                    {
                        int eatedEnergy = EatCell(oldCell);
                        if (eatedEnergy != int.MinValue)
                            return new ColonialHeadCell(oldCell, energy + eatedEnergy, direct, geneticCode, newCCP);
                        field.IncreaseToxic(oldCell);
                        return null;
                    }
                    break;
            }
            return null;
        }
        protected int Parametr(int ccpincrease) => geneticCode[(CCP + ccpincrease) % geneticCode.Length];
    }
}
