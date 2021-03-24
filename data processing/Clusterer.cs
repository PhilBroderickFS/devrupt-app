using System;
using System.Collections;

namespace Predictor
{
	public class Clusterer
	{
		public static double[][] GetClusters(double[][] data, Int32 num_clusters, Int32 steps)
        {
			double[][] kdata = (double[][])data.Clone();
			double[][] centroids = new double[num_clusters][];
			double[][][] clusters = new double[num_clusters][][];
			kdata = Tools.Shuffle(kdata);
			for(int i = 0; i < num_clusters; i++) //randomly choose centroids
            {
				centroids[i] = kdata[i];
            }

			for(int s = 0; s < steps; s++)
            {
				foreach (var point in kdata)
				{
					var distances = new double[num_clusters];
					for (int i = 0; i < num_clusters; i++)
					{
						var dist = Tools.Evcdist(centroids[i], point);
						distances[i] = dist;
					}
					var mini = Tools.MinIndex(distances);
					clusters[mini][] = point; //idk
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
						centroids[c][d] /= clusters[c].Length;
					}


                }
			}

			

			return centroids;
        }
	}
}