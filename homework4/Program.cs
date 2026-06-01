namespace homework4;

class Program
{
    static void Main(string[] args)
    {
        //Task1();
        //Task2();
        Task3();
    }


    static void Task1()
    {
        Console.WriteLine("enter the size of the array: ");
        if (!int.TryParse(Console.ReadLine(), out var size))
        {
            Console.WriteLine("invalid input");
            return;
        }

        Console.WriteLine("enter the numbers: ");
        int[] numbers = new int[size];

        string[] input = Console.ReadLine().Split(' ');

        int[] evens = new int[size];
        int[] odds = new int[size];

        int evenCount = 0;
        int oddCount = 0;

        for (int i = 0; i < size; i++)
        {
            numbers[i] = int.Parse(input[i]);

            if (numbers[i] % 2 == 0)
            {
                evens[evenCount] = numbers[i];
                evenCount++;
            }
            else
            {
                odds[oddCount] = numbers[i];
                oddCount++;
            }
        }

        Console.Write("array#1: ");
        for (int i = 0; i < evenCount; i++)
        {
            Console.Write(evens[i] + " ");
        }

        Console.WriteLine();

        Console.Write("array#2: ");
        for (int i = 0; i < oddCount; i++)
        {
            Console.Write(odds[i] + " ");
        }
    }


    static void Task2()
    {
        var contacts = new Dictionary<string, string>();

        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("1. add a contact");
            Console.WriteLine("2. delete a contact");
            Console.WriteLine("3. update a contact");
            Console.WriteLine("4. view contacts");
            Console.WriteLine("5. exit");
            
            Console.WriteLine("choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("enter name: ");
                    var name = Console.ReadLine();
                    
                    Console.WriteLine("enter number: ");
                    var phone = Console.ReadLine();
                    
                    contacts[name] = phone;
                    Console.WriteLine("contact added");
                    break;

                case "2":
                    Console.Write("enter name to delete: ");
                    name = Console.ReadLine();

                    if (contacts.Remove(name))
                        Console.WriteLine("contact deleted");
                    else
                        Console.WriteLine("contact not found");

                    break;

                case "3":
                    Console.Write("enter name to update: ");
                    name = Console.ReadLine();

                    if (contacts.ContainsKey(name))
                    {
                        Console.Write("enter new phone number: ");
                        phone = Console.ReadLine();

                        contacts[name] = phone;
                        Console.WriteLine("updated");
                    }
                    else
                    {
                        Console.WriteLine("contact not found");
                    }

                    break;

                case "4":
                    Console.WriteLine("\ncontacts:");

                    foreach (var contact in contacts)
                    {
                        Console.WriteLine($"{contact.Key}: {contact.Value}");
                    }

                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("invalid option");
                    break;
            }
            
        }
    }

    static void Task3()
    {
        Console.WriteLine("enter the number of elements: ");
        int n = int.Parse(Console.ReadLine());
        
        Console.WriteLine("enter the elements");
        int[] arr = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var result = arr
            .GroupBy(x => x)
            .OrderBy(g => g.Key);

        foreach (var group in result)
        {
            int count = group.Count();
            int sum = group.Sum();
            
            Console.WriteLine($"{group.Key} appears {count} times. sum is  {sum}");
        }
    }
}