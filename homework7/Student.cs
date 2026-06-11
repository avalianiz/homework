namespace homework7;

internal class Student
{
    public Student(string name, int age, int enrollmentYear)
    {
        this.name = name;
        this.age = age;
        this.enrollmentYear = enrollmentYear;
    }

    private string name;
    private int age;
    private int enrollmentYear;

    public string RandomSubject()
    {
        Console.WriteLine("Enter subject: ");
        var subject = Console.ReadLine();
        
        return subject;
    }

    public int YearsTillGraduation()
    {
        var currentYear = DateTime.Now.Year;
        var yearsPassed = currentYear - enrollmentYear;
        var yearsLeft = 4 - yearsPassed;

        return yearsLeft > 0 ? yearsLeft : 0;
    }
}