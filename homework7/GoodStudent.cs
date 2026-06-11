namespace homework7;

internal class GoodStudent : SecondStudent
{
    public GoodStudent(string name) : base(name) {}

    public override void Study()
    {
        Console.WriteLine($"Good student {name} is studying ");
    }
    
    public override void Read()
    {
        Console.WriteLine($"Good student {name} is reading");
    }

    public override void Write()
    {
        Console.WriteLine($"Good student {name} is writing");
    }

    public override void Relax()
    {
        Console.WriteLine($"Good student {name} is relaxing");
    }
}