using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Weapon : InventoryItem
    {
        public int MinimumDamage;
        public int MaximumDamage;

        public Weapon(string name, int quantity, int minimumDamage, int maximumDamage) : base (name, quantity)
        {
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }
    }
}
