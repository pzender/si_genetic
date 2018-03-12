using System;
using System.Linq;

namespace SI_Genetic
{

    public class Phenotype
    {
        public Phenotype(GeneticAlgorithm parameters)
        {
            this.parameters = parameters;
            Genotype = new int[parameters.Input.Size];
            Random r = new Random();
        }

        public void RandomizeGenotype()
        {
            Random r = new Random();
            Genotype = Enumerable.Range(1, parameters.Input.Size).OrderBy(n => r.Next()).ToArray();
        }

        GeneticAlgorithm parameters;
        public int[] Genotype { get; set; }

        public void Mutate()
        {
            for (int i = 0; i < Genotype.Length; i++)
            {
                Random r = new Random();
                if (r.NextDouble() < parameters.P_mutation)
                {
                    int swapWith = r.Next(Genotype.Length);

                    //swap with a randomly chosen other gene
                    int tmp = Genotype[i];
                    Genotype[i] = Genotype[swapWith];
                    Genotype[swapWith] = tmp;
                }
            }

        }

        public Phenotype Crossover(Phenotype other)
        {
            Random r = new Random();
            int splice_point = r.Next(parameters.Input.Size);
            Phenotype child = new Phenotype(parameters);
            for (int i = 0; i < splice_point; i++)
            {
                child.Genotype[i] = this.Genotype[i];
            }
            for (int i = splice_point; i < child.Genotype.Length; i++)
            {
                
                if (child.Genotype.Contains(other.Genotype[i]) == false) //ideally - if we can take the second half from the second parent - that's great, let's go for it
                {
                    child.Genotype[i] = other.Genotype[i];
                }
                else if (child.Genotype.Contains(other.Genotype[i]) == false) //let's see if we can grab the second half from the first parent 
                {
                    child.Genotype[i] = this.Genotype[i];
                }
                else
                { //shove whatever we can
                    int[] available = Enumerable.Range(1, parameters.Input.Size)
                        .Where(n => child.Genotype.Contains(n) == false)
                        .OrderBy(m => r.Next())
                        .ToArray();
                    child.Genotype[i] = available[0];
                }
            }

            return child;
        }

        public Phenotype Clone()
        {
            return new Phenotype(parameters)
            {
                Genotype = this.Genotype.ToArray()
            };
        }
    }
}