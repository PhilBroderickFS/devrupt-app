using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor
{
    public class Tools
    {
        public static double Evcdist(double[] a, double[] b)
        {
            double temp = 0;
            for(int i = 0; i < a.Length; i++)
            {
                temp += Math.Pow(b[i] - a[i], 2);
            }
            double dist = Math.Sqrt(temp);
            return dist;
        }

        public static double Vlen(double[] a)
        {
            double temp = 0;
            for (int i = 0; i < a.Length; i++)
            {
                temp += Math.Pow(a[i], 2);
            }
            double len = Math.Sqrt(temp);
            return len;
        }

        public static double[][] Shuffle(double[][] data)
        {
            double[][] shuffled = (double[][])data.Clone();
            for (int i = shuffled.Length - 1; i > 0; i--)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, i + 1);

                double[] temp = shuffled[i];
                shuffled[i] = shuffled[randomIndex];
                shuffled[randomIndex] = temp;
            }
            return shuffled;
        }

        public static int MinIndex(double[] arr)
        {


            var min = arr[0];
            int minIndex = 0;

            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public static dynamic SortList(dynamic lst)
        {
            var size = lst.Count;
            var lens = new double[size];
            for (int i = 0; i < size; i++)
            {
                lens[i] = Vlen(lst[i]);
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    if (lens[i] > lens[j])
                    {
                        var temp = lst[i];
                        lst[i] = lst[j];
                        lst[j] = temp;
                    }
                }
            }
            return lst;
        }

    }
}
