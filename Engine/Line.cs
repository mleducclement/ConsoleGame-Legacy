using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Line
    {
        public string Content;
        public ConsoleColor Color;

        public Line(string content, ConsoleColor color)
        {
            Content = content;
            Color = color;
        }
    }
}
