using Opgave05.model;

namespace Opgave05;

class Program
{
    static void Main(string[] args)
    {
        // To IDENTISKE instanser af klassen
        GeoPointClass c1 = new GeoPointClass { Latitude = 56.15, Longitude = 10.20 };
        GeoPointClass c2 = new GeoPointClass { Latitude = 56.15, Longitude = 10.20 };

        // to IDENTISKE instanser af recorden.
        GeoPointRecord r1 = new GeoPointRecord(56.15, 10.20);
        GeoPointRecord r2 = new GeoPointRecord(56.15, 10.20);

        Console.WriteLine($"c1 == c2: {c1 == c2}"); // Reference equality: sammenligner hukommelsesadresser.
        Console.WriteLine($"r1 == r2: {r1 == r2}"); // Value equality: sammenligner indholdet.
        
        // viser den indbyggede toString metode. 
        Console.WriteLine("\nToString() på klasse-objektet:");
        Console.WriteLine(c1); // Når den indbyggede tostring kommer fra en klasse = namespace + klassenavn.

        Console.WriteLine("\nToString() på record-objektet:");
        Console.WriteLine(r1); // når den indbyggede tostring kommer fra en record =
                               // GeoPointRecord { Latitude = 56.15, Longitude = 10.2 }
                               // navnet på recorden + { property = value, property = value }
    }
}
