using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor
{
    public class FoodGenerator
    {
        public static double[][] Generate(Int32 n_dishes, Int32 n_ing)
        {
            var DishSet = new double[n_dishes][];
            Random random = new Random();
            for(int i = 0; i < n_dishes; i++)
            {
                var Dish = new double[n_ing];
                for (int j = 0; j < n_ing; j++)
                {
                    Dish[j] = random.Next(2);
                }
                DishSet[i] = Dish;
            }
            return DishSet;
        }
    }
}
