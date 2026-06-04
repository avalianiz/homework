namespace homework5;

class Program
{
    static void Main(string[] args)
    {
        Task2();
    }


    static void Task1()
    {
        Console.WriteLine("Enter radius: ");
        if (!double.TryParse(Console.ReadLine(), out var radius))
        {
            Console.WriteLine("invalid input");
            return;
        }
        
        // bigger square side is 2 * radius. smaller square side is 2 * radius / sqrt2

        var s2 = Math.Pow((radius * 2), 2); // big
        var s1 = Math.Pow((radius * 2 / Math.Sqrt(2)), 2); // small
        
        Console.WriteLine($"Area of bigger square is {s2}, \nArea of smaller square is {s1}");
        Console.WriteLine($"Difference between areas is: {s2 - s1}");
    }

    static void Task2()
    {
        Console.WriteLine("enter your input: ");
        string[] input = Console.ReadLine()
            .Split(' ',  StringSplitOptions.RemoveEmptyEntries);

        bool jackpot = true;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != input[0])
            {
                jackpot = false;
                break;
            }
        }
        Console.WriteLine(jackpot ? "Yes" : "no");
    }
}