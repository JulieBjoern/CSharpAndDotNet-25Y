namespace Lektion03Opgave03;

class Lektion03Opgave03Main
{
    static async Task Main(string[] args)
    {
        
        var repository = new StarWarsRepository();
        var character = await repository.GetCharacterByIdAsync(1);
        Console.WriteLine(character);
        var character2 = await repository.GetCharacterByIdAsync(2);
        Console.WriteLine(character2);
        var character5 = await repository.GetCharacterByIdAsync(5);
        Console.WriteLine(character5);
    }
}
