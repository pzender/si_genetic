using System;
using SI_Genetic;

class Program
{
    static void Main(string[] args)
    {
        QAPAlgorithm test = null;
        
        string command = "";

        while (command != "exit")
        {
            command = Console.ReadLine();
            switch (command)
            {
                case "gen":
                    Console.WriteLine("nOfGenerations: ");
                    int nOfGenerations = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("p_crossover: ");
                    double p_crossover = Double.Parse(Console.ReadLine());
                    Console.WriteLine("p_mutation: ");
                    double p_mutation = Double.Parse(Console.ReadLine());
                    Console.WriteLine("tourn_size: ");
                    int tourn_size = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("pop_size: ");
                    int pop_size = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("test_case: ");
                    int gen_test_case = Int32.Parse(Console.ReadLine());

                    test = new GeneticAlgorithm(nOfGenerations, p_crossover, p_mutation, tourn_size, pop_size, $"input{gen_test_case}.txt");
                   
                    break;
                case "grd":
                    Console.WriteLine("starting_point: ");
                    int starting_point = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("test_case: ");
                    int grd_test_case = Int32.Parse(Console.ReadLine());

                    test = new GreedyAlgorithm(starting_point, $"input{grd_test_case}.txt");
                   
                    break;
                case "rnd":
                    Console.WriteLine("best_of: ");
                    int best_of = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("test_case: ");
                    int rnd_test_case = Int32.Parse(Console.ReadLine());

                    test = new RandomAlgorithm(best_of, $"input{rnd_test_case}.txt");

                    break;
                default:
                    Console.WriteLine("wut");
                    break;

            }

            if (test != null)
            {
                test.Input.ReadFile();
                Console.WriteLine(test.Evaluate(test.Run()));
            }
        }
    }
}

