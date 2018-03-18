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
                    //Console.WriteLine("nOfGenerations: ");
                    //int nOfGenerations = Int32.Parse(Console.ReadLine());
                    //Console.WriteLine("p_crossover: ");
                    //double p_crossover = Double.Parse(Console.ReadLine());
                    //Console.WriteLine("p_mutation: ");
                    //double p_mutation = Double.Parse(Console.ReadLine());
                    //Console.WriteLine("tourn_size: ");
                    //int tourn_size = Int32.Parse(Console.ReadLine());
                    //Console.WriteLine("pop_size: ");
                    //int pop_size = Int32.Parse(Console.ReadLine());
                    //Console.WriteLine("test_case: ");
                    //int gen_test_case = Int32.Parse(Console.ReadLine());

                    //base
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    //test selection
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.01, SelectionMethod.Roulette,     1, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.01, SelectionMethod.Tournament,   1, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.01, SelectionMethod.Tournament,   2, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.01, SelectionMethod.Tournament,  10, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.01, SelectionMethod.Tournament,  25, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.01, SelectionMethod.Tournament, 100, $"input{12}.txt"); test.Run();
                    //test mutation
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.00, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.02, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.05, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.10, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.20, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.50, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 1.00, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    //test crossover
                    test = new GeneticAlgorithm(100, 100, 0.0, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.2, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.4, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.5, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.6, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.8, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 1.0, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    //test pop-size
                    test = new GeneticAlgorithm(100,  10, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100,  20, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100,  50, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 200, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 500, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    //test gen-count
                    test = new GeneticAlgorithm( 10, 100, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm( 20, 100, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm( 50, 100, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(100, 100, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(200, 100, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    test = new GeneticAlgorithm(500, 100, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    //test both
                    test = new GeneticAlgorithm(500, 500, 0.7, 0.01, SelectionMethod.Tournament, 5, $"input{12}.txt"); test.Run();
                    Console.WriteLine("done!");

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

