using System.Collections.Generic;

namespace BRAIN.Actions
{
    public interface IAction
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        List<string> Dominants { get; set; }
        void Execute(object argument);
    }
}