class Conditioner
{
    private float currentT;
    private string currentMode;

    public Conditioner()
    {
        currentT = 16;
        currentMode = "Cooling";
    }

    private bool CanDecrease()
    {
        return currentT > 16;
    }
    private bool CanIncrease()
    {
        return currentT < 32;
    }

    // public interface
    public void SetCoolMode()
    {
        this.currentMode = "Cooling";
    }
    public void SetDryMode()
    {
        this.currentMode = "Drying";
    }
    public void IncreseTemperature()
    {
        if (CanIncrease()) this.currentT += 1;
    }
    public void DecreaseTemperature()
    {
        if (CanDecrease()) this.currentT -= 1;
    }

    public override string ToString()
    {
        return $"Mode: {currentMode} - {currentT}^C";
    }
}

// Interface is a blueprint of a class. It can contain declarations of methods, properties, indexers, and events.

interface IDevice
{
    string Model { get; set; }

    void TurnOn();
    void TurnOff();
    void DoWork();
}

// interface implementation
class Printer : IDevice
{
    public string Model { get; set; }

    public void DoWork()
    {
        Console.WriteLine("Printing black & white document...");
    }

    public void TurnOff()
    {
        Console.WriteLine("Cancel active printing and shut down!");
    }

    public void TurnOn()
    {
        Console.WriteLine("Start and check the cartridges status...");
    }
}
class TV : IDevice
{
    public string Model { get; set; }

    public void DoWork()
    {
        Console.WriteLine("Showing the current TV program...");
    }

    public void TurnOff()
    {
        Console.WriteLine("Shut down.");
    }

    public void TurnOn()
    {
        Console.WriteLine("Start and open the first channel...");
    }
}

internal class Program
{
    private static void TestDevice(IDevice device)
    {
        device.TurnOn();
        device.DoWork();
        device.TurnOff();
    }
    private static void Main(string[] args)
    {
        Conditioner conditioner = new Conditioner();

        conditioner.IncreseTemperature();
        conditioner.SetDryMode();
        Console.WriteLine(conditioner);

        Printer printer = new Printer();
        TV tv = new TV();

        IDevice device = tv; // cast to the interface

        TestDevice(printer);
        TestDevice(tv);
    }
}