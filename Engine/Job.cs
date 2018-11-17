using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Job
    {
        public string Name;
        public int StartingHP;

        public Job(string name, int startingHP)
        {
            Name = name;
            StartingHP = startingHP;
        }
    }
}
