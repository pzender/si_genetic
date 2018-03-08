using System;
using System.Linq;

namespace SI_Genetic
{
    public class GreedyAlgorithm : QAPAlgorithm
    {
        public GreedyAlgorithm(int startingPoint, string filename) : base(filename)
        {
            this.startingPoint = startingPoint;
        }

        int startingPoint;

        public override int[] Run()
        {
            sw.WriteLine(DateTime.Now);
            sw.WriteLine($"starting_point: {startingPoint}");
            int[] result = new int[Input.Size];
            result[0] = startingPoint;
            for(int i = 1; i < Input.Size; i++)
            {
                int[] available = Enumerable.Range(1, Input.Size)
                        .Where(n => result.Contains(n) == false)
                        .ToArray();
                int closest = i+1;
                foreach(int n in available)
                {
                    if (Input.Distances[i - 1, i] * Input.Flows[result[i], n-1] < Input.Distances[i - 1, i] * Input.Flows[result[i], closest-1])
                        closest = n;
                }
                result[i] = closest;
            }
            sw.WriteLine();
            for (int i = 0; i < Input.Size; i++)
            {
                sw.Write($"{result[i]}, ");
            }
            sw.WriteLine(Evaluate(result));
            sw.Close();

            return result;
        }
    }

}