using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;

namespace currencies.Services;

public class CurService
{
    HttpClient httpClient;
    public CurService()
    {
        httpClient = new HttpClient();
    }
    List<Currency> curList = new();
    public async Task<List<Currency>> GetCur()
    {
        if (curList?.Count > 0) return curList;

        var url = "https://github.com/Erlangga28/Assignment-Framework-AppsWithJSON/blob/main/EplTeams/Resources/Raw/epldata.json";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            curList = await response.Content.ReadFromJsonAsync<List<Currency>>();
        }

        /*using var stream = await FileSystem.OpenAppPackageFileAsync("Movies.json");
        using var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync();
        moviesList = JsonSerializer.Deserialize<List<Movie>>(content); */

        return curList;
    }


}

public class Currency
{
}