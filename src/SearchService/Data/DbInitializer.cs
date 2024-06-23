using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.Services;

namespace SearchService.Data;

class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("SearchDB", MongoClientSettings
                                       .FromConnectionString(app.Configuration.GetConnectionString("MongoDBConnection")));

        await DB.Index<Item>()
                .Key(x => x.Type, KeyType.Text)
                .Key(x => x.Model, KeyType.Text)
                .Key(x => x.Condition, KeyType.Text)
                .CreateAsync();

        var count = await DB.CountAsync<Item>();

        using var scope = app.Services.CreateScope();

        var httpClient = scope.ServiceProvider.GetRequiredService<AuctionServiceHttpClient>();

        var items = await httpClient.GetItemsForSearchDb();

        Console.WriteLine($"{items.Count} returned from auction service");

        if (items.Count > 0) await DB.SaveAsync(items);
     }
}
