using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CSScriptLibrary;
namespace RAK.Actions
{
    /// <summary>
    /// Klasa służąca do ładowania skryptów oraz akcji wdrożonych
    /// </summary>
    public class ActionManager
    {
        public static List<IAction> Actions = new List<IAction>();
        /// <summary>
        /// Konstruktor klasy. Sprawdza czy istnieje folder.
        /// </summary>
        public ActionManager()
        {
            Actions.Add(new SayHi());
            Actions.Add(new Connect());
            if (!Directory.Exists("ActionScripts"))
            {
                Console.WriteLine("Directory for custom scripts doesn't exists, I'm creating one for you...");
                Directory.CreateDirectory("ActionScripts");
            }
            else
            {
                Console.WriteLine("Loading custom actions...");
                Parallel.ForEach(Directory.GetFiles("ActionScripts", "*.csx"), x =>
                {
                    try
                    {
                        Actions.Add(CSScript.Evaluator.LoadFile<IAction>(x));
                        Console.WriteLine("Found custom action: "+CSScript.Evaluator.LoadFile<IAction>(x).Dominants[0]);
                   
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                });

            }
            Console.WriteLine(Actions.Count.ToString());

        }
    }

    public static class ScriptProvider
    {
        public static void AddMessage(string message)
        {
            MainWindow._current.AddMessage(message, false);
        }
    }

}