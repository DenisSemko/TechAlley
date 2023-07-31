using FilesHub.API.AwsConfiguration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AwsConfiguration>(builder.Configuration.GetSection("AwsConfiguration"));
builder.Services.AddSingleton<IAwsConfiguration>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<AwsConfiguration>>().Value);

builder.Services.AddScoped<IBucketService, BucketService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();