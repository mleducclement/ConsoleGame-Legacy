using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public abstract class Spell
    {
        public string Name;
        public int MpCost;

        public Spell(string name, int mpCost)
        {
            Name = name;
            MpCost = mpCost;
        }

        public virtual void DealDamage(Entity entity)
        {

        }

        public virtual void Heal(Entity entity)
        {

        }

        public static void CastSpell(Spell spell, Entity ally, Entity foe)
        {
            if (spell is BlackMagic)
            {
                spell.DealDamage(foe);
                UI.WriteToBattleInfoArea($"{ally.Name} cast {spell.Name} at {foe.Name} for {((BlackMagic)spell).SpellDamage} damage. {foe.Name} now has {foe.CurrentHp} hp remaining.", UI.MAGENTA);
                Console.ResetColor();
            }
            else if (spell is WhiteMagic)
            {
                spell.Heal(ally);
                UI.WriteToBattleInfoArea($"{ally.Name} cast {spell.Name} at himself, is healed for {((WhiteMagic)spell).AmountHealed} and now has {ally.CurrentHp} hp remaining.", UI.GREEN);
                Console.ResetColor();
            }
        }
    }
}
