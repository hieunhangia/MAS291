namespace Question_1;

public abstract class Part3
{
    public static void Result(in double p, in int n, in int loop)
    {
        ActualMeanAndVariance(p, n, loop, out var mean, out var variance);
        Console.WriteLine($"With N = {loop}");
        Console.WriteLine($"Expected Mean of Runs({p}, {n}) = {ExpectedMean(p, n)}");
        Console.WriteLine($"Actual Mean of Runs({p}, {n}) = {mean}");
        Console.WriteLine("--------------");
        Console.WriteLine($"Expected Variance of Runs({p}, {n}) = {ExpectedVariance(p, n)}");
        Console.WriteLine($"Actual Variance of Runs({p}, {n}) = {variance}");
    }

    private static double ExpectedMean(in double p, in int n)
        => 1 + 2 * (n - 1) * p * (1 - p);

    private static double ExpectedVariance(in double p, in int n) 
        => 2 * p * (1 - p) * (2 * n - 3 - 2 * p * (1 - p) * (3 * n - 5));

    private static void ActualMeanAndVariance
        (in double p, in int n, in int loop, out double mean, out double variance)
    {
        double sumX = 0, sumX2 = 0;
        for (var i = 0; i < loop; i++)
        {
            double runs = Runs(p, n);
            sumX += runs;
            sumX2 += runs * runs;
        }

        mean = sumX / loop;
        variance = sumX2 / loop - Math.Pow(mean, 2);
    }

    private static int Runs(in double p, in int n)
    {
        var rd = new Random();
        var oldRun = rd.NextDouble() < p;
        var runs = 1;
        for (var i = 1; i < n; i++)
        {
            if (oldRun == rd.NextDouble() < p) continue;
            runs++;
            oldRun = !oldRun;
        }

        return runs;
    }
}