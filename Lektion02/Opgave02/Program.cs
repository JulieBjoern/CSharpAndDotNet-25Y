using System.Globalization;
using Opgave02.model;

namespace Opgave02;

class Program
{
    static void Main(string[] args)
    {
        var products = SeedData.Products;
        var customers = SeedData.Customers;
        // 1. Find alle produkter i kategorien Category.Elektronik, som er på lager (StockCount > 0)
        var electronicsInStock = products
            .Where(p => p.Category == Category.Elektronik && p.StockCount > 0)
            .ToList(); // listen bliver automatisk lavet til en IEnumerable, så vi laver den tilbage til en liste med ToList() for at kunne bruge den senere. 

        // 2. Udskriv navn og pris for disse produkter, sorteret efter pris i faldende rækkefølge (dyreste først)


        var sortedElectronics = electronicsInStock
            .OrderByDescending(p => p.Price)
            .ToList();
        foreach (var electronic in sortedElectronics)
        {
            Console.WriteLine($"Produkt: {electronic.Name}, Pris: {electronic.Price.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}");
        }
        

        // 3. Find alle kunder fra byen "Aarhus" og udskriv deres navne
        var customersFromAarhus = customers
            .Where(c => c.City == "Aarhus")
            .ToList();
        foreach (var customer in customersFromAarhus)
        {
            Console.WriteLine($"Kunde: {customer.Name}");
        }

    }
}
