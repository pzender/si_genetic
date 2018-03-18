using System;

namespace SI_Genetic
{

    public abstract class Generation
    {
        public Generation(GeneticAlgorithm parameters)
        {
            this.parameters = parameters;
            this.Population = new Phenotype[parameters.Population_size];
            for(int i = 0; i < parameters.Population_size; i++)
            {
                Population[i] = new Phenotype(parameters);
            }
            
        }
        protected GeneticAlgorithm parameters;
        public Phenotype[] Population { get; private set; }


        public int BestRating()
        {
            int best_rating = parameters.Evaluate(Population[0].Genotype);
            foreach (Phenotype p in Population)
            {
                if (parameters.Evaluate(p.Genotype) < best_rating)
                    best_rating = parameters.Evaluate(p.Genotype);
            }
            return best_rating;
        }
        public int AverageRating()
        {
            int sum_rating = 0;
            foreach (Phenotype p in Population)
            {
                sum_rating += parameters.Evaluate(p.Genotype);
            }
            return sum_rating / Population.Length;

        }
        public int WorstRating()
        {
            int worst_rating = parameters.Evaluate(Population[0].Genotype);
            foreach (Phenotype p in Population)
            {
                if (parameters.Evaluate(p.Genotype) > worst_rating)
                    worst_rating = parameters.Evaluate(p.Genotype);
            }
            return worst_rating;

        }

        protected Phenotype BestPhenotype(Phenotype[] population)
        {
            Phenotype best = population[0];
            foreach (Phenotype p in population)
            {
                if (parameters.Evaluate(p.Genotype) < parameters.Evaluate(best.Genotype))
                    best = p;
            }
            return best;
        }

        public Phenotype BestPhenotype()
        {
            Phenotype best = Population[0];
            foreach (Phenotype p in Population)
            {
                if (parameters.Evaluate(p.Genotype) < parameters.Evaluate(best.Genotype))
                    best = p;
            }
            return best;
        }

        protected abstract Phenotype Selection();


        public Generation NextGeneration()
        {
            Generation nextGeneration;
            //brzydkie to to cokolwiek
            if(this is GenerationTournament)
            {
                nextGeneration = new GenerationTournament(this.parameters);
            }
            else if(this is GenerationRoulette)
            {
                nextGeneration = new GenerationRoulette(this.parameters);
            }
            else
            {
                nextGeneration = null;
                throw new Exception("unknown generation type");
            }
            for (int i = 0; i < Population.Length; i += 2) //using 2 phenotypes from current generation we create 2 for the next one
            {
                Random r = new Random();

                //SELECTION
                Phenotype parent_a = Selection();
                Phenotype parent_b = Selection();
                Phenotype child_a;
                Phenotype child_b;

                //CROSSOVER
                if (r.NextDouble() < parameters.P_crossover)
                {
                    child_a = parent_a.Crossover(parent_b);
                    child_b = parent_b.Crossover(parent_a);
                }
                else
                {
                    //TU ZEPSUŁEŚ!
                    child_a = parent_a.Clone();
                    child_b = parent_b.Clone();
                }

                //MUTATION
                child_a.Mutate();
                child_b.Mutate();

                //ADD TO NEW GENERATION
                nextGeneration.Population[i] = child_a;
                if(i+1 < Population.Length)
                    nextGeneration.Population[i + 1] = child_b;
            }

            return nextGeneration;

        }
    }
}
