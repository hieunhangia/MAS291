namespace Question_2;

public abstract class Part1
{
    public static string Result(in int n, in int loop)
        => $"""
            Expected ProbDerangement = {1 / Math.E}
            Actual ProbDerangement({n}) = {ProbDerangement(n, loop)}
            """;
    

    private static double ProbDerangement(in int n, in int loop)
    {
        var count = 0;
        for (var i = 0; i < loop; i++)
        {
            var random = RandomPermutation(n);
            var check = true;
            for (var j = 0; j < n; j++)
                if (random[j] == j + 1)
                {
                    check = false;
                    break;
                }

            if (check) count++;
        }

        return 1.0 * count / loop;
    }

    public static List<int> RandomPermutation(in int n)
    {
        var array = new List<int>();
        var rd = new Random();
        for (var i = 1; i <= n; i++) array.Insert(rd.Next(0, array.Count + 1), i);

        return array;
    }
}