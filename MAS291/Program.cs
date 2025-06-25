namespace MAS291;

internal abstract class Program
{
    private static void Main()
    {
        var l = Question_2.Part1.RandomPermutation(20);
        Console.WriteLine("List");
        foreach (var x in l)
        {
            Console.Write($"{x} ");
        }
        Console.WriteLine();
        Console.WriteLine("Sublist");
        foreach (var x in Question_2.Part3.LengthOfLIS(l))
        {
            foreach (var y in x)
            {
                Console.Write($"{y} ");
            }
            Console.WriteLine();
        }
    }

}