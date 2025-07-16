namespace MAS291;

internal abstract class Program
{
    private static void Main()
    {
        Console.WriteLine("Question 1 Part 1:");
        Console.WriteLine("p = 0.3");
        Console.WriteLine(Question_1.Part1.Result(0.3,10));
        Console.WriteLine("p = 0.6");
        Console.WriteLine(Question_1.Part1.Result(0.6,10));
        Console.WriteLine("----------------------");
        Console.WriteLine("Question 1 Part 2:");
        Console.WriteLine("p = 0.3");
        Console.WriteLine(Question_1.Part2.Result(0.3,100000));
        Console.WriteLine("p = 0.6");
        Console.WriteLine(Question_1.Part2.Result(0.6,100000));
        Console.WriteLine("----------------------");
        Console.WriteLine("Question 1 Part 3:");
        Console.WriteLine("p = 0.3, n = 100");
        Console.WriteLine(Question_1.Part3.Result(0.3,100,100000));
        Console.WriteLine("p = 0.6, n = 100");
        Console.WriteLine(Question_1.Part3.Result(0.6,100,100000));
        Console.WriteLine("----------------------");
        Console.WriteLine("Question 1 Part 4:");
        Console.WriteLine("p = 0.3");
        Console.WriteLine(Question_1.Part4.Result(0.3,100000));
        Console.WriteLine("p = 0.6");
        Console.WriteLine(Question_1.Part4.Result(0.6,100000));
        Console.WriteLine("----------------------");
        Console.WriteLine("Question 1 Part 5:");
        Console.WriteLine("a = 3, b = 6");
        Console.WriteLine(Question_1.Part5.Result(3,6,100000));
        Console.WriteLine("-----------------------");
        Console.WriteLine("Question 2 Part 1:");
        Console.WriteLine("n = 100");
        Console.WriteLine(Question_2.Part1.Result(100,100000));
        Console.WriteLine("-----------------------");
        Console.WriteLine("Question 2 Part 2:");
        Console.WriteLine("n = 100");
        Console.WriteLine(Question_2.Part2.Result(100,100000));
        Console.WriteLine("-----------------------");
        Console.WriteLine("Question 3 Part 1:");
        Console.WriteLine("a = 0.3, b = 0.6, x = 5pi/8");
        Console.WriteLine(Question_3.Part1.Result(0.5, 0.5, Math.PI * 5 / 8));
        Console.WriteLine("-----------------------");
        Console.WriteLine("Question 3 Part 2:");
        Console.WriteLine(Question_3.Part2.Result(100000));
        Console.WriteLine("-----------------------");
        Console.WriteLine("Question 3 Part 2 Bonus:");
        Console.WriteLine("AB = 0.3");
        Console.WriteLine(Question_3.Part2Bonus.Result(100000,0.3));
        Console.WriteLine("AB = 0.6");
        Console.WriteLine(Question_3.Part2Bonus.Result(100000,0.6));
        Console.WriteLine("AB = 3");
        Console.WriteLine(Question_3.Part2Bonus.Result(100000,3));
        Console.WriteLine("AB = 6");
        Console.WriteLine(Question_3.Part2Bonus.Result(100000,6));
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}