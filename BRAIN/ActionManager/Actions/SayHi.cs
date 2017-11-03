using System;
using System.Collections.Generic;

namespace BRAIN.Actions
{
    internal class SayHi : IAction
    {
        public SayHi()
        {
            Id = 1;
            Name = "SayHi";
            Description = "Mówi czesć";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<string> Dominants { get; set; } = new List<string> {"czesc", "wita", "elo"};

        public void Execute(object argument)
        {
            Console.WriteLine("Cześć!");
        }
    }
}