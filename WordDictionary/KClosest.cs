using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordDictionary
{
    public class KClosest
    {
        public int[][] GetKClosestPoints(int[][] points, int k)
        {
            var pointsSorted = new SortedSet<int>(Comparer<int>.Create((i, j) =>
            {
                var dist1 = points[i][0] * points[i][0] + points[i][1] * points[i][1];
                var dist2 = points[j][0] * points[j][0] + points[j][1] * points[j][1];
                return dist1 != dist2 ? dist1.CompareTo(dist2) : i.CompareTo(j);
            }));
            for (var i = 0; i < points.GetLength(0); i++)
            {
                var max = pointsSorted.Max;
                if (pointsSorted.Count == k)
                {
                    if (GetDist(points, i) < GetDist(points, max))
                    {
                        pointsSorted.Remove(max);
                        pointsSorted.Add(i);
                    }
                }
                else
                {
                    pointsSorted.Add(i);
                }
            }

            var result = new int[k][];
            var index = 0;
            while(pointsSorted.Any())
            {
                var min = pointsSorted.Min;
                result[index++] = points[min];
                pointsSorted.Remove(min);
            }
            return result;
        }

        public int GetDist(int[][] points, int i)
        {
            return points[i][0] * points[i][0] + points[i][1] * points[i][1];
        }
    }
}
