using AVSoftTest.API;
using AVSoftTest.BLL;
using AVSoftTest.BLL.Interfaces;
using AVSoftTest.DAL;
using AVSoftTest.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICounterManager, CounterManager>();
builder.Services.AddScoped<ICounterRepository, CounterRepository>();
builder.Services.AddSingleton<Context>();

builder.Services.AddAutoMapper(typeof(MapperAPIProfile), typeof(MapperBLLProfile));

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
