using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Player : Entity
    {
        public int CurrentEXP;
        public int XpToNextLevel;
        public int Level;

        public Weapon EquippedWeapon;

        public List<Spell> KnownSpells = new List<Spell>();

        public Position Position;

        public Job CurrentJob;

        private Player(int currentEXP, int xpToNextLevel, int level, Position position, int maxHp) :  base (maxHp)
        {
            CurrentEXP = currentEXP;
            XpToNextLevel = xpToNextLevel;
            Level = level;
            Position = position;
        }

        //Create the default player
        public static Player CreateNewPlayer()
        {
            Player player = new Player(0, 100, 1, new Position(30, 10), 10);

            return player;
        }

        //Start the character creation
        public void CharacterCreation()
        {
            Console.WriteLine("What is your name?");

            Name = Console.ReadLine();

            Console.WriteLine("Welcome to this dungeon, {0}", Name);

            Console.WriteLine("Tell me, {0}, Which class interest you the most?", Name);
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Thief");
            Console.WriteLine("Choose one of them by entering the number :");

            int _job = Convert.ToInt32(Console.ReadLine());

            SetCurrentJob(_job);
            SetStartingHP();

            Console.WriteLine("Ahhh, I see that you chose to be a {0}", CurrentJob.Name);
        }

        //Set player's job according to the user's choice
        public void SetCurrentJob(int jobID)
        {
            switch (jobID)
            {

                case 1:
                    {
                        CurrentJob = World.Jobs[0];
                        break;
                    }

                case 2:
                    {
                        CurrentJob = World.Jobs[1];
                        break;
                    }

                case 3:
                    {
                        CurrentJob = World.Jobs[2];
                        break;
                    }
            }       
        }

        //Set player's starting HP according to his job
        public void SetStartingHP()
        {
            MaxHP = CurrentJob.StartingHP;
            CurrentHp = MaxHP;
        }

        //Move player North on the map and handles different cases depending on the destination tile properties
        public void MoveNorth()
        {
            Position newPosition = new Position(Position.XCoord, (Position.YCoord - 1));
            var destination = Tile.GetTileAtDestination(newPosition);

            if (Position.YCoord > 3 && !(destination is Obstacle))
            {
                Position.YCoord--;
                UI.DrawPlayer(this);
                Console.SetCursorPosition(Position.XCoord, (Position.YCoord + 1));
                Console.Write(' ');
            }
            else if (destination is Chest)
            {
                Chest currentChest = destination as Chest;
                currentChest.OpenChest();
            }
            else
            {
                UI.WriteToInfoArea("You cannot move north!");
            }
        }

        //Move player East on the map and handles different cases depending on the destination tile properties
        public void MoveEast()
        {
            Position newPosition = new Position((Position.XCoord + 1), Position.YCoord);
            var destination = Tile.GetTileAtDestination(newPosition);

            if (Position.XCoord < 158 && !(destination is Obstacle))
            {
                Position.XCoord++;
                UI.DrawPlayer(this);
                Console.SetCursorPosition((Position.XCoord - 1), Position.YCoord);
                Console.Write(' ');
            }
            else if (destination is Chest)
            {
                Chest currentChest = destination as Chest;
                currentChest.OpenChest();
            }
            else
            {
                UI.WriteToInfoArea("You cannot move east!");
            }
        }

        //Move player South on the map and handles different cases depending on the destination tile properties
        public void MoveSouth()
        {
            Position newPosition = new Position(Position.XCoord, (Position.YCoord + 1));
            var destination = Tile.GetTileAtDestination(newPosition);

            if (Position.YCoord < 44 && !(destination is Obstacle))
            {
                Position.YCoord++;
                UI.DrawPlayer(this);
                Console.SetCursorPosition(Position.XCoord, (Position.YCoord - 1));
                Console.Write(' ');
            }
            else if (destination is Chest)
            {
                Chest currentChest = destination as Chest;
                currentChest.OpenChest();
            }
            else
            {
                UI.WriteToInfoArea("You cannot move south!");
            }
        }

        //Move player West on the map and handles different cases depending on the destination tile properties
        public void MoveWest()
        {
            Position newPosition = new Position((Position.XCoord - 1), Position.YCoord);
            var destination = Tile.GetTileAtDestination(newPosition);

            if (Position.XCoord > 1 && !(destination is Obstacle))
            {
               Position.XCoord--;
               UI.DrawPlayer(this);
               Console.SetCursorPosition((Position.XCoord + 1), Position.YCoord);
               Console.Write(' ');
            }
            else if (destination is Chest)
            {
               Chest currentChest = destination as Chest;
               currentChest.OpenChest();
            }
            else
            {
                UI.WriteToInfoArea("You cannot move west!");
            }
        }

        public void AttackWithWeapon(Monster monster)
        {
            int damage = RNG.GenerateNumber(EquippedWeapon.MinimumDamage, EquippedWeapon.MaximumDamage);
            monster.CurrentHp -= damage;
            if (monster.CurrentHp <= 0)
            {
                monster.CurrentHp = 0;
            }      
            UI.WriteToBattleInfoArea($"{Name} hits the {monster.Name} for {damage} damage. {monster.Name} now has {monster.CurrentHp} hp remaining.", UI.CYAN);
            Console.ResetColor();
        }
    }
}
