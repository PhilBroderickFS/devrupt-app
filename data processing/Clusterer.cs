using System;
using System.Collections.Generic;


namespace Predictor
{
	public class Clusterer
	{
		public static double[][] GetClusters(double[][] data, Int32 num_clusters, Int32 steps)
        {
			double[][] kdata = (double[][])data.Clone();
			double[][] centroids = new double[num_clusters][];
			var clusters = new List<List<double[]>>();


			for(int i = 0; i < num_clusters; i++)
            {
				clusters.Add(new List<double[]>());
            }


			kdata = Tools.Shuffle(kdata);
			for(int i = 0; i < num_clusters; i++) //randomly choose centroids
            {
				centroids[i] = kdata[i];
            }

			for(int s = 0; s < steps; s++)
            {
				Console.WriteLine("Iteration: " + (s+1));
				foreach (var point in kdata)
				{
					var distances = new double[num_clusters];
					for (int i = 0; i < num_clusters; i++)
					{
						var dist = Tools.Evcdist(centroids[i], point);
						distances[i] = dist;
					}
					var mini = Tools.MinIndex(distances);
					clusters[mini].Add(point);
				}

				for(int c = 0; c < num_clusters; c++)
                {
					centroids[c] = new double[kdata[0].Length];
					for (int d = 0; d < kdata[0].Length; d++)
					{
						foreach (var point in clusters[c])
						{
							centroids[c][d] += point[d];
						}
						centroids[c][d] /= clusters[c].Count;
					}


                }
			}

			

			return centroids;
        }


		public static dynamic GetMenu(double[][] guests_g, double[][] dishes, int n_dishes)
        {
			var menu = new List<double[]>();
			var clusters = new List<List<double[]>>();
			var n_groups = guests_g.Length;
			Console.WriteLine(guests_g.Length);

			for (int i = 0; i < n_groups; i++)
			{
				clusters.Add(new List<double[]>());
			}
			Console.WriteLine(clusters.Count);


			foreach (var point in dishes)
			{
				var distances = new double[n_groups];
				for (int i = 0; i < n_groups; i++)
				{
					var dist = Tools.Evcdist(guests_g[i], point);
					distances[i] = dist;
				}
				var mini = Tools.MinIndex(distances);
				clusters[mini].Add(point);
			}

			for (int i = 0; i < clusters.Count; i++) 
            {
				//Console.WriteLine(clusters[i].Count);
				clusters[i] = Tools.SortList(clusters[i]);
				menu.Add(clusters[i][0]);
				menu.Add(clusters[i][1]);
				menu.Add(clusters[i][2]);

			}
			menu.Add(clusters[0][3]);

            double[][] vs = menu.ToArray();
			return vs;
        }
	}
}