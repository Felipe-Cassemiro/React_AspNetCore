using Microsoft.EntityFrameworkCore;
using ProAtividade.API.Context;
using ProAtividade.API.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
builder.Services.AddScoped<IAtividadesService, AtividadesService>();

builder.Services.AddCors();

builder.Services.AddControllers()
    .AddJsonOptions(p => p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
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

app.UseCors(option => option.AllowAnyHeader()
                            .AllowAnyOrigin()
                            .AllowAnyMethod());

app.MapControllers();

app.Run();
