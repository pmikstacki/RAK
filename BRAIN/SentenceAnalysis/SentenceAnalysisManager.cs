using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRAIN.Actions;
using NLog.Targets;

namespace BRAIN.SentenceAnalysis
{
    public class SentenceAnalysisManager
    {
        public void Analyze(string Sentence)
        {
            Console.WriteLine("Analizuję zdanie "+Sentence);
            Console.WriteLine("Zdanie po depolsyfikacji: "+DePolish(Sentence));
            Parallel.ForEach<string>(DePolish(Sentence).Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries), x =>
            {
                Console.WriteLine("sprawdzam dominantę dla "+x);
                Parallel.ForEach<IAction>(ActionManager.Actions, a =>
                {
                    if (a.Dominants.Any(s => x.Contains(DePolish(s))))
                    {
                        Console.WriteLine("Znalazłem dominantę dla akcji: "+a.Name);
                        a.Execute(Sentence);
                    }
                });
            });
            
        }

        private string DePolish(string Sentence)
        {
            return Sentence.ToLower().Replace('ą', 'a').Replace('ł', 'l').Replace('ż', 'z').Replace('ź', 'z')
                .Replace('ó', 'o').Replace('ś', 's').Replace('ć', 'c').Replace(",", "").Replace(".", "");
        }
    }
}