namespace homework9;

public class MultTable
{
    private static string filePath = 
        Path.Combine(@"D:\RiderProjects\homework\homework9", "table.txt");
    
    
    internal static void PrintTable()
    {
        Console.WriteLine("enter N: ");
        if (!int.TryParse(Console.ReadLine(), out var n))
        {
            Console.WriteLine("invalid input");
            return;
        }

        using StreamWriter streamWriter = new StreamWriter(filePath);

        for (int i = 1; i <= 10; i++)
        {
            streamWriter.WriteLine($"{n} * {i} = {n * i}");
        }
    }
}