using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLifeApp.FieldClasses
{
    interface IHaveContacts
    {
        List<LifeCell> Contacts { get; }
        public void DelRef(LifeCell cell);
    }
}
