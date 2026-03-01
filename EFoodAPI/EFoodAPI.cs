namespace EFoodAPI;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;


public static class EFoodAPI
{
    public static async Task<List<Food>> GetFoods(int weekOffset = 0)
    {
        Query query = new(year: DateTime.Now.Year, week: ISOWeek.GetWeekOfYear(DateTime.Now) + weekOffset);

        using var client = new HttpClient();
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        };
        var response = await client.PostAsJsonAsync("https://ea.e-food.hu/api/v1/menu", query, options);
        response.EnsureSuccessStatusCode();
        MenuResponse? menu = await response.Content.ReadFromJsonAsync<MenuResponse>(options);

        return menu!.GetFoods();
    }
}
