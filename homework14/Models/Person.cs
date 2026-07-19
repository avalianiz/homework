namespace homework14.Models;

public class Person
{
    public DateTime CreateDate { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string JobPosition { get; set; } = string.Empty;
    public double Salary  { get; set; }
    public double? WorkExperience { get; set; }
    public Address? PersonAddress { get; set; }
}