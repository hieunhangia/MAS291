namespace Question_2;

public abstract class Part2
{
    public static void Result(in int n, in int loop)
    {
        ActualMeanAndVariance(n, loop, out var mean, out var variance);
        Console.WriteLine($"With n = {n} and {loop} loops");
        Console.WriteLine($"Mean of X ≈ {mean}");
        Console.WriteLine($"Variance of X ≈ {variance}");
    }

    private static void ActualMeanAndVariance(in int n, in int loop, out double mean, out double variance)
    {
        double sumX = 0, sumX2 = 0;
        for (var i = 0; i < loop; i++)
        {
            var hd = HillDistance(Part1.RandomPermutation(n));
            sumX += hd;
            sumX2 += hd * hd;
        }

        mean = sumX / loop;
        variance = sumX2 / loop - Math.Pow(mean, 2);
    }

    private static int HillDistance(in int a, in int b) 
        => a < b ? 2 * (b - a) : a - b;

    private static int HillDistance(in List<int> a)
    {
        var sum = 0;
        for (var i = 0; i < a.Count - 1; i++) sum += HillDistance(a[i], a[i + 1]);
        return sum;
    }
}