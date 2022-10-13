using System;

// abstract class - class that contains at least one abstract method
// can not create an instance of the abstract classes
public abstract class Device
{
    public string Model { get; set; }
    public decimal Price { get; set; }
    public int Year { get; set; }
    public bool IsPowerOn { get; set; }

    public void SwitchPower()
    {
        IsPowerOn = !IsPowerOn;
    }
    // abstract method - does not has realisation
    public abstract void DoWork();

    public override string ToString()
    {
        return $"Model: {Model} - {Price}$\n" +
            $"Year: {Year}\n" +
            $"Power is {(IsPowerOn ? "ON" : "OFF")}";
    }
}

public class Printer : Device
{
    public string Type { get; set; }
    public string Resolution { get; set; }

    public override string ToString()
    {
        return base.ToString() + "\n" +
            $"Type: {Type}\n" +
            $"Resolution: {Resolution}";
    }

    public override void DoWork()
    {
        Console.WriteLine($"Printing document with {Resolution} quality!");
    }

    public void CleanInks()
    {
        Console.WriteLine("Cleaning the inks!");
    }
}

public class Router : Device
{
    public float Frequency { get; set; }
    public int Antenas { get; set; }

    public override string ToString()
    {
        return base.ToString() + "\n" +
            $"Antenas: {Antenas}\n" +
            $"Frequency: {Frequency}";
    }

    public override void DoWork()
    {
        Console.WriteLine($"Transfering data between other devices on {Frequency}GHz!");
    }

    public void Reset()
    {
        Console.WriteLine("Reseting all settigns to factory!");
    }
}

internal class Program
{
    private static void TestWork(Device device)
    {
        Console.WriteLine($"Testing {device.Model}...");

        if (!device.IsPowerOn)
            device.SwitchPower();

        // testing work
        device.DoWork();

        device.SwitchPower();
    }

    private static void Main(string[] args)
    {
        // error with creating abstract class
        //Device device = new Device()
        //{
        //    Model = "Canon Pixma",
        //    Price = 150,
        //    Year = 2012,
        //    IsPowerOn = true
        //}; 
        //device.DoWork(); // error

        Printer printer = new Printer()
        {
            Model = "Canon Pixma",
            Price = 150,
            Year = 2012,
            IsPowerOn = true,
            Type = "Black & White",
            Resolution = "2340x3560"
        };
        Router router = new Router()
        {
            Model = "TP-Link 4566",
            Price = 90,
            Year = 2018,
            IsPowerOn = false,
            Frequency = 2.4F,
            Antenas = 6
        };


        TestWork(router);
        Console.WriteLine(new String('-', 40));
        TestWork(printer);
    }
}