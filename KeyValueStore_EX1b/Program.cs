using System;
using KeyValueStore_EX1b;
public class Program
{
    static void Main()
    {
        var d = new MyDictionary();
        try
        {
            Console.WriteLine(d["Cats"]);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        d["Cats"] = 42;
        d["Dogs"] = 17;
        Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");
    }
}