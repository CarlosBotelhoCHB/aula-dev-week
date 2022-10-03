using Microsoft.EntityFrameworkCore;
using src.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Adicionando o serviço do DataBaseContext especificando onde é a classe
// Especificando qual banco de dados usar (UseInMemoryDatabase)
builder.Services.AddDbContext<DataBaseContext>(options => options.UseInMemoryDatabase("dbcontracts"));
// Adcionando no escopo do projeto a instancia do DataBaseContext sem precisar instanciar a todo momento
builder.Services.AddScoped<DataBaseContext, DataBaseContext>();

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
