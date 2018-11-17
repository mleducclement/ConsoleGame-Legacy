using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Engine
{
    public static class MapManager
    {
        public static string[] Map = new string[] { };


        //Reads each lines of TextMap to populate the tiles list in World.cs with X, Y and the type of tile, based on the character used in the TextMap
        public static void PopulateTileList()
        {
            Map = File.ReadAllLines(@"R:\C#\Repos\Archive\ConsoleGame\TextMap.txt");

            int currentLine = 3;

            foreach (string line in Map)
            {
                for (int i = 1; i <= line.Length; i++)
                {
                    
                    char currentCharacter = line[i - 1];

                    if (currentCharacter == 'X')
                    {
                        World.Tiles.Add(new Wall(i, currentLine));
                    }
                    else if (currentCharacter == 'C')
                    {
                        World.Tiles.Add(new Chest(i, currentLine));
                    }
                    else if (currentCharacter == ' ')
                    {
                        World.Tiles.Add(new Tile(i, currentLine));
                    }  
                }
                currentLine++;
            }
        }

        //Draw the map and set the appropriate character depending on the input from the TextMap file
        public static void DrawMap()
        {
            foreach (Tile tile in World.Tiles)
            {
                if (tile is Wall)
                {
                    Console.SetCursorPosition(tile.X, tile.Y);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write('#');
                    Console.ResetColor();
                }
                else if (tile is Chest)
                {
                    if ((tile as Chest).Looted)
                    {
                        Console.SetCursorPosition(tile.X, tile.Y);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write('C');
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.SetCursorPosition(tile.X, tile.Y);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('C');
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
