public delegate void MotionDetectedEvent(string location);
 hgc
class MotionSensor
{
    public event MotionDetectedEvent? ChangeConsoleColor;
    public string Name { get; set; }

    public MotionSensor(string name)
    {
        Name = name;
    }

    public void DetectMotion(string location)
    {
        ChangeConsoleColor?.Invoke(location);
    }

    public void Print()
    {
        Console.WriteLine($"MotionSensor Name: {Name}");
    }
}

class Thermostat
{
    public event MotionDetectedEvent? ChangeConsoleColor;
    public string Name { get; set; }

    public Thermostat(string name)
    {
        Name = name;
    }

    public void Print()
    {
        Console.WriteLine($"Thermostat Name: {Name}");
    }
}

static class Program
{
    static void Main(string[] args)
    {
        MotionSensor motionSensor = new MotionSensor("MotionSensor");
        motionSensor.ChangeConsoleColor += MotionDetectedEvent;
        motionSensor.DetectMotion("put");

        Thermostat thermostat = new Thermostat("Thermostat");
        thermostat.ChangeConsoleColor += MotionDetectedEvent;
        thermostat.ChangeConsoleColor -= MotionDetectedEvent; // Пример отписки от события

        Console.ReadLine();
    }

    static void MotionDetectedEvent(string location)
    {
        if (location == "put")
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (location == "take")
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
