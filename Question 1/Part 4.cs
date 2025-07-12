namespace Question_1;

public abstract class Part4
{
    public static string Result(in double p, in int loop)
    {
        var result = $"Expected Mean of Variables = {ExpectedMean(p)}";
        try
        {
            result += $"\nActual Mean of Variables = {ActualMean(p, loop)}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return result;
    }

    private static double ExpectedMean(in double p) => 1 / (2 * p - 1);

    private static double ActualMean(in double p, in int loop)
    {
        double sum = 0;
        for (var i = 0; i < loop; i++) sum += NumberOfTossUntilHeadExceedTail(p);
        return sum / loop;
    }

    private static long NumberOfTossUntilHeadExceedTail(in double p)
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