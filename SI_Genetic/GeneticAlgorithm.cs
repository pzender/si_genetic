﻿using System;
using System.IO;

namespace SI_Genetic
{
    public enum SelectionMethod { Roulette, Tournament};
    public class GeneticAlgorithm : QAPAlgorithm
    {
        
        public GeneticAlgorithm(int nOfGenerations, int population_size, double p_crossover, double p_mutation, SelectionMethod selection, int tournament_size, string inputFileName) : base(inputFileName)
        {
            this.NOfGenerations = nOfGenerations;
            this.P_crossover = p_crossover;
            this.P_mutation = p_mutation;
            this.Tournament_size = tournament_size;
            this.Population_size = population_size;
            if (selection == SelectionMethod.Roulette)
                cur_generation = new GenerationRoulette(this);
            else if (selection == SelectionMethod.Tournament)
                cur_generation = new GenerationTournament(this);
            
        }

        public void Initialize()
        {
            foreach (Phenotype p in cur_generation.Population)
                p.RandomizeGenotype();
            best = cur_generation.BestPhenotype();
            sw.WriteLine("SEP=;");
            sw.WriteLine(DateTime.Now);
            sw.WriteLine($"generations: {NOfGenerations}, p_crossover: {P_crossover}, p_mutation: {P_mutation}, t_size: {Tournament_size}, pop_size: {Population_size}, selection: {cur_generation.GetType().ToString()}");
            Console.WriteLine($"generations: {NOfGenerations}, p_crossover: {P_crossover}, p_mutation: {P_mutation}, t_size: {Tournament_size}, pop_size: {Population_size}, selection: {cur_generation.GetType().ToString()}");
        }

        public int NOfGenerations { get; private set; }
        public double P_crossover { get; private set; }
        public double P_mutation { get; private set; }
        public int Tournament_size { get; private set; }
        public int Population_size { get; private set; }

        Phenotype best;
        Generation cur_generation;
        

        public override int[] Run()
        {
            Initialize();
            for (int i = 0; i < NOfGenerations; i++)
            {
                //report results
                string GenerationResults = $"{i};{cur_generation.BestRating()};{cur_generation.AverageRating()};{cur_generation.WorstRating()}\n";
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
