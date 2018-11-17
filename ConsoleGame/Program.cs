using System;
using System.Threading;
using System.Runtime.InteropServices;

using Engine;

namespace ConsoleGame
{
    public static class Program
    {
        ////////////////////////////////////
        // Used to prevent console resize //
        ////////////////////////////////////
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        ////////////////////////////////////

        enum State { Battle, Exploration, Menu }

        private static Player _player;

        //DebugVariables
        static Monster standardMonster = World.Monsters[0];

        static void Main(string[] args)
        {
            ////////////////////////////////////
            // Used to prevent console resize //
            ////////////////////////////////////
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }
            ////////////////////////////////////

            //Create the new player
            _player = Player.CreateNewPlayer();
            _player.EquippedWeapon = World.Weapons[1];

            foreach (var item in World.Spells)
            {
                _player.KnownSpells.Add(item);
            }

            //Bools
            bool _gameOver = false;

            //Enum
            State value = State.Exploration;

            ////////////////////////////////////

            _player.CharacterCreation();

            Console.Clear();

            Console.CursorVisible = false;

            UI.Initialize();
            UI.DrawGUI(_player);
            UI.DrawGameScreen();
            UI.DrawPlayer(_player);
            MapManager.DrawMap();

            do
            {
                if (value == State.Exploration)
                {
                    UI.DrawGUI(_player);
                    value = ParseCommand();
                }

                else if (value == State.Battle)
                {
                    Monster _currentMonster = new Monster(standardMonster.Name, standardMonster.Damage, standardMonster.MaxHP, standardMonster.ExperiencePointsValue, standardMonster.GoldValue);

                    Console.Clear();
                    UI.DrawBattleScreen();
                    UI.DrawGUI(_player);

                    Entity dead = NewBattle.StartBattle(_currentMonster, _player);

                    if (dead == _currentMonster)
                    {

                        value = State.Exploration;
                        Console.Clear();
                        UI.DrawGameScreen();
                        MapManager.DrawMap();
                        UI.DrawPlayer(_player);
                    }
                    else
                    {
                        UI.WriteToInfoArea("You are dead. GAME OVER");
                        _gameOver = true;
                    }
                }
                
            } while (!_gameOver);

            Console.WriteLine("It seems that you have been killed");
            Console.ReadKey();
        }

        //Take the user keypress and handles the case, depending on the the key that was pressed
        static State ParseCommand()
        {
            bool isValid = true;

            do
            {
                isValid = true;
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow :
                        {
                            _player.MoveEast();
                            break;
                        }

                    case ConsoleKey.LeftArrow:
                        {
                            _player.MoveWest();
                            break;
                        }

                    case ConsoleKey.UpArrow:
                        {
                            _player.MoveNorth();
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            _player.MoveSouth();
                            break;
                        }

                    case ConsoleKey.I:
                        {
                            break;
                        }

                    case ConsoleKey.B:
                        {
                            return State.Battle;
                        }
                    default:
                        {
                            UI.WriteToInfoArea("Please choose a correct command.");
                            isValid = false;
                            break;
                        }
                }

                return State.Exploration;

            } while (!isValid);
        }            
    }
}