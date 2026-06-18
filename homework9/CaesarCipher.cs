using System.Text.Json;

namespace homework9;

public class CaesarCipher
{
    private static string filePath =
        Path.Combine(@"D:\RiderProjects\homework\homework9", "cipher.json");

    public static void Encrypt()
    {
        CaesarData data = new CaesarData()
        {
            Word = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            Key = 7
        };

        string json = JsonSerializer.Serialize(data);

        File.WriteAllText(filePath, json);


        string file = File.ReadAllText(filePath);

        CaesarData input = JsonSerializer.Deserialize<CaesarData>(file)!;


        string result = "";

        foreach (char c in input.Word)
        {
            int number = c - 'A';
            int shifted = (number + input.Key) % 26;

            result += (char)('A' + shifted);
        }


        var output = new
        {
            Cipher = result
        };

        string outputJson = JsonSerializer.Serialize(output);

        Console.WriteLine(outputJson);
    }
}