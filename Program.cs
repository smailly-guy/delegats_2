using System;

public delegate string VerySimpleDelegate();

class Program
{
    static void Main()
    {
        VerySimpleDelegate d = new VerySimpleDelegate(() => { return "Enjoy your string!"; });
        Console.WriteLine(d());
    }
}
