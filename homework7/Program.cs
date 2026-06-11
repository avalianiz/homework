namespace homework7;

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
        Company localCompany = new Company(false);
        Company foreignCompany = new Company(true);
        
        Console.WriteLine($"Local tax: {localCompany.GetTaxRate()}");
        Console.WriteLine($"Foreign tax: {foreignCompany.GetTaxRate()}");

        Employee john = new Employee
        {
            firstName = "John",
            lastName = "Doe",
            position = "developer",
            workedHours = [5, 5, 4, 0, 3, 8, 10]
        };

        Console.WriteLine(john.GetWeeklySalary());
    }

    static void Task2()
    {
        Student alex = new Student("Alex", 19, 2024);
        Teacher eva = new Teacher("Eva", true);
        
        Console.WriteLine("Years left: " + alex.YearsTillGraduation());
        
        string subject = alex.RandomSubject();
        string result = eva.CheckStudentSubject(subject);
        
        Console.WriteLine(result);
    }

    static void Task3()
    {
        SecondStudent s1 = new GoodStudent("john");
        SecondStudent s2 = new LazyStudent("doe");
        SecondStudent s3 = new GoodStudent("ben");

        Classroom classroom = new Classroom(s1, s2, s3);

        classroom.ShowAllActivities();
    }
}