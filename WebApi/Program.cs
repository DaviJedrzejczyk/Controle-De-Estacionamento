using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Implements;
using Services.Interfaces;
using Services.Implements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<EstacionamentoDB>(option =>
{
    option.UseSqlServer("name=ConnectionStrings:Estacionamento");
});
builder.Services.AddTransient<ICarroDAL, CarroDAL>();
builder.Services.AddTransient<ICarroService, CarroService>();
builder.Services.AddTransient<ISaidasCarroDAL, SaidasCarroDAL>();
builder.Services.AddTransient<ISaidaCarroService, SaidasCarroService>();
builder.Services.AddTransient<IUnityOfWork, UnityOfWork>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
