namespace homework9;

public class LastLineReader
{
    private static string filePath = 
        Path.Combine(@"D:\RiderProjects\homework\homework9", "input.txt");
    
    internal static void GetUserInput()
    {
        Console.WriteLine("enter the amount of lines: ");
        if (!int.TryParse(Console.ReadLine(), out var count))
        {
            Console.WriteLine("invalid input");
            return;
        }

        string[] lines = new string[count];

        for (int i = 0; i < count; i++)
        {
            lines[i] = Console.ReadLine();
        }
        
        File.WriteAllLines(filePath, lines);
    }

    internal static void ReadLastLine()
    {
        string[] lines = File.ReadAllLines(filePath);
        Console.WriteLine($"Last line: {lines[^1]}");
    }
}