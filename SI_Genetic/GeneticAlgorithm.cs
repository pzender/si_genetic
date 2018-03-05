using System;
using System.IO;

namespace SI_Genetic
{

    public class GeneticAlgorithm
    {
        public GeneticAlgorithm(int nOfGenerations, double p_crossover, double p_mutation, int tournament_size, int population_size, string inputFileName)
        {
            this.Input = new InputData(inputFileName);
            this.NOfGenerations = nOfGenerations;
            this.P_crossover = p_crossover;
            this.P_mutation = p_mutation;
            this.Tournament_size = tournament_size;
            this.Population_size = population_size;

            this.sw = new StreamWriter("../../../genetic_output.csv");
        }

        public void Initialize()
        {
            cur_generation = new Generation(this);
            foreach (Phenotype p in cur_generation.Population)
                p.RandomizeGenotype();
            best = cur_generation.BestPhenotype();
            sw.WriteLine(DateTime.Now);
            sw.WriteLine($"generations: {NOfGenerations}, p_crossover: {P_crossover}, p_mutation: {P_mutation}, t_size: {Tournament_size}, pop_size: {Population_size}");
        }

        public int NOfGenerations { get; private set; }
        public double P_crossover { get; private set; }
        public double P_mutation { get; private set; }
        public int Tournament_size { get; private set; }
        public int Population_size { get; private set; }
        public InputData Input { get; private set; }


        Phenotype best;
        Generation cur_generation;

        StreamWriter sw;

        public Phenotype Run()
        {
            Initialize();
            for (int i = 0; i < NOfGenerations; i++)
            {
                //report results
                string GenerationResults = $"{i}, {cur_generation.BestRating()}, {cur_generation.AverageRating()}, {cur_generation.WorstRating()}\n";
                Console.Write(GenerationResults);
                sw.Write(GenerationResults);

                //next generation
                cur_generation = cur_generation.NextGeneration();
                if (cur_generation.BestPhenotype().Evaluate() < best.Evaluate())
                    best = cur_generation.BestPhenotype();

            }
            return best;

        }
    }
}
