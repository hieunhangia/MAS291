using System.Numerics;

namespace Question_1
{
    public abstract class Part5
    {
        public static void Result(int a, int b, int loop)
        {
            Console.WriteLine($"|S({a},{b})| = {S(a, b)}");
            Console.WriteLine($"Expected Mean of RunA = {ExpectedMeanRunA(a, b)}");
            Console.WriteLine($"Actual Mean of RunA = {ActualMeanRunA(a, b, loop)}");
        }

        private static BigInteger S(int a, int b) => Combination(a + b, a);

        private static BigInteger Combination(int n, int k)
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

        private static double ExpectedMeanRunA(int a, int b) => 1.0 * (a * (b + 1)) / (a + b);

        private static double ActualMeanRunA(int a, int b, int loop)
        {
            double sum = 0;
            for (var i = 0; i < loop; i++) sum += RunA(RandomS(a, b));
            return sum / loop;
        }

        private static int RunA(string s)
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

        private static string RandomS(int a, int b)
        {
            var s = new List<char>();
            for (var i = 0; i < a; i++) s.Add('A');
            var rd = new Random();
            for (var i = 0; i < b; i++) s.Insert(rd.Next(s.Count + 1), 'B');
            return new string(s.ToArray());
        }
    }
}