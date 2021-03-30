using System;

namespace Predictor
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = FoodGenerator.Generate(20, 10);
            var dishes = FoodGenerator.Generate(100, 10);
            var cents = Clusterer.GetClusters(guests, 3, 100);
            //Console.WriteLine(cents.Length);
            var menu = Clusterer.GetMenu(cents, dishes, 10);
            foreach (double[] dish in menu)
            {
                foreach(double ing in dish)
                {
                    Console.Write(ing + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
