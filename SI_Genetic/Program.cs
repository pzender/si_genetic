using System;
using SI_Genetic;

class Program
{
    static void Main(string[] args)
    {
        int instance = 12;
        int TIMES_TO_RUN = 12;
        QAPAlgorithm test;
        
        int genetic_sum = 0;
        for (int i = 0; i < TIMES_TO_RUN; i++)
        {
            test = new GeneticAlgorithm(100, 0.7, 0.01, 8, 100, $"input{instance}.txt");
            test.Input.ReadFile();
            genetic_sum += (test.Evaluate(test.Run()));
            Console.WriteLine($"Genetic {i + 1}");
        }

        Console.WriteLine($"GENETIC : {genetic_sum / TIMES_TO_RUN} points.");


        int greedy_sum = 0;
        for (int i = 0; i < TIMES_TO_RUN; i++)
        {
            test = new GreedyAlgorithm(i%instance +1, $"input{instance}.txt");
            test.Input.ReadFile();
            greedy_sum += (test.Evaluate(test.Run()));
            Console.WriteLine($"Greedy {i + 1}");
        }

        Console.WriteLine($"GREEDY  : {greedy_sum / TIMES_TO_RUN} points.");


        int random_sum = 0;
        for (int i = 0; i < TIMES_TO_RUN; i++)
        {
            test = new RandomAlgorithm(1000, $"input{instance}.txt");
            test.Input.ReadFile();
            random_sum += (test.Evaluate(test.Run()));
            Console.WriteLine($"Random {i + 1}");
        }

        Console.WriteLine($"RANDOM  : {random_sum / TIMES_TO_RUN} points.");
    }

}

