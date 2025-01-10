using Microsoft.Extensions.Hosting;
using TimeChamp.Integraions.MainEngine.AdaptarServiceRouter;
using TimeChamp.Integraions.MainEngine.ApiCalls;
using TimeChamp.Integraions.MainEngine.RabbitMQHouse.RabbitMQConsumer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<AdaptarService>();
builder.Services.AddSingleton<UpsertUsersI2TConsumer>();
builder.Services.AddSingleton<ApiCaller>();
var app = builder.Build();
UpsertUsersI2TConsumer upsertUsersI2TConsumer = app.Services.GetRequiredService<UpsertUsersI2TConsumer>();



upsertUsersI2TConsumer.StartListening();

app.MapGet("/", () => "Hello World!");

app.Run();
