using System;
using System.IO;

namespace SI_Genetic
{

    public class GeneticAlgorithm : QAPAlgorithm
    {
        public GeneticAlgorithm(int nOfGenerations, double p_crossover, double p_mutation, int tournament_size, int population_size, string inputFileName) : base(inputFileName)
        {
            this.NOfGenerations = nOfGenerations;
            this.P_crossover = p_crossover;
            this.P_mutation = p_mutation;
            this.Tournament_size = tournament_size;
            this.Population_size = population_size;

            
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
        //public InputData Input { get; private set; }


        Phenotype best;
        Generation cur_generation;


        public override int[] Run()
        {
            Initialize();
            for (int i = 0; i < NOfGenerations; i++)
            {
                //report results
                string GenerationResults = $"{i}, {cur_generation.BestRating()}, {cur_generation.AverageRating()}, {cur_generation.WorstRating()}\n";
                sw.Write(GenerationResults);

                //next generation
                cur_generation = cur_generation.NextGeneration();
                if (Evaluate(cur_generation.BestPhenotype().Genotype) < Evaluate(best.Genotype))
                    best = cur_generation.BestPhenotype();

            }

            sw.WriteLine();
            for (int i = 0; i < Input.Size; i++)
            {
                sw.Write($"{best.Genotype[i]}, ");
            }
            sw.WriteLine(Evaluate(best.Genotype));

            sw.Close();

            return best.Genotype;

        }
    }
}
