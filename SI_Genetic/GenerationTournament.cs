using System;
using System.Collections.Generic;
using System.Linq;

namespace SI_Genetic { 
    public class GenerationTournament : Generation
    {
        public GenerationTournament(GeneticAlgorithm parameters) : base(parameters) { }

        override protected Phenotype Selection()
        {
            int t_size = parameters.Tournament_size;
            Phenotype[] tournament = new Phenotype[t_size];
            for (int i = 0; i < t_size; i++)
            {
                Random r = new Random();
                tournament[i] = Population[r.Next(Population.Length)];
            }
            return BestPhenotype(tournament);
        }
     
    }
}

