using BlazorTestingExample.Core.Clients.DB;
using BlazorTestingExample.Core.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCoreServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Run DB migrations on app startup, in prod only:
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<BlazorTestingExampleDbContext>();
context.Database.Migrate();

app.UseHttpsRedirection();


app.UseRouting();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();