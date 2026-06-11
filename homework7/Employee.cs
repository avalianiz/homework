namespace homework7;

internal class Employee
{
    private string firstName { get; set; }
    private string lastName { get; set; }
    private int Age { get; set; }
    private string position { get; set; }
    private int[] workedHours { get; set; }


    public double GetWeeklySalary()
    {
        double hourlyRate = GetHourlyRate();
        double salary = 0;
        int totalHours = 0;

        for (int i = 0; i < workedHours.Length; i++)
        {
            int hours = workedHours[i];
            totalHours += hours;

            bool isWeekend = i == 5 || i == 6;

            if (isWeekend)
            {
                salary += hours * hourlyRate * 2;
            }
            else
            {
                salary += hours * hourlyRate;
            }

            if (hours > 8)
            {
                salary += (hours - 8) * 5;
            }

        }

        if (totalHours > 50)
        {
            salary += (salary * 0.2);
        }

        return salary;
    }

    private double GetHourlyRate()
    {
        return position switch
        {
            "manager" => 40,
            "developer" => 30,
            "tester" => 20,
            _ => 10
        };
    }
}