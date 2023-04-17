using UrlShortener.WebApi.Exceptions;
using UrlShortener.WebApi.Repositories;
using UrlShortener.WebApi.Services.Helpers;
using URLShortener.WebApi.Config;
using URLShortener.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json")
    .Build();
builder.Services.Configure<UrlShortenerConfig>(builder.Configuration.GetSection("UrlShortenerConfig"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUrlShortenerRepository, UrlShortenerRepository>();
builder.Services.AddSingleton<IUrlShortenerHelper, UrlShortenerHelper>();

builder.Services.AddTransient<IUrlShortenerService, UrlShortenerService>();

await using var app = builder.Build();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

await app.RunAsync();
