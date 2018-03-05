using System;
using System.IO;
using SI_Genetic;

class Program
{
    static void Main(string[] args)
    {
        GeneticAlgorithm test = new GeneticAlgorithm(500, 0.7, 0.01, 8, 200, "input12.txt");
        test.Input.ReadFile();
        Phenotype best = test.Run();

        for(int i = 0; i < test.Input.Size; i++)
        {
            Console.Write($"{best.Genotype[i]}, ");
        }
        Console.WriteLine();
        //Console.WriteLine($"{DateTime.Now}");
    }
}

