namespace MAS291;

internal abstract class Program
{
    private static void Main()
    {
        for (var i = 0; i < 10; i++)
        {
            foreach (var j in Question_2.Part1.RandomPermutation(20))
            {
                Console.Write(j+" ");
            }
            Console.WriteLine();
        }
    }

}