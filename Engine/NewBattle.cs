using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class NewBattle
    {
        enum BattleState
        {
            INIT,
            CHOOSE_PLAYER_ACTION,
            PROCESS_PLAYER_ACTION,
            CHOOSE_MONSTER_ACTION,
            PROCESS_MONSTER_ACTION,
            CHECK_FOR_DEATH
        };

        static bool BattleActive = false;
        static bool IsValid = true;
        static BattleState currentState = BattleState.INIT;

        public static Entity StartBattle(Monster monster, Player player)
        {
            Entity victim = null;
            Spell spellToCast;
            BattleActive = true;
            ConsoleKeyInfo battleCommand;

            do
            {
                switch (currentState)
                {
                    case BattleState.INIT:
                        {
                            UI.ClearMessageBox();
                            UI.BattleUIBuffer.Clear();
                            UI.CurrentBattleConsoleLine = 34;
                            Console.SetCursorPosition(0, 0);

                            UI.WriteBattleInstructions();
                            UI.WriteToBattleInfoArea("A battle with " + monster.Name + " begins!", UI.DEFAULT);
                            currentState = BattleState.CHOOSE_PLAYER_ACTION;
                            break;
                        }

                    case BattleState.CHOOSE_PLAYER_ACTION:
                        {
                            do
                            {
                                IsValid = true;
                                battleCommand = Console.ReadKey(true);

                                switch (battleCommand.Key)
                                {
                                    case ConsoleKey.A:
                                        {
                                            player.AttackWithWeapon(monster);
                                            break;
                                        }

                                    case ConsoleKey.S:
                                        {
                                            spellToCast = ChooseSpell(player);

                                            if (spellToCast != null)
                                            {
                                                Spell.CastSpell(spellToCast, player, monster);
                                                break;
                                            }
                                            else
                                            {
                                                IsValid = false;
                                            }
                                            break;
                                        }

                                    default:
                                        {
                                            UI.WriteToBattleInfoArea("Please choose a correct command", UI.DEFAULT);
                                            IsValid = false;
                                            break;
                                        }
                                }

                                UI.ClearBattleMenuScreen();

                            } while (!IsValid);
                            //currentState = BattleState.PROCESS_PLAYER_ACTION;
                            break;
                        }

                    case BattleState.PROCESS_PLAYER_ACTION:
                        {
                            switch (battleCommand.Key)
                            {
                                
                            }
                            break;
                        }

                    case BattleState.CHOOSE_MONSTER_ACTION:
                        {
                            break;
                        }

                    case BattleState.PROCESS_MONSTER_ACTION:
                        {
                            break;
                        }

                    case BattleState.CHECK_FOR_DEATH:
                        {
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            } while (BattleActive);

            return victim;
        }

        public static Spell ChooseSpell(Player player)
        {
            UI.WriteToBattleInfoArea("Press the letter of the spell to cast or press (z) to exit menu", UI.DEFAULT);
            UI.DrawSpellMenu(player);

            bool isValid;
            int spellChoice;

            do
            {
                isValid = true;
                ConsoleKeyInfo battleMenuCommand;
                battleMenuCommand = Console.ReadKey(true);

                if (battleMenuCommand.KeyChar.ToString() == "z")
                {
                    return null;
                }

                spellChoice = ((int)battleMenuCommand.KeyChar) - 97;

                if (player.KnownSpells.Count > spellChoice && spellChoice >= 0)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    UI.WriteToBattleInfoArea("Please choose an existing spell from the list", UI.DEFAULT);
                }

            } while (!isValid);

            return player.KnownSpells[spellChoice];
        }
    }
}
