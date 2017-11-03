using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BRAIN.SentenceAnalysis
{
    internal class SentenceAnalysisManager
    {
        public List<string> SimplifyOutput(string Sentence)
        {
            Parallel.ForEach<string>(DePolish(Sentence).Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries), x =>
            {
                Parallel.ForEach
            });
            throw new Exception("String is empty!");
        }

        private string DePolish(string Sentence)
        {
            return Sentence.ToLower().Replace('ą', 'a').Replace('ł', 'l').Replace('ż', 'z').Replace('ź', 'z')
                .Replace('ó', 'o').Replace('ś', 's').Replace('ć', 'c');
        }
    }
}