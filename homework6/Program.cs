namespace homework6;

class Program
{
    static void Main(string[] args)
    {
        // task 1
        Console.WriteLine(Task1(49, 71, 2));
        Console.WriteLine(Task1(2, 27, 4));
        
        // int example
        Task4(new List<int> { 5, 5 });

        // string example
        Task4(new List<string> { "test", "random", "programming", "word" });

        // bool example
        Task4(new List<bool> { true, false, true, false, true, false, false });
        
        
        string input = "12345";
        Task5(input, 0);
        
        int[] nums1 = { 1, 2, 3, 1 };
        int[] nums2 = { 1, 2, 3, 4 };

        Console.WriteLine("----------------- task 6 ----------------");
        Console.WriteLine(Task6(nums1, 0)); // true
        Console.WriteLine(Task6(nums2, 0)); // false
    }

    static int Task1(int a, int b, int n)
    {
        int count = 0;

        for (int x = 1; ; x++)
        {
            double power = Math.Pow(x, n);

            if (power > b)
                break;

            if (power >= a)
                count++;
        }

        return count;
    }
    
    
    static void Task4<T>(List<T> list)
    {
        if (typeof(T) == typeof(string))
        {
            foreach (var item in list)
                Console.WriteLine(item.ToString().ToUpper());
        }
        else if (typeof(T) == typeof(int))
        {
            int sum = 0;
            foreach (var item in list)
                sum += Convert.ToInt32(item);

            Console.WriteLine(sum);
        }
        else if (typeof(T) == typeof(bool))
        {
            bool[] arr = list.Cast<bool>().ToArray();

            if (arr.Length == 0) return;

            Console.WriteLine($"first elemetn {arr[0]}");
            Console.WriteLine($"last element {arr[^1]}");
            Console.WriteLine($"middle element {arr[arr.Length / 2]}");
        }
        else
        {
            Console.WriteLine("type not supported");
        }
    }
    static void Task5(string s, int index)
    {
        // stop when we reach end of string
        if (index == s.Length)
            return;

        // print current digit
        Console.Write(s[index]);

        // print - if the digit is not the last one
        if (index < s.Length - 1)
            Console.Write(" - ");
        
        Task5(s, index + 1);
    }
    
    
    static bool Task6(int[] nums, int index)
    {
        
        if (index >= nums.Length)
            return false;

        // check current element against all following elements
        for (int i = index + 1; i < nums.Length; i++)
        {
            if (nums[index] == nums[i])
                return true;
        }
        
        return Task6(nums, index + 1);
    }
}


