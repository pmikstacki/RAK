using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAK.Actions;

namespace RAK.ActionManager
{

    /// <summary>
    /// Ta klasa służy sortowaniu akcji do wywołania aby zsycnhronizować i ustandaryzować kolejnosć wykonywania akcji
    /// </summary>
    
    public static class ActionScheduler
    {

        private static List<IAction> Actions = new List<IAction>();
        public static void ScheduleAction(IAction action)
        {
            Actions.Add(action);
        }


    }
}
