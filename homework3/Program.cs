namespace homework3;

class Program
{
    static void Main(string[] args)
    {
        DivideByFive();
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
    
}