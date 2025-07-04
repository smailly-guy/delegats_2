using System;

public class CarEventArgs : EventArgs
{
    public string msg;
    public CarEventArgs(string message) => msg = message;
}

public class Car
{
    public event EventHandler<CarEventArgs> AboutToBlow;
    public event EventHandler<CarEventArgs> Exploded;

    private string name;
    private int maxSpeed;
    private int currentSpeed;

    public Car(string name, int max, int current)
    {
        this.name = name;
        this.maxSpeed = max;
        this.currentSpeed = current;
    }

    public void Accelerate(int delta)
    {
        currentSpeed += delta;
        if (maxSpeed - currentSpeed == 10)
            AboutToBlow?.Invoke(this, new CarEventArgs("Careful! Almost blown!"));
        if (currentSpeed >= maxSpeed)
            Exploded?.Invoke(this, new CarEventArgs("Boom! Car is dead."));
        else
            Console.WriteLine($"Current speed = {currentSpeed}");
    }
}

class Program
{
    static void Main()
    {
        Car c = new Car("SlugBug", 100, 10);
        c.AboutToBlow += (sender, e) => Console.WriteLine(e.msg);
        c.Exploded += (sender, e) => Console.WriteLine(e.msg);

        for (int i = 0; i < 6; i++)
            c.Accelerate(20);
    }
}
