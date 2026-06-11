namespace homework7;

internal class Classroom
{
    private List<SecondStudent> students = new List<SecondStudent>();

    public Classroom(params SecondStudent[] students)
    {
        this.students.AddRange(students);
    }

    public void ShowAllActivities()
    {
        foreach (var student in students)
        {
            student.Study();
            student.Read();
            student.Write();
            student.Relax();
        }
    }
}