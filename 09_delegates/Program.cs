using System;

// method prototype: return_type name(parameter_types)
delegate double AriphmeticOperation(double a, double b);

delegate int ChangeValue(int element);

internal class Program
{
    private static double Summ(double left, double right) => left + right;
    private static double Sub(double left, double right) => left - right;
    private static double Mult(double left, double right) => left * right;
    private static double Div(double left, double right)
    {
        if (right == 0) return 0;
        return left / right;
    }

    private static double GetSquare(double side) => side * side;

    private static void ChangeArray(int[] arr, ChangeValue changeFunc)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = changeFunc(arr[i]);
        }
    }

    // method for change element value
    private static int Random(int element)
    {
        Random rnd = new Random();
        return rnd.Next(Math.Abs(element));
    }
    private static int Increase(int element) => element + 1;
    private static int Decrease(int element) => element - 1;

    private static void Main(string[] args)
    {
        // -------------- Delegates --------------
        AriphmeticOperation operation = Summ;
        operation = Div;
        //operation = GetSquare; // error

        Console.WriteLine("Operation result: " + operation.Invoke(40, 8));
        Console.WriteLine("Operation result: " + operation(40, 8));

        AriphmeticOperation[] operations = { Summ, Sub, Mult, Div };

        Console.Write("Choose operation (1-4): ");
        int number = int.Parse(Console.ReadLine());

        var resulr = operations[number - 1].Invoke(15, 6);
        Console.WriteLine("Result: " + resulr);

        // change array using Delegates
        int[] numbers = { 4, 1, -6, 0, -120, -33, -6, 50, 9 };

        Console.WriteLine("\nOriginal array:");
        foreach (var item in numbers) Console.Write(item + " ");

        ChangeArray(numbers, Increase);

        Console.WriteLine("\nChanged array with delegate:");
        foreach (var item in numbers) Console.Write(item + " ");

        // -------------- Anonymous Methods --------------
        // anonymous delegate
        AriphmeticOperation customOperation = delegate (double a, double b)
                                              {
                                                  return Math.Sqrt(a) + Math.Sqrt(b);
                                              };
        // anonymous lambda expression
        customOperation = (a, b) => Math.Sqrt(a) + Math.Sqrt(b);

        ChangeArray(numbers, (element) => Math.Abs(element));

        Console.WriteLine("\nChanged array with anonymous expression:");
        foreach (var item in numbers) Console.Write(item + " ");
        Console.WriteLine();

        // -------------- System Delegates --------------
        // Aciton delegate does not return any value
        Action<int, string, bool> action = null;
        action?.Invoke(5, "hello", true);

        // Func delegate must return a value
        Func<int, int, double> func = null;
        double? result = func?.Invoke(7, 8);

        // -------------- Multicast Delegate --------------
        Action showMessage = () => Console.WriteLine("Hello!");

        // change method reference
        showMessage = () => Console.WriteLine("Goodbye!");

        // add method reference
        showMessage += () => Console.WriteLine("Additinal message!");
        showMessage += () => Console.WriteLine("Blablabla...");

        // invoke all methods in the delegate chain and return the last method result
        showMessage.Invoke();
    }
}