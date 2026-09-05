namespace Lektion03Opgave01;

public delegate double MathOperation(double x, double y);

class MathOperations
{
    public static double Add(double x, double y)
    {
        return x + y;
    }

    public static double Subtract(double x, double y)
    {
        return x - y;
    }
    
    public static double Multiply(double x, double y)
    {
        return x * y;
    }

    public static void ExecuteAndPrint(double a, double b, MathOperation operation)
    {
        var result = operation(a, b);
        Console.WriteLine($"Result: {result}");
    }
}

class Lektion03Opgave01Main
{
    
    
    static void Main(string[] args)
    {
        // Test af add:
        MathOperations.ExecuteAndPrint(5, 3, MathOperations.Add); // Output: Result: 8
        
        // Et lambda udtryk for division:
        MathOperation divide = (x, y) => x / y;
        MathOperations.ExecuteAndPrint(10, 2, divide); // Output: Result: 5
        
        // Det smarte ved lambda udtryk er, at vi kan definere det inline uden at skulle oprette en separat metode.
        
        // et lambda udtryk for potenser (Math.Pow):
        MathOperation power = (x, y) => Math.Pow(x, y);
        MathOperations.ExecuteAndPrint(2, 3, power); // Output: Result: 8 
    }
}