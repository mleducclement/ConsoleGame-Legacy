using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Entity
    {
        public int MaxHP;
        public int CurrentHp;
        public string Name;

        public Entity(int maxHp)
        {
            MaxHP = maxHp;
            CurrentHp = maxHp;
        }
    }
}
