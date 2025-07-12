using System.Numerics;

namespace Question_1;

public abstract class Part5
{
    public static string Result(in int a, in int b, in int loop)
        => $"""
            |S({a},{b})| = {S(a, b)}
            Expected Mean of RunA = {ExpectedMeanRunA(a, b)}
            Actual Mean of RunA = {ActualMeanRunA(a, b, loop)}
            """;


    private static BigInteger S(in int a, in int b) => Combination(a + b, a);

    private static BigInteger Combination(in int n, int k)
    {
        if (k > n - k) k = n - k;
        BigInteger result = 1;
        for (var i = 1; i <= k; i++)
        {
            result *= n - (k - i);
            result /= i;
        }

        return result;
    }

    private static double ExpectedMeanRunA(in int a, in int b)
        => 1.0 * (a * (b + 1)) / (a + b);

    private static double ActualMeanRunA(in int a, in int b, in int loop)
    {
        double sum = 0;
        for (var i = 0; i < loop; i++) sum += RunA(RandomS(a, b));
        return sum / loop;
    }

    private static int RunA(in string s)
    {
        var runA = 0;
        var oldChar = s[0];
        if (oldChar == 'A') runA++;
        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] == oldChar) continue;
            if (s[i] == 'A') runA++;
            oldChar = s[i];
        }

        return runA;
    }

    private static string RandomS(in int a, in int b)
    {
        var s = new List<char>();
        for (var i = 0; i < a; i++) s.Add('A');
        var rd = new Random();
        for (var i = 0; i < b; i++) s.Insert(rd.Next(s.Count + 1), 'B');
        return new string(s.ToArray());
    }
}