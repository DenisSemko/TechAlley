var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "../../SharedConfig", "Config.json"), true, true);
builder.Configuration.AddJsonFile($"ocelot.json", true, true);
builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.AddCustomMiddleware();

app.UseOcelot();

app.Run();