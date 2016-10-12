using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Door
    {
        public Key Key { get; private set; }
        public bool IsUnlocked { get; set; }

        public Door(Key key = null)
        {
            Key = key;
        }

    }
}
