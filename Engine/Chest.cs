using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Chest : Obstacle
    {
        public bool Looted = false;

        public Chest(int x, int y) : base(x, y)
        {
            //Content = content;
        }

        public void OpenChest()
        {
            if (!Looted)
            {
                UI.WriteToInfoArea("You open the chest and you find : XXX.");
                Console.SetCursorPosition(X, Y);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write('C');
                Looted = true;
                Console.ResetColor();
            }
            else
            {
                UI.WriteToInfoArea("You already opened that chest and it's now empty.");
            }
        }
    }
}
