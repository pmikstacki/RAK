using System.Collections.Generic;

namespace RAK.Actions
{
    public class ActionManager
    {
        public static List<IAction> Actions = new List<IAction>();

        public ActionManager()
        {
            Actions.Add(new SayHi());
            Actions.Add(new Connect());
        }
    }
}