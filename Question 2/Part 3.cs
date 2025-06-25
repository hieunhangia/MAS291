// ReSharper disable InconsistentNaming
namespace Question_2
{
    public abstract class Part3
    {
        public static List<List<int>> LengthOfLIS(List<int> a)
        {
            var allIS = new List<List<int>>();
            for (var i = 0; i < a.Count; i++)
            {
                var checking = a[i];
                allIS.Add([]);
                allIS[i].Add(checking);
                for (var j = i + 1; j < a.Count; j++)
                {
                    if (checking < a[j])
                    {
                        allIS[i].Add(a[j]);
                    }
                }
            }
            return allIS;
        }
    }
}
