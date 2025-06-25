namespace Question_1
{
    public abstract class Part2
    {
        public static void Result(double p, int n)
        {
            Console.WriteLine($"Relative frequency of H with N = {n} and p = {p}");
            Console.WriteLine($"Expected result = p = {p}");
            Console.WriteLine($"Actual result = {Toss(p, n)}");
        }

        private static double Toss(double p, int n)
        {
            var rd = new Random();
            var head = 0;
            for (var i = 0; i < n; i++)
                if (rd.NextDouble() < p)
                    head++;
            return 1.0 * head / n;
        }
    }
}