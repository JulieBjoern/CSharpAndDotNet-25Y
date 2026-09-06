namespace Lektion03Opgave03;

public class StarWarsRepository
{
    private readonly List<string> _starWarsCharacters = // readonly betyder at listen ikke kan ændres efter initialisering. skal altid være det samme
    [
        "Luke Skywalker",
        "Darth Vader",
        "Princess Leia",
        "Han Solo",
        "Yoda"
    ];

    public async Task<string> GetCharacterByIdAsync(int id)
    {
        Console.WriteLine("Henter karakter fra Star Wars repository...");
        // Simulerer 2 sekunders database-/netværksventetid
        var task = Task.Delay(2000);

        while (!task.IsCompleted)
        {
            Console.WriteLine("...venter...");
            await Task.Delay(500); // Vent 0,5 sekunder før næste ventetid
        }
        
        await task;
        
        Console.WriteLine("Ventetid afsluttet...");

        int index = id - 1;
        if (index < 0 && index >= _starWarsCharacters.Count)
        {
            return "Ukendt karakter";
        }
        
        Console.WriteLine("karakter fra Star Wars repository er nu hentet");

        return _starWarsCharacters[index];
    }
}