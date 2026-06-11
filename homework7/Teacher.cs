namespace homework7;

internal class Teacher
{
    public Teacher(string name, bool isCertified)
    {
        this.name = name;
        this.isCertified = isCertified;
    }
    
    private string name;
    private bool isCertified;


    public string CheckStudentSubject(string subject)
    {
        if (subject == "maths")
        {
            return $"5+6={5 + 6}";
        }
        else if (subject == "chemistry")
        {
            return "H2O";
        }
        else if (subject == "english")
        {
            return "text in english";
        }
        else
        {
            return "sorry not competent :(";
        }
    }
}