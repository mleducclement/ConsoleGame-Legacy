using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public static class UI
    {
        private const int CONSOLE_WIDTH = 160;
        private const int CONSOLE_HEIGHT = 57;
        private const string TITLE = "Console RPG";
        private const string HORIZ_DASH_LINE = " --------------------------------------------------------------------------------" +
                                               "------------------------------------------------------------------------------";
        private const string HORIZ_SOLID_LINE = "____________________________________________________________" +
                                                "___________________________________________________________";

        public const ConsoleColor RED = ConsoleColor.Red;
        public const ConsoleColor MAGENTA = ConsoleColor.DarkMagenta;
        public const ConsoleColor CYAN = ConsoleColor.Cyan;
        public const ConsoleColor GREEN = ConsoleColor.Green;
        public const ConsoleColor DEFAULT = ConsoleColor.White;

        public static int CurrentConsoleLine = 57;
        public static int CurrentBattleConsoleLine;

        public static List<String> UIBuffer = new List<String>();
        public static List<Line> BattleUIBuffer = new List<Line>();

        //Initialize game windows with the correct title and size
        public static void Initialize()
        {
            Console.SetWindowSize(CONSOLE_WIDTH, CONSOLE_HEIGHT);
            Console.Title = TITLE;
        }

        public static void DrawGameScreen()
        {
            for (int i = 3; i < 45; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine('|');
                Console.SetCursorPosition(159, i);
                Console.WriteLine('|');
            }
            Console.SetCursorPosition(0, 45);
            Console.WriteLine(HORIZ_DASH_LINE);
        }

        //Draw the player stats information panel
        public static void DrawGUI(Player player)
        {
            
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(HORIZ_DASH_LINE);
            Console.SetCursorPosition(0, 1);
            UI.FillLine(' ');
            Console.SetCursorPosition(17, 1);
            Console.WriteLine("Name : {0}", player.Name);
            Console.SetCursorPosition(47, 1);
            Console.WriteLine("HP : {0}/{1}", player.CurrentHp, player.MaxHP);
            Console.SetCursorPosition(77, 1);
            Console.WriteLine("EXP : {0}/{1}", player.CurrentEXP, player.XpToNextLevel);
            Console.SetCursorPosition(107, 1);
            Console.WriteLine("LVL : {0}", player.Level);
            Console.SetCursorPosition(127, 1);
            Console.WriteLine("Class : {0}", player.CurrentJob.Name);
            Console.WriteLine(HORIZ_DASH_LINE);
        }

        //Draw the player on the map
        public static void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.Position.XCoord, player.Position.YCoord);
            Console.WriteLine('@');
        }

        //Draw the battle screen
        public static void DrawBattleScreen()
        {
            for (int i = 3; i < 45; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine('|');
                Console.SetCursorPosition(19, i);
                Console.WriteLine('|');
                Console.SetCursorPosition(139, i);
                Console.WriteLine('|');
                Console.SetCursorPosition(159, i);
                Console.WriteLine('|');
            }
            Console.SetCursorPosition(20, 35);
            Console.WriteLine(HORIZ_SOLID_LINE);
            Console.SetCursorPosition(0, 45);
            Console.WriteLine(HORIZ_DASH_LINE);
        }

        //Draw the spell menu screen in battle and display spells according to the player's list of known spells in a 4*3 "table"
        public static void DrawSpellMenu(Player player)
        {
            int cursorPositionY = 37;

            int spellNumber = 1;

            int spellIndex;

            if (player.KnownSpells.Count == 0)
            {
                Console.SetCursorPosition(40, cursorPositionY);
                Console.Write("No Known Spell");
            }
            else
            {
                foreach (Spell spell in player.KnownSpells)
                {
                    if (spellNumber < 5)
                    {
                        Console.SetCursorPosition(21, cursorPositionY);
                        spellIndex = (player.KnownSpells).IndexOf(spell) + 97;
                        Console.Write(Convert.ToChar(spellIndex) + ".");
                        Console.SetCursorPosition(24, cursorPositionY);
                        Console.Write(spell.Name);
                        Console.SetCursorPosition(40, cursorPositionY);
                        Console.Write(spell.MpCost.ToString() + " MP");
                        spellNumber++;
                        cursorPositionY += 2;
                    }
                    else if (spellNumber > 4 && spellNumber < 9)
                    {
                        if (cursorPositionY > 43)
                        {
                            cursorPositionY = 37;
                        }
                        Console.SetCursorPosition(65, cursorPositionY);
                        spellIndex = (player.KnownSpells).IndexOf(spell) + 97;
                        Console.Write(Convert.ToChar(spellIndex) + ".");
                        Console.SetCursorPosition(68, cursorPositionY);
                        Console.Write(spell.Name);
                        Console.SetCursorPosition(84, cursorPositionY);
                        Console.Write(spell.MpCost.ToString() + " MP");
                        spellNumber++;
                        cursorPositionY += 2;
                    }
                    else
                    {
                        if (cursorPositionY > 43)
                        {
                            cursorPositionY = 37;
                        }
                        Console.SetCursorPosition(111, cursorPositionY);
                        spellIndex = (player.KnownSpells).IndexOf(spell) + 97;
                        Console.Write(Convert.ToChar(spellIndex) + ".");
                        Console.SetCursorPosition(114, cursorPositionY);
                        Console.Write(spell.Name);
                        Console.SetCursorPosition(129, cursorPositionY);
                        Console.Write(spell.MpCost.ToString() + " MP");
                        spellNumber++;
                        cursorPositionY += 2;
                    }
                }
            }
        }

        //Helper method to clear the part of the console where the game message will appear
        public static void ClearMessageBox()
        {
            for (int iy = 46; iy <= 56; iy++)
            {
                Console.SetCursorPosition(0, iy);
                UI.FillLine(' ');
            }
        }

        //Helper method to clear the part of the console where the battle messages will appear
        public static void ClearBattleMessageBox()
        {
            for (int iy = 6; iy < 35; iy++)
            {
                Console.SetCursorPosition(20, iy);
                UI.FillLine(' ', 119);
            }
        }

        //Helper method to clear the battle menu part of the console 36 - 44
        public static void ClearBattleMenuScreen()
        {
            for (int iy = 36; iy < 45; iy++)
            {
                Console.SetCursorPosition(20, iy);
                UI.FillLine(' ', 119);
            }
        }

        //Display the argument string to the game message area, if the message area is full, replace the first line with the new message
        public static void WriteToInfoArea(string message)
        {
            if (CurrentConsoleLine <= 46)
            {
                UIBuffer.RemoveAt(10);
                UIBuffer.Insert(0, message);
                ClearMessageBox();

                for (int i = 0; i < UIBuffer.Count; i++)
                {
                    Console.SetCursorPosition(0, (56 - i));
                    Console.WriteLine(UIBuffer[i]);
                }
            }
            else
            {
                ClearMessageBox();
                Console.SetCursorPosition(0, CurrentConsoleLine);
                UIBuffer.Add(message);
                for (int i = 0; i < UIBuffer.Count; i++)
                {
                    Console.SetCursorPosition(0, (56 - i));
                    Console.WriteLine(UIBuffer[i]);
                }
                CurrentConsoleLine--;
            }
        }

        //Display the argument string to the battle message area, if the message area is full, replace the first line with the new message
        public static void WriteToBattleInfoArea(string message, ConsoleColor color, bool addToBuffer = true)
        {
            Line line = new Line(message, color);

            if (BattleUIBuffer.Count >= 28)
            {
                BattleUIBuffer.RemoveAt(BattleUIBuffer.Count - 1);
                BattleUIBuffer.Insert(0, line);
                ClearBattleMessageBox();

                for (int i = 0; i < BattleUIBuffer.Count; i++)
                {
                    Console.SetCursorPosition(21, (34 - i));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(BattleUIBuffer[i].Content);
                }
            }
            else
            {
                BattleUIBuffer.Add(line);
                Console.SetCursorPosition(21, CurrentBattleConsoleLine);
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                CurrentBattleConsoleLine--;
            }
            Console.ResetColor();
        }

        public static void WriteBattleInstructions()
        {
            Console.SetCursorPosition(21, 3);
            Console.WriteLine("Choose a command to execute by typing the corresponding letter.");
            Console.SetCursorPosition(21, 4);
            Console.WriteLine("(a) to attack / (s) to cast a spell / (i) for items / (r) to run away");
            Console.SetCursorPosition(21, 5);
            Console.WriteLine("------------------------------------------------------------------------------------");
        }

        //Center the argument string and displays it in the game message area
        public static void CenterText(string text)
        {
            Console.WriteLine(new string(' ', (Console.WindowWidth - text.Length) / 2));
        }

        //Add X blank lines to the message area
        public static void AddBlankLines(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine();
            }
        }

        //Fill a line with the argument character
        public static void FillLine(char character, int length = 160)
        {
            string completeText = string.Empty;

            while (completeText.Length < length)
            {
                completeText += character;
            }

            Console.Write(completeText);
        }
    }
}
