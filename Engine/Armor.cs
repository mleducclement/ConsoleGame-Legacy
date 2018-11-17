using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Armor : InventoryItem
    {
        public int ArmorClass;
        
        public Armor(string name, int quantity, int armorClass) : base (name, quantity)
        {
            ArmorClass = armorClass;
        }
    }
}
