using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public static class Battle
    {
        private static bool BattleActive = false;
        private static bool isValid = true;

        public static Entity StartBattle(Monster monster, Player player)
        {
            Entity victim = null;
            Spell spellToCast;
            BattleActive = true;
            ConsoleKeyInfo battleCommand;

            do
            {
                do
                {
                    isValid = true;
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
                                    isValid = false;
                                }
                                break;
                            }

                        default:
                            {
                                UI.WriteToBattleInfoArea("Please choose a correct command", UI.DEFAULT);
                                isValid = false;
                                break;
                            }
                    }

                    UI.ClearBattleMenuScreen();

                } while (!isValid);

                if (CheckIfIsDead(monster))
                {
                    UI.WriteToBattleInfoArea("The monster lies dead at your feet. You get " + monster.ExperiencePointsValue + " Experience and " + monster.GoldValue + " Gold.", UI.DEFAULT);
                    BattleActive = false;
                    victim = monster;
                    break;
                }

                monster.DamagePlayer(player);

                //Update GUI
                UI.DrawGUI(player);

                if (CheckIfIsDead(player))
                {
                    UI.WriteToBattleInfoArea("Sadly, you were defeated by the " + monster.Name + ". Your deeds will never be known to the rest of the world.", UI.DEFAULT);
                    BattleActive = false;
                    victim = player;
                    break;
                }
            } while (BattleActive);

            UI.CurrentConsoleLine = 46 + UI.UIBuffer.Count;
            return victim;
        }

        public static bool CheckIfIsDead(Entity entity)
        {
            int entityHp = entity.CurrentHp;

            if (entityHp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
