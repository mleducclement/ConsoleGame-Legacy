using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class BlackMagic : Spell
    {
        public int SpellDamage;

        public BlackMagic (string name, int mpCost, int spellDamage) : base (name, mpCost)
        {
            Name = name;
            MpCost = mpCost;
            SpellDamage = spellDamage;
        }

        public override void DealDamage(Entity entity)
        {
            entity.CurrentHp -= SpellDamage;
        }
    }
}
