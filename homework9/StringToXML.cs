using System.Xml;

namespace homework9;

public class StringToXml
{
    private static string _filePath =
        Path.Combine(@"D:\RiderProjects\homework\homework9", "strings.xml");
    
    public static void ConvertToXml()
    {
        Console.WriteLine("enter string:");
        string text = Console.ReadLine();
        
        Console.WriteLine("enter n: ");
        if (!int.TryParse(Console.ReadLine(), out var n))
        {
            Console.WriteLine("invalid input");
            return;
        }
        
        int partLength = text.Length / n;
        XmlDocument xml = new XmlDocument();
        
        XmlNode root = xml.CreateElement("strings");
        xml.AppendChild(root);

        for (int i = 0; i < n; i++)
        {
            int start = i * partLength;

            string part;

            if (i == n - 1)
            {
                part = text.Substring(start);
            }
            else
            {
                part =  text.Substring(start, partLength);
            }
            
            XmlElement node = xml.CreateElement(part);
            node.InnerText = $"string {i + 1}";
            
            root.AppendChild(node);
        }
        
        xml.Save(_filePath);
        Console.WriteLine(xml.OuterXml);
    }
}