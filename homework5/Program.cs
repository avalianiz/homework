namespace homework5;

class Program
{
    static void Main(string[] args)
    {
        //Task1();
        //Task2();
        //Task3();
        Task4();
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

    static void Task3()
    {
        Console.WriteLine("enter the amount of wins: ");
        if (!double.TryParse(Console.ReadLine(), out var wins))
        {
            Console.WriteLine("invalid input");
            return;
        }
        
        Console.WriteLine("enter the amount of draws: ");
        if (!double.TryParse(Console.ReadLine(), out var draws))
        {
            Console.WriteLine("invalid input");
            return;
        }
        
        Console.WriteLine("enter the amount of loses: ");
        if (!double.TryParse(Console.ReadLine(), out var loses))
        {
            Console.WriteLine("invalid input");
            return;
        }
        
        Console.WriteLine($"{wins * 3 + draws + loses * 0} Points");
    }

    static void Task4()
    {
        Console.WriteLine("enter hours worked (7 entries): ");
        int[] input = Console.ReadLine()
            .Split(' ',  StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        if (input.Length != 7)
            throw new ArgumentException("please enter exactly 7 integers");

        int pay = 0;

        for (int day = 0; day < 7; day++)
        {
            int hours = input[day];
            bool isWeekend = (day == 5 || day == 6);

            if (isWeekend)
            {
                if (hours <= 8)
                {
                    pay += hours * 10 * 2; // $10 per hour, doubled during the weekend
                }
                else
                {
                    pay += 8 * 2 * 10; // first 8 hours, no overtime
                    pay += (hours - 8) * 15 * 2; // overtime hours, whatever is left $15 per hour doubled on the weekend
                }
            }
            else
            {
                if (hours <= 8)
                {
                    pay += hours * 10; // regular pay
                }
                else
                {
                    pay += 8 * 10; // first 8 hours no overtime
                    pay += (hours - 8) * 15; // $15 per hour for extra hours done
                }
            }
        }
        Console.WriteLine(pay);
    }
}