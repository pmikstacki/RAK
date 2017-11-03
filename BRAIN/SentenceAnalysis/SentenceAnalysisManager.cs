using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BRAIN.Actions;
using NLog.Targets;

namespace BRAIN.SentenceAnalysis
{
    public class SentenceAnalysisManager
    {
        public void Analyze(string Sentence)
        {
            List<dominant> dominants = new List<dominant>();

            Console.WriteLine("Analizuję zdanie "+Sentence);
            Console.WriteLine("Zdanie po depolsyfikacji: "+DePolish(Sentence));
            Parallel.ForEach<string>(DePolish(Sentence).Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries), x =>
            {
                Console.WriteLine("sprawdzam dominantę dla "+x);
                Parallel.ForEach<IAction>(ActionManager.Actions, a =>
                {
                    if (a.Dominants.Any(s => x.Contains(DePolish(s))))
                    {
                        Console.WriteLine("Znalazłem dominantę dla akcji: "+a.Name+", słowo: "+x);
                        if(!Exists(a))
                            dominants.Add(new dominant() {actionName = a.Name});
                    }
                });
            });
            bool Exists(IAction action)
            {
                if (dominants.Any(l => l.actionName == action.Name))
                {
                    dominants.Find(o => o.actionName == action.Name).count += 1;
                }
                else
                {
                    Console.WriteLine("Nie znaleziono....");
                    return false;
                }
                return false;
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Dominanty: ");
            Console.WriteLine("Nazwa | Ilośc Wystąpień");
            Console.WriteLine("------|----------------");
            foreach (var VARIABLE in dominants)
            {
                Console.WriteLine(VARIABLE.actionName + " | "+VARIABLE.count.ToString() );
            }
        }

        private string DePolish(string Sentence)
        {
            return Sentence.ToLower().Replace('ą', 'a').Replace('ł', 'l').Replace('ż', 'z').Replace('ź', 'z')
                .Replace('ó', 'o').Replace('ś', 's').Replace('ć', 'c').Replace(",", "").Replace(".", "");
        }




        private class dominant
        {
            public string actionName;
            public int count = 1;
        }
    }
}