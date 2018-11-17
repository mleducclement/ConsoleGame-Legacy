using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public static class World
    {
        public static readonly List<Job> Jobs = new List<Job>();
        public static readonly List<Chest> Chests = new List<Chest>();
        public static readonly List<Weapon> Weapons = new List<Weapon>();
        public static readonly List<Armor> Armors = new List<Armor>();
        public static readonly List<Potion> Potions = new List<Potion>();
        public static readonly List<Spell> Spells = new List<Spell>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Tile> Tiles = new List<Tile>();

        //Initialize full world with items and tiles
        static World()
        {
            PopulateJobs();
            PopulateWeapons();
            PopulateArmors();
            PopulatePotions();
            PopulateSpells();
            PopulateMonsters();
            MapManager.PopulateTileList();
        }

        //Populate the Jobs list
        private static void PopulateJobs()
        {
            Jobs.Add(new Job("Warrior", 100));
            Jobs.Add(new Job("Mage", 10));
            Jobs.Add(new Job("Thief", 15));
        }

        //Populate the Weapons list
        private static void PopulateWeapons()
        {
            Weapons.Add(new Weapon("Knife", 1, 1, 3));
            Weapons.Add(new Weapon("Short Sword", 1, 1, 2));
        }

        //Populate the Armors list
        private static void PopulateArmors()
        {
            Armors.Add(new Armor("Shirt", 1, 1));
            Armors.Add(new Armor("Leather Armor", 1, 4));
        }

        //Populate the Potions list
        private static void PopulatePotions()
        {
            Potions.Add(new Potion("Healing", 1, 20));
        }

        //Populate the Spells list
        private static void PopulateSpells()
        {
            Spells.Add(new WhiteMagic("Heal", 8, 20));
            Spells.Add(new WhiteMagic("Antidote", 25, 20));
            Spells.Add(new WhiteMagic("Recover", 19, 20));
            Spells.Add(new BlackMagic("Fireball", 15, 20));
            Spells.Add(new BlackMagic("Thunder", 7, 20));
            Spells.Add(new BlackMagic("Glacier", 106, 20));
            Spells.Add(new BlackMagic("Firestorm", 85, 20));
            Spells.Add(new BlackMagic("Omega Blast", 14, 20));
            Spells.Add(new BlackMagic("Volcano", 36, 20));
            Spells.Add(new BlackMagic("Radiance", 255, 20));
            Spells.Add(new BlackMagic("Supernova", 45, 20));
            Spells.Add(new BlackMagic("Singularity", 118, 20));
        }

        //Populate the Monsters List
        private static void PopulateMonsters()
        {
            Monsters.Add(new Monster("Rat", 1, 100, 1, 1));
            Monsters.Add(new Monster("Slime", 3, 14, 2, 2));
            Monsters.Add(new Monster("Skeleton", 5, 20, 4, 4));
        }
    }
}
