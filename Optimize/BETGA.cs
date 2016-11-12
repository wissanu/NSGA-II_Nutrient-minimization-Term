using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Optimize.GA
{

    class BETGA
    {
        public delegate double GAFunction(double[] values);
        private static Random rand = new Random();
        public static int x = 10;
        public static int y = 10;
        public static int z = 7;
        public static Form1 myform = new Form1();

        public class GA
        {
            public double MutationRate;
            public double CrossoverRate;
            public int ChromosomeLength;
            public int PopulationSize;
            public int GenerationSize;
            public bool Elitism;
            public double best_fitness = 0.0;
            public double[] best_chromosome;
            private ArrayList CurrentParentList;
            private ArrayList CurrentChildList;
            private ArrayList TotalChunk;
            private ArrayList FitnessList;
            public int count_error = 0;
            static private GAFunction getFitness;
            static private GAFunction getFat;
            static private GAFunction getProtien;
            static private GAFunction getCarbo;
            public double best_fat = 0.0;
            public double best_protien = 0.0;
            public double best_carbo = 0.0;
            public double best_cal = 0.0;

            public GAFunction FitnessFunction
            {
                get { return getFitness; }
                set { getFitness = value; }
            }
            public GAFunction FatFunction
            {
                get { return getFat; }
                set { getFat = value; }
            }
            public GAFunction ProtienFunction
            {
                get { return getProtien; }
                set { getProtien = value; }
            }
            public GAFunction CarboFunction
            {
                get { return getCarbo; }
                set { getCarbo = value; }
            }
            public GA(double XoverRate, double mutRate, int popSize, int genSize, int ChromLength)
            {
                Elitism = false;
                MutationRate = mutRate;
                CrossoverRate = XoverRate;
                PopulationSize = popSize;
                GenerationSize = genSize;
                ChromosomeLength = ChromLength;
            }

            public void LaunchGA()
            {
                CurrentParentList = new ArrayList(GenerationSize/2);
                CurrentChildList = new ArrayList(GenerationSize/2);
                TotalChunk = new ArrayList(GenerationSize);
                best_chromosome = new double[ChromosomeLength];
                Chromosome.ChromosomeMutationRate = MutationRate;

                // initial population
                int j = 0;
                string x = ""; string y = ""; string z = ""; string k = "";
                while (j < PopulationSize/2)
                {
                    Chromosome g = new Chromosome(ChromosomeLength, true);
                    g.fat = FatFunction(g.ChromosomeGenes);
                    g.protien = ProtienFunction(g.ChromosomeGenes);
                    g.carbo = CarboFunction(g.ChromosomeGenes);
                    g.ChromosomeFitness = FitnessFunction(g.ChromosomeGenes);
                    if (((g.ChromosomeFitness >= 0.0 && g.ChromosomeFitness <= 2000.0) && (g.fat >= 45.0 && g.fat <= 65.0) && (g.protien >= 55.0 && g.protien <= 120.0)) == true)
                    {
                        CurrentParentList.Add(g);
                        j++;
                    }
                    else
                        count_error += 1;

                    if (count_error == 100000)
                        break;

                }
                if (count_error == 100000)
                {
                    best_fitness = -100000;
                }
                else
                {
                    FastDominatedSort("parent");
                    CrowdingDistanceAssign("parent");

                    for (int i = 0; i < GenerationSize; i++)
                    {
                        CreateNextGeneration();
                        FastDominatedSort("totalchunk");
                        CrowdingDistanceAssign("totalchunk");

                        CurrentParentList.Clear();
                        for(int q = 0; q < PopulationSize/2; q++)
                        {
                            CurrentParentList.Add((Chromosome)TotalChunk[q]);
                        }
                    }
                    for (int l = 0; l < PopulationSize / 2; l++)
                    {
                        x += ((Chromosome)CurrentParentList[l]).ChromosomeFitness + "\n";
                        y += ((Chromosome)CurrentParentList[l]).fat + "\n";
                        z += ((Chromosome)CurrentParentList[l]).Prank + "\n";
                        k += ((Chromosome)CurrentParentList[l]).Crowding_ds + "\n";
                    }
                    using (StreamWriter writerpop_n_gen = new StreamWriter("C:\\Users\\wissanu\\Desktop\\output_GA\\popx.txt"))
                    {
                        writerpop_n_gen.WriteLine(x);
                        writerpop_n_gen.Close();
                    }
                    using (StreamWriter writerpop_n_gen = new StreamWriter("C:\\Users\\wissanu\\Desktop\\output_GA\\popy.txt"))
                    {
                        writerpop_n_gen.WriteLine(y);
                        writerpop_n_gen.Close();
                    }
                    using (StreamWriter writerpop_n_gen = new StreamWriter("C:\\Users\\wissanu\\Desktop\\output_GA\\popz.txt"))
                    {
                        writerpop_n_gen.WriteLine(z);
                        writerpop_n_gen.Close();
                    }
                    using (StreamWriter writerpop_n_gen = new StreamWriter("C:\\Users\\wissanu\\Desktop\\output_GA\\popk.txt"))
                    {
                        writerpop_n_gen.WriteLine(k);
                        writerpop_n_gen.Close();
                    }
                    best_fitness = ((Chromosome)CurrentParentList[0]).ChromosomeFitness;
                    for (int p = 0; p < ChromosomeLength; p++)
                        best_chromosome[p] = ((Chromosome)CurrentParentList[0]).ChromosomeGenes[p];

                    best_fat = ((Chromosome)CurrentParentList[0]).fat;
                    best_protien = ((Chromosome)CurrentParentList[0]).protien;
                    best_carbo = ((Chromosome)CurrentParentList[0]).carbo;
                    
                }
            }
            
            private void FastDominatedSort(string refer)
            {
                ArrayList temp_pop = new ArrayList();
                if(refer == "parent")
                    for(int i =0; i< PopulationSize/2; i++)
                        temp_pop.Add((Chromosome)CurrentParentList[i]);
                if(refer == "totalchunk")
                    for (int i = 0; i < PopulationSize; i++)
                        temp_pop.Add((Chromosome)TotalChunk[i]);

                foreach (var p in temp_pop)
                {
                    ((Chromosome)p).nich_count = 0;
                    foreach(var q in temp_pop)
                    {
                        if(((Chromosome)p).ChromosomeFitness >= ((Chromosome)q).ChromosomeFitness && ((Chromosome)p).fat >= ((Chromosome)q).fat )
                            ((Chromosome)p).nich_count += 1;
                    }
                }
                temp_pop.Sort(new ChromosomeComparernich());

                for(int i = 0; i < ((refer=="parent")?PopulationSize/2:PopulationSize); i++)
                {
                    Chromosome c = ((Chromosome)temp_pop[i]);
                    Chromosome previous = (i == 0) ? ((Chromosome)temp_pop[i]) : ((Chromosome)temp_pop[i - 1]);
                    if (i == 0)
                        c.Prank = 1;
                    else if (c.nich_count == previous.nich_count)
                        c.Prank = previous.Prank;
                    else if (c.nich_count > previous.nich_count)
                        c.Prank = previous.Prank + 1;
                }
                temp_pop.Sort(new ChromosomeComparerParetoFront());

                if (refer == "parent")
                {
                    CurrentParentList.Clear();
                    for (int i = 0; i < PopulationSize / 2; i++)
                        CurrentParentList.Add((Chromosome)temp_pop[i]);
                }
                if (refer == "totalchunk")
                {
                    TotalChunk.Clear();
                    for (int i = 0; i < PopulationSize; i++)
                        TotalChunk.Add((Chromosome)temp_pop[i]);
                }
            }

            private void CrowdingDistanceAssign(string refer)
            {
                ArrayList temp_pop = new ArrayList();
                if (refer == "parent")
                    for (int i = 0; i < PopulationSize / 2; i++)
                        temp_pop.Add((Chromosome)CurrentParentList[i]);
                if (refer == "totalchunk")
                    for (int i = 0; i < PopulationSize; i++)
                        temp_pop.Add((Chromosome)TotalChunk[i]);
                
                int count_rank = 0;
                List<int> carry_total_count_rank = new List<int>();

                for (int i = 0; i < ((refer == "parent") ? PopulationSize / 2 : PopulationSize); i++)
                {
                    count_rank += 1;
                    if (i != ((refer == "parent") ? (PopulationSize / 2) - 1 : PopulationSize - 1))
                    {
                        if (((Chromosome)temp_pop[i]).Prank != ((Chromosome)temp_pop[i + 1]).Prank)
                        {
                            carry_total_count_rank.Add(count_rank);
                            count_rank = 0;
                        }
                    }
                    else
                        carry_total_count_rank.Add(count_rank);
                }
                int f_step = -1;
                int start = 0, end = 0;
                for( int k = 0; k < carry_total_count_rank.Count; k++)
                {
                    if (f_step == -1)
                    { start = 0; end = carry_total_count_rank[k];}
                    else
                    { start += end; end += carry_total_count_rank[k]; }

                    Console.WriteLine("{0} : {1}", start , end);
                    for (int i = start; i < end; i++)
                    {
                        Chromosome g = ((Chromosome)temp_pop[i]);
                        g.Crowding_ds = ( i == start)? 0.0: (i == end-1)? 1.0: (((Chromosome)temp_pop[i+1]).ChromosomeFitness - ((Chromosome)temp_pop[i-1]).ChromosomeFitness)/ (((Chromosome)temp_pop[end-1]).ChromosomeFitness - ((Chromosome)temp_pop[start]).ChromosomeFitness) + (((Chromosome)temp_pop[i + 1]).fat - ((Chromosome)temp_pop[i - 1]).fat) / (((Chromosome)temp_pop[end - 1]).fat - ((Chromosome)temp_pop[start]).fat);
                        if(i == end-1)
                        {
                            f_step = 1;
                            start = 0;
                        }
                    }
                }
                if (refer == "parent")
                {
                    CurrentParentList.Clear();
                    for (int i = 0; i < PopulationSize / 2; i++)
                        CurrentParentList.Add((Chromosome)temp_pop[i]);
                }
                if (refer == "totalchunk")
                {
                    TotalChunk.Clear();
                    for (int i = 0; i < PopulationSize; i++)
                        TotalChunk.Add((Chromosome)temp_pop[i]);
                }
            }

            private void CreateNextGeneration()
            {
                CurrentChildList.Clear();

                int i = 0;
                bool dup_child1 = false;
                bool dup_child2 = false;
                while (i < (PopulationSize/2))
                {
                    Chromosome parent1, parent2, child1, child2;
                    parent1 = TournamentSelection();
                    parent2 = TournamentSelection();
                    if (rand.NextDouble() < CrossoverRate)
                    { parent1.Crossover(ref parent2, out child1, out child2); }
                    else
                    {
                        child1 = parent1;
                        child2 = parent2;
                    }
                    child1.Mutate();
                    child2.Mutate();
                    // prepare constraint for check calories, fat and protien of child1
                    child1.fat = FatFunction(child1.ChromosomeGenes);
                    child1.protien = ProtienFunction(child1.ChromosomeGenes);
                    child1.carbo = CarboFunction(child1.ChromosomeGenes);
                    child1.ChromosomeFitness = Math.Abs(FitnessFunction(child1.ChromosomeGenes));
                    // prepare constraint for check calories, fat and protien of child2
                    child2.fat = FatFunction(child2.ChromosomeGenes);
                    child2.protien = ProtienFunction(child2.ChromosomeGenes);
                    child2.carbo = CarboFunction(child2.ChromosomeGenes);
                    child2.ChromosomeFitness = Math.Abs(FitnessFunction(child2.ChromosomeGenes));

                    if ((child2.ChromosomeFitness >= 0.0 && child2.ChromosomeFitness <= 2000.0) &&(child1.ChromosomeFitness >= 0.0 && child1.ChromosomeFitness <= 2000.0) == true)
                    {
                        if (((child1.fat >= 45.0 && child1.fat <= 65.0) && (child1.protien >= 55.0 && child1.protien <= 120.0) && (child2.fat >= 45.0 && child2.fat <= 65.0) && (child2.protien >= 55.0 && child2.protien <= 120.0)) == true)
                        {
                            foreach (var x in CurrentChildList)
                            {
                                if (((Chromosome)x).ChromosomeFitness == child1.ChromosomeFitness)
                                {
                                    dup_child1 = true;
                                    break;
                                }
                            }
                            foreach (var y in CurrentChildList)
                            {
                                if (((Chromosome)y).ChromosomeFitness == child1.ChromosomeFitness)
                                {
                                    dup_child2 = true;
                                    break;
                                }
                            }
                            if (!dup_child1 && !dup_child2)
                            {
                                CurrentChildList.Add(child1);
                                CurrentChildList.Add(child2);
                                i += 2;
                                dup_child1 = false;
                                dup_child2 = false;
                            }
                            else { dup_child1 = false; dup_child2 = false; }
                        }
                    }
                }
                
                for (int k = 0; k < PopulationSize/2; k++)
                    TotalChunk.Add(CurrentParentList[k]);
                for (int k = 0; k < PopulationSize / 2; k++)
                    TotalChunk.Add(CurrentChildList[k]);
            }
            private Chromosome TournamentSelection()
            {
                ArrayList parent = new ArrayList();
                double versus = 0.25;
                Chromosome best = null;
                for(int i = 0; i < (PopulationSize/2)*versus; i++)
                    parent.Add(((Chromosome)CurrentParentList[rand.Next(0, PopulationSize / 2)]));

                best = ((Chromosome)parent[0]);
                for(int i = 0; i < (PopulationSize / 2) * versus; i++)
                {
                    if(i!=0)
                    {
                        if (best.Prank > ((Chromosome)parent[i]).Prank)
                        {
                            best = (Chromosome)parent[i];
                        }
                        else if (best.Prank == ((Chromosome)parent[i]).Prank)
                        {
                            if (best.Crowding_ds < ((Chromosome)parent[i]).Crowding_ds)
                                best = (Chromosome)parent[i];
                        }
                        else { }
                    }
                }
                return best;
            }
        }

        public class Chromosome
        {
            public double[] ChromosomeGenes;
            public int ChromosomeLength;
            public double ChromosomeFitness;
            public static double ChromosomeMutationRate;
            public double fat;
            public double protien;
            public double carbo;
            public int Prank;
            public int nich_count;
            public double Crowding_ds;

            //สร้าง chromosome 
            public Chromosome(int length, bool createGenes)
            {
                ChromosomeLength = length;
                ChromosomeGenes = new double[length];
                if (createGenes)
                {
                    for (int i = 0; i < ChromosomeLength; i++)
                    {
                        if (i < myform.lm)
                            ChromosomeGenes[i] = (double)rand.Next(0, x);
                        if (i >= myform.lm && i < (myform.lm + myform.mm))
                            ChromosomeGenes[i] = (double)rand.Next(0, y);
                        if (i >= (myform.lm + myform.mm) && i < (myform.lm + myform.mm + myform.nn))
                            ChromosomeGenes[i] = (double)rand.Next(0, z);
                    }
                }
            }


            public void Crossover(ref Chromosome Chromosome2, out Chromosome child1, out Chromosome child2)
            {
                int first_position = (int)(rand.NextDouble() * (double)ChromosomeLength);
                int second_position = (int)(rand.NextDouble() * (double)ChromosomeLength);
                int range_position1 = (first_position <= second_position) ? first_position : second_position; ;
                int range_position2 = (second_position >= first_position) ? second_position : first_position; ;
                child1 = new Chromosome(ChromosomeLength, false);
                child2 = new Chromosome(ChromosomeLength, false);
                for (int i = 0; i < ChromosomeLength; i++)
                {
                    if (i < range_position1)
                    {
                        child1.ChromosomeGenes[i] = ChromosomeGenes[i];
                        child2.ChromosomeGenes[i] = Chromosome2.ChromosomeGenes[i];
                    }
                    else if (((i >= range_position1) && (i <= range_position2)) == true)
                    {
                        child1.ChromosomeGenes[i] = Chromosome2.ChromosomeGenes[i];
                        child2.ChromosomeGenes[i] = ChromosomeGenes[i];
                    }
                    else
                    {
                        child1.ChromosomeGenes[i] = ChromosomeGenes[i];
                        child2.ChromosomeGenes[i] = Chromosome2.ChromosomeGenes[i];
                    }
                }
            }
            //Mutates the chromosome genes by randomly switching them around 
            public void Mutate()
            {
                int swap_select, swap_replace;
                double temp;

                for (int i = 0; i < myform.lm; i++)
                {
                    swap_select = rand.Next(0, myform.lm);
                    swap_replace = rand.Next(0, myform.lm);
                    if (rand.NextDouble() < ChromosomeMutationRate)
                    {
                        temp = ChromosomeGenes[swap_select];
                        ChromosomeGenes[swap_select] = ChromosomeGenes[swap_replace];
                        ChromosomeGenes[swap_replace] = temp;
                    }
                }
                for (int i = myform.lm; i < myform.lm + myform.mm; i++)
                {
                    swap_select = rand.Next(myform.lm, (myform.lm + myform.mm));
                    swap_replace = rand.Next(myform.lm, (myform.lm + myform.mm));
                    if (rand.NextDouble() < ChromosomeMutationRate)
                    {
                        temp = ChromosomeGenes[swap_select];
                        ChromosomeGenes[swap_select] = ChromosomeGenes[swap_replace];
                        ChromosomeGenes[swap_replace] = temp;
                    }
                }
                for (int i = myform.lm + myform.mm; i < myform.lm + myform.mm + myform.nn; i++)
                {
                    swap_select = rand.Next((myform.lm + myform.mm), (myform.lm + myform.mm + myform.nn));
                    swap_replace = rand.Next((myform.lm + myform.mm), (myform.lm + myform.mm + myform.nn));
                    if (rand.NextDouble() < ChromosomeMutationRate)
                    {
                        temp = ChromosomeGenes[swap_select];
                        ChromosomeGenes[swap_select] = ChromosomeGenes[swap_replace];
                        ChromosomeGenes[swap_replace] = temp;
                    }
                }
                /*if (position < myform.lm)
                    ChromosomeGenes[position] = (double)rand.Next(0, x);
                if (position >= myform.lm && position < (myform.lm + myform.mm))
                    ChromosomeGenes[position] = (double)rand.Next(0, y);
                if (position >= (myform.lm + myform.mm) && position < (myform.lm + myform.mm + myform.nn))
                    ChromosomeGenes[position] = (double)rand.Next(0, z); */
            }

        }
        public sealed class ChromosomeComparernich : IComparer
        {
            public int Compare(object x, object y)
            {
                if (!(x is Chromosome) || !(y is Chromosome))
                    throw new ArgumentException("Not of type Chromosome");
                if (((Chromosome)x).nich_count > ((Chromosome)y).nich_count)
                    return 1;
                else if (((Chromosome)x).nich_count== ((Chromosome)y).nich_count)
                    return 0;
                else
                    return -1;
            }
        }

        public sealed class ChromosomeComparerParetoFront : IComparer
        {
            public int Compare(object x, object y)
            {
                if (!(x is Chromosome) || !(y is Chromosome))
                    throw new ArgumentException("Not of type Chromosome");
                if (((Chromosome)x).Prank == ((Chromosome)y).Prank)
                {
                    if (((Chromosome)x).ChromosomeFitness > ((Chromosome)y).ChromosomeFitness)
                        return 1;
                    else if (((Chromosome)x).ChromosomeFitness == ((Chromosome)y).ChromosomeFitness)
                        return 0;
                    else
                        return -1;
                }
                else if (((Chromosome)x).Prank > ((Chromosome)y).Prank)
                    return 0;
                else
                    return -1;
            }
        }


        public static void Main(string[] args)
        {
            Application.Run(myform);

            /*ga.GetWorst(out values, out fitness);
            System.Console.WriteLine("\nWorst ({0}):", fitness);
            for (int i = 0; i < values.Length; i++)
                System.Console.Write("{0} ", values[i]);*/

            Console.ReadLine();
        }


    }
}
