namespace Question_1;

public abstract class Part1
{
    public static void Result(in double p, in int n)
        => Console.WriteLine($"Toss({p}, {n}) = {Toss(p, n)}");

    private static string Toss(in double p, in int n)
    {
        var rd = new Random();
        var result = "";
        for (var i = 0; i < n; i++)
            result += rd.NextDouble() < p ? 'H' : 'T';
        return result;
    }
}