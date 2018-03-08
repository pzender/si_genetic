using System;
using System.Linq;

namespace SI_Genetic
{
    public class RandomAlgorithm : QAPAlgorithm
    {
        public RandomAlgorithm(int top_of, string filename) : base(filename)
        {
            this.top_of = top_of;
        }

        int top_of;
        public override int[] Run()
        {
            int[] best = Roll();
            for(int i = 1; i < top_of; i++)
            {
                int[] new_roll = Roll();
                if (Evaluate(best) > Evaluate(new_roll))
                    best = new_roll;
            }
            sw.WriteLine();
            for (int i = 0; i < Input.Size; i++)
            {
                sw.Write($"{best[i]}, ");
            }
            sw.WriteLine(Evaluate(best));
            sw.Close();
            return best;
        }


        public int[] Roll()
        {
            Random r = new Random();
            return Enumerable.Range(1, Input.Size).OrderBy(n => r.Next()).ToArray();
        }
    }
}