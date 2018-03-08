using System;
using System.IO;

namespace SI_Genetic
{
    public abstract class QAPAlgorithm
    {
        public QAPAlgorithm(string filename)
        {
            this.Input = new InputData(filename);
            string output_file = $"../../../output_files/output-{this.GetType().Name}-{DateInProperFormat()}";
            while (File.Exists(output_file + ".csv"))
            {
                output_file += "_new";
            }
            this.sw = new StreamWriter(output_file + ".csv");
        }
        public abstract int[] Run();
        protected StreamWriter sw;
        public InputData Input { get; private set; }


        protected string DateInProperFormat()
        {
            return
                String.Format("{0:d2}.", DateTime.Now.Month) +
                String.Format("{0:d2}-", DateTime.Now.Day) +
                String.Format("{0:d2}.", DateTime.Now.Hour) +
                String.Format("{0:d2}.", DateTime.Now.Minute) +
                String.Format("{0:d2}", DateTime.Now.Millisecond);
        }

        public int Evaluate(int[] result)
        {
            int sum = 0;
            for (int i = 0; i < Input.Size; i++)
            {
                for (int j = 0; j < Input.Size; j++)
                {
                    sum += (Input.Flows[i, j] * Input.Distances[result[i] - 1, result[j] - 1]);
                }
            }
            return sum;
        }
    }
}