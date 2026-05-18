namespace homework2;

class Program
{
    static void Main(string[] args)
    {
        // print full name
        Console.WriteLine("Zurab Avaliani");
        
        // make console color blue
        Console.ForegroundColor = ConsoleColor.Blue;
        
        // get input from user and return it
        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello {name}!");
    }
}