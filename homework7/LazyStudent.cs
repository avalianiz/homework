namespace homework7;

internal class LazyStudent : SecondStudent
{
    public LazyStudent(string name) : base(name) {}

    public override void Study()
    {
        Console.WriteLine($"Lazy student {name} is studying ");
    }
    
    public override void Read()
    {
        Console.WriteLine($"lazy student {name} is reading");
    }

    public override void Write()
    {
        Console.WriteLine($"lazy student {name} is writing");
    }

    public override void Relax()
    {
        Console.WriteLine($"lazy student {name} is relaxing");
    }
}