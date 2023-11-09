
using Bankomat.Api.Repositories;
using Bankomat.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<BancomatV2Context>(cfg =>
{
    var connectionString = "server=localhost;user=sa;password=password123;database=Bancomat";



    cfg.UseSqlServer(connectionString)
     .LogTo(Console.WriteLine, LogLevel.Information)
     .EnableSensitiveDataLogging()
     .EnableDetailedErrors();

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUtenteDb, UtenteRepositoryDb>();
builder.Services.AddScoped<IBancheDb, BancheRepositoryDb>();
builder.Services.AddScoped<IFunzionalitaDb, FunzionalitaRepositoryDb>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



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
