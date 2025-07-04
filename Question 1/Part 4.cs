namespace Question_1
{
    public abstract class Part4
    {
        public static void Result(double p, int loop)
        {
            Console.WriteLine($"With N = {loop} and p = {p}");
            Console.WriteLine($"Expected Mean of Variables = {ExpectedMean(p)}");
            try
            {
                Console.WriteLine($"Actual Mean of Variables = {ActualMean(p, loop)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static double ExpectedMean(double p) => 1 / (2 * p - 1);

        private static double ActualMean(double p, int loop)
        {
            double sum = 0;
            for (var i = 0; i < loop; i++) sum += NumberOfTossUntilHeadExceedTail(p);
            return sum / loop;
        }

        private static long NumberOfTossUntilHeadExceedTail(double p)
        {
            var rd = new Random();
            long head = 0, tail = 0, sum = 0;
            do
            {
                if (rd.NextDouble() < p) head++;
                else tail++;
                if (sum++ > 1000000000) throw new Exception("It seems this function never finishes.");
            } while (head <= tail);

            return sum;
        }
    }
}