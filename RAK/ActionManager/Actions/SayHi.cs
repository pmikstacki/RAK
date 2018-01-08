using System;
using System.Collections.Generic;

namespace RAK.Actions
{
    
    internal class SayHi : IAction
    {
        Random r = new Random();
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
            MainWindow._current.AddMessage(new List<string>() {"Cześć", "Witaj", "Siemsone"}[r.Next(0, 2)], false);
        }
    }
}