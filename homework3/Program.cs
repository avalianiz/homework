namespace homework3;

class Program
{
    static void Main(string[] args)
    {
        //DivideByFive();
        ArithmeticOperations();
    }

    
    #region divideby5
    static void DivideByFive()
    {
        Console.WriteLine("Input a number: ");
        if (int.TryParse(Console.ReadLine(), out int input))
        {
            Console.WriteLine(input % 5 == 0 ? "yes" : "no");
        }
        else
        {
            Console.WriteLine("please enter a valid number!");
        }
    }
    #endregion
    
    #region arithmeticoperations

    static void ArithmeticOperations()
    {
        Console.WriteLine("Enter X: ");

        if (!double.TryParse(Console.ReadLine(), out var x))
        {
            Console.WriteLine("invalid input");
            return;
        }
        
        Console.WriteLine("Enter Y: ");
        
        if (!double.TryParse(Console.ReadLine(), out var y))
        {
            Console.WriteLine("invalid input");
            return;
        }


        Console.WriteLine("addition: " + (x + y));
        Console.WriteLine("multiplication: " + (x * y));

        var subtraction = x > y ? x - y : y - x;
        Console.WriteLine("subtraction: " + subtraction);

        var bigger = x > y ? x : y;
        var smaller = x < y ? x : y;

        if (smaller == 0)
        {
            Console.WriteLine("division by zero is not allowed");
        }
        else
        {
            Console.WriteLine("division: " + bigger / smaller);
        }
    }
    
    #endregion
}