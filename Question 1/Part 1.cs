namespace Question_1
{
    public abstract class Part1
    {
        public static void Result(double p, int n)
        {
            Console.WriteLine($"Toss({p}, {n}) = {Part1.Toss(p, n)}");
        }

        private static string Toss(double p, int n)
        {
            var rd = new Random();
            var result = "";
            for (var i = 0; i < n; i++)
                result += rd.NextDouble() < p ? 'H' : 'T';
            return result;
        }
    }
}