using Microsoft.EntityFrameworkCore;
using ZenGarden.Api;
using ZenGarden.Infrastructure;
using ZenGarden.Services;
using ZenGarden.Services.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDataBase();
builder.Services.AddAutoMapper(typeof(ApplicationProfile));

builder.Services.AddTransient<IUserService, UserService>();//?
builder.Services.AddTransient<IGardenService, GardenService>();
builder.Services.AddTransient<IPlantService, PlantService>();
builder.Services.AddTransient<IWalletService, WalletService>();
builder.Services.AddTransient<IInsectService, InsectService>();

var app = builder.Build();

await MigrateDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task MigrateDatabase(WebApplication webApplication)
{
    using var scope = webApplication.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (context == null)
        throw new Exception("Cannot initialize the database context");

    await context.Database.MigrateAsync();
}