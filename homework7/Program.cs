namespace homework7;

class Program
{
    static void Main(string[] args)
    {
        Company localCompany = new Company(false);
        Company foreignCompany = new Company(true);
        
        Console.WriteLine($"Local tax: {localCompany.GetTaxRate()}");
        Console.WriteLine($"Foreign tax: {foreignCompany.GetTaxRate()}");
    }
}