namespace Lektion03Opgave4;

class Lektion03Opgave4Main
{
    
    static async Task Main(string[] args)
    {
      var catFactFetcher = new CatfactFetcher();
      var catFact = await catFactFetcher.FetchCatFactAsync();
      Console.WriteLine($"Cat Fact: {catFact.fact}"); // strongly typed fordi vi har lavet en record CatFactDto <3 
      var catFact2 = await catFactFetcher.FetchCatFactAsync();
      Console.WriteLine($"Cat Fact: {catFact2.fact}"); 
    }
    
}