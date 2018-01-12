using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RAK.Actions;

namespace RAK.SentenceAnalysis
{
    public class SentenceAnalysisManager
    {   
        /// <summary>
        /// Analizuje Treść podanego zdania, depolsyfikuje (usuwa polskie znaki)
        /// oraz wykonuje podaną/e akcję/e
        /// <param name="Sentence">Zdanie do przetworzenia</param>
        /// </summary>
        public void Analyze(string Sentence)
        {
            var dominants = new List<dominant>();

            Console.WriteLine("Analizuję zdanie " + Sentence);
            Console.WriteLine("Zdanie po depolsyfikacji: " + DePolish(Sentence));
            foreach (string x in DePolish(Sentence).Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries))
            {
                Console.WriteLine("sprawdzam dominantę dla " + x);
                foreach (IAction a in ActionManager.Actions)
                {
                    if (a.Dominants.Any(s => x.Contains(DePolish(s))))
                    {
                        a.Execute(new object());
                        Console.WriteLine("Znalazłem dominantę dla akcji: " + a.Name + ", słowo: " + x);
                        if (!Exists(a))
                            dominants.Add(new dominant {actionName = a.Name});



                    }
                }
            }

            bool Exists(IAction action)
            {
                if (dominants.Any(l => l.actionName == action.Name))
                {
                    dominants.Find(o => o.actionName == action.Name).count += 1;
                    return true;
                }
                return false;
                return false;
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Dominanty: ");
            Console.WriteLine("Nazwa | Ilośc Wystąpień");
            Console.WriteLine("------|----------------");
            foreach (var VARIABLE in dominants)
                Console.WriteLine(VARIABLE.actionName + " | " + VARIABLE.count);
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