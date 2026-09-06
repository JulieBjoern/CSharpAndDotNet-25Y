using System.Net.Http.Json;

namespace Lektion03Opgave4;

public class CatfactFetcher
{
    private readonly HttpClient _httpClient = new();

    public async Task<CatFactDto> FetchCatFactAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("https://catfact.ninja/fact");
            response.EnsureSuccessStatusCode();

            var catFactDto = await response.Content.ReadFromJsonAsync<CatFactDto>(); // læser det som JSON og konverterer det til CatFactDto
            
            if (catFactDto == null)
            {
                throw new InvalidOperationException("Received null response from cat fact API.");
            }
            
            return catFactDto;
        }
        catch (HttpRequestException httpEx)
        {
            throw new InvalidOperationException("HTTP request failed while fetching cat fact.", httpEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to fetch cat fact.", ex);
        }
    }
}