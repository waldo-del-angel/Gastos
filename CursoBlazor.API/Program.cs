using CursoBlazor.Data;
using CursoBlazor.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
var sqlConnectionConf = new SqlConfiguration(builder.Configuration.GetConnectionString("CursoBlazorConnection"));

// Inyect dependecies
builder.Services.AddScoped<ICategoryRepo, CategoriaRepo>();

// Add services to the container.
builder.Services.AddSingleton(sqlConnectionConf);
builder.Services.AddControllers();
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
