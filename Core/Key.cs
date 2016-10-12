using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Key: IGameItem
    {
        public GameObjectType type { get { return GameObjectType.Key; } }

        public delegate void OnItemUse(Key item, EventArgs args);
        public event OnItemUse itemUse;

        public Key()
        {

        }


        public void use()
        {
            itemUse?.Invoke(this,EventArgs.Empty);
        }

    }
}
