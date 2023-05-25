var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Configuration.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "../../../SharedConfig", "Config.json"), true, true);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("JWT"));
builder.Services.AddSingleton<IJwtOptions>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<JwtOptions>>().Value);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MigrateDatabase<ApplicationContext>((context, services) =>
{
    var logger = services.GetService<ILogger<IdentitySeed>>();
    IdentitySeed.SeedData(context, logger).Wait();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();