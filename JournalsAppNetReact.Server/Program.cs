using Journals.Application.Extensions;
using Journals.Infraestructure.Extensions;
using Journals.Infraestructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IJournalSeeder>();
await seeder.Seed();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
    
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
