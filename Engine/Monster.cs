using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Monster : Entity
    {
        public int Damage;
        public int ExperiencePointsValue;
        public int GoldValue;

        public Monster (string name, int damage, int maxHp, int experience, int gold) : base (maxHp)
        {
            Name = name;
            Damage = damage;
            ExperiencePointsValue = experience;
            GoldValue = gold;
        }

        public void DamagePlayer(Player player)
        {
            player.CurrentHp -= Damage;
            UI.WriteToBattleInfoArea($"{Name} attacks and {player.Name} is hit for {Damage} points of damage.", UI.RED);
            Console.ResetColor();
        }
    }
}
