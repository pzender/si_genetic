using System;
using System.Collections.Generic;
using System.Linq;

namespace SI_Genetic { 
    public class GenerationRoulette : Generation
    {
        public GenerationRoulette(GeneticAlgorithm parameters) : base(parameters) { }

        override protected Phenotype Selection()
        {
            int bestRating = BestRating();
            int worstRating = WorstRating();
            Phenotype chosen = null;

            Random r = new Random();
            Dictionary<Phenotype, int> selectionPoints = new Dictionary<Phenotype, int>();
            int sumOfPoints = 0;
            foreach (Phenotype ph in Population)
            {
                int points = worstRating - parameters.Evaluate(ph.Genotype);
                selectionPoints.Add(ph, points);
                sumOfPoints += points;
            }

            int randomized = r.Next(sumOfPoints);
            int cumulativeSum = 0;
            for (int i = 0; i < Population.Length && chosen == null; i++)
            {
                cumulativeSum += selectionPoints[Population[i]];
                if (randomized < cumulativeSum)
                    chosen = Population[i];
            }

            return chosen;
        }
     
    }
}

