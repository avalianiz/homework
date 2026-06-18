using System.Text.Json;

namespace homework9;

public class DaysTillBirthday
{
    private static string _filePath =
        Path.Combine(@"D:\RiderProjects\homework\homework9", "dates.json");

    public static void GetDaysTillBirthday()
    {
        DateInfo info = new DateInfo()
        {
            CurrentDate = "June 14, 2022",
            Birthday = "June 20, 2022"
        };

        string json = JsonSerializer.Serialize(info);

        File.WriteAllText(_filePath, json);


        string data = File.ReadAllText(_filePath);

        DateInfo dates = JsonSerializer.Deserialize<DateInfo>(data)!; // we know its not null its hardcoded


        DateTime currentDate = DateTime.Parse(dates.CurrentDate);
        DateTime birthday = DateTime.Parse(dates.Birthday);

        int daysLeft = (birthday - currentDate).Days;

        Console.WriteLine($"current date: {currentDate:MMMM dd, yyyy}");
        Console.WriteLine($"birthday: {birthday:MMMM dd, yyyy}");
        Console.WriteLine($"days before birthday: {daysLeft}");
    }
}