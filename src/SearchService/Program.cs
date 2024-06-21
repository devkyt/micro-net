var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();


await DB.InitAsync("SearchDB", MongoClientSettings
    .FromConnectionString(builder.Configuration.GetConnectionString("MongoDBConnection")));

await DB.Index<Item>()
    .Key(x => x.Type, KeyType.Text)
    .Key(x => x.Model, KeyType.Text)
    .Key(x => x.Condition, KeyType.Text)
    .CreateAsync();

app.Run();
