using System;

public delegate void MathMessage(string msg, int result);

class SimpleMath
{
    private MathMessage handler;

    public void SetMathHandler(MathMessage target)
    {
        handler = target;
    }

    public void Add(int x, int y)
    {
        handler?.Invoke("Adding has completed!", x + y);
    }
}

class Program
{
    static void Main()
    {
        SimpleMath m = new SimpleMath();
        m.SetMathHandler((msg, result) =>
            Console.WriteLine($"Message: {msg}, Result: {result}"));
        m.Add(10, 10);
    }
}
