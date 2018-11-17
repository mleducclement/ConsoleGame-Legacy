using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class WhiteMagic : Spell
    {
        public int AmountHealed;

        public WhiteMagic (string name, int mpCost, int amountHealed) : base (name, mpCost)
        {
            Name = name;
            MpCost = mpCost;
            AmountHealed = amountHealed;
        }

        public override void Heal(Entity entity)
        {
            int newHp = entity.CurrentHp + AmountHealed;

            if (newHp <= entity.MaxHP)
            {
                entity.CurrentHp += AmountHealed;
            }
            else
            {
                entity.CurrentHp = entity.MaxHP;
            }
        }
    }
}
