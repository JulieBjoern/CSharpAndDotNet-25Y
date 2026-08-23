using Opgave04.model;

namespace Opgave04;

class Program
{
    static void Main(string[] args)
    {
        // Opret et par produkter.
        Product laptop = new Product("1", "Bærbar computer", 7999.95m, "Elektronik"); // "m" efter tallet angiver at det er en decimal literal.
        Product mouse = new Product("2", "Trådløs mus", 299.50m, "Tilbehør");

        // Opdatering med with: opret en ny udgave af produktet med tilbudspris.
        // Non-destructive mutation: originalen er uændret — der laves en kopi.
        Product discountedLaptop = laptop with { Price = 6799.95m };

        Console.WriteLine("Original:");
        Console.WriteLine($"  {laptop}");
        Console.WriteLine("Med tilbudspris:");
        Console.WriteLine($"  {discountedLaptop}");
        Console.WriteLine($"Original uændret: {laptop.Price == 7999.95m}");
        Console.WriteLine($"Forskellige objekter: {!ReferenceEquals(laptop, discountedLaptop)}");

        // Deconstruction: udpak værdierne direkte fra recorden.
        var (id, name, price, category) = discountedLaptop; // på én linje kan man udpakke alle properties i recorden.
        /* ellers skulle man gøre således:
        // var name = discountedLaptop.Name;
        var price = discountedLaptop.Price;
        osv. */
        
        Console.WriteLine("Test af deconstruction:" + $"\nVare: {name}, Pris: {price}");
        
        var (mouseId, mouseName, mousePrice, mouseCategory) = mouse;
        Console.WriteLine("Test af deconstruction:" + $"\nVare: {mouseName}, Pris: {mousePrice}");
    }
}
