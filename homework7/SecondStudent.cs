namespace homework7;

internal class SecondStudent
{
    protected string name;

    public SecondStudent(string name)
    {
        this.name = name;
    }

    public virtual void Study()
    {
        Console.WriteLine($"{name} is studying");
    }

    public virtual void Read()
    {
        Console.WriteLine($"{name} is reading");
    }

    public virtual void Write()
    {
        Console.WriteLine($"{name} is writing");
    }

    public virtual void Relax()
    {
        Console.WriteLine($"{name} is relaxing");
    }
}