namespace Question_2;

public abstract class Part2
{
    public static void Result(int n, int loop)
    {
        ActualMeanAndVariance(n, loop, out var mean, out var variance);
        Console.WriteLine($"With n = {n} and loop {loop} times");
        Console.WriteLine($"Approximate Mean of X = {mean}");
        Console.WriteLine($"Approximate Variance of X = {variance}");
    }

    private static void ActualMeanAndVariance(int n, int loop, out double mean, out double variance)
    {
        int sumX = 0, sumX2 = 0;
        for (var i = 0; i < loop; i++)
        {
            var runs = HillDistance(Part1.RandomPermutation(n));
            sumX += runs;
            sumX2 += runs * runs;
        }

        mean = 1.0 * sumX / loop;
        variance = 1.0 * sumX2 / loop - Math.Pow(mean, 2);
    }

    private static int HillDistance(int a, int b) => a < b ? 2 * (b - a) : a - b;

    private static int HillDistance(List<int> a)
    {
        var sum = 0;
        for (var i = 0; i < a.Count - 1; i++) sum += HillDistance(a[i], a[i + 1]);
        return sum;
    }
}