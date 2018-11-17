using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Potion : InventoryItem
    {
        int HpToRecover;

        public Potion(string name, int quantity, int hpToRecover) : base (name, quantity)
        {
            HpToRecover = hpToRecover;
        }
    }
}
