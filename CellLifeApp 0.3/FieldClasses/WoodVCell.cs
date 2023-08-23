﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    class WoodVCell : WoodCell, IRotateble
    {
        public Direct Direction { get; }

        public WoodVCell(GeneticCell cell, List<LifeCell> contacts, Direct direct) 
            : base(cell, contacts) 
        { Direction = direct;}
    }
}
