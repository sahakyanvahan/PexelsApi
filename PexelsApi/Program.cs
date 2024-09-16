using Microsoft.Extensions.Options;
using PexelsApi.Services;
using PexelsApi.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPexelsService, PexelsService>();

builder.Services.Configure<PexelsSettings>(builder.Configuration.GetSection("Pexels"));

builder.Services.AddHttpClient<IPexelsService, PexelsService>()
    .ConfigureHttpClient((serviceProvider, client) =>
    {
        var pexelsSettings = serviceProvider.GetRequiredService<IOptions<PexelsSettings>>().Value;
        client.BaseAddress = new Uri("https://api.pexels.com/");
        client.DefaultRequestHeaders.Add("Authorization", $"{pexelsSettings.ApiKey}");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
