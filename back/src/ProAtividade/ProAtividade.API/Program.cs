using Microsoft.EntityFrameworkCore;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Atividade.Repositories;
using ProAtividade.Domain.Atividade.Services;
using ProAtividade.Domain.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddScoped<IAtividadeService, AtividadeService>();
builder.Services.AddScoped<IAtividadeRepository, AtividadeRepository>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();

builder.Services.AddControllers();

builder.Services.AddCors(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(option => option.AllowAnyHeader()
                            .WithOrigins("http://localhost:3000")
                            .AllowAnyMethod());

app.MapControllers();

app.Run();
