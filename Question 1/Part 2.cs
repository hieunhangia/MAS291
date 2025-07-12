namespace Question_1;

public abstract class Part2
{
    public static string Result(in double p, in int n)
    => $"""
        Expected result = p = {p}
        Actual result = {Toss(p, n)}
        """;

    private static double Toss(in double p, in int n)
    {
        var rd = new Random();
        var head = 0;
        for (var i = 0; i < n; i++)
            if (rd.NextDouble() < p)
                head++;
        return 1.0 * head / n;
    }
}