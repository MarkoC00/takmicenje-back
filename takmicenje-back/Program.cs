using DataAccessLayer.Data;
using BusinessAccess.Contracts;
using DataAccessLayer.Contracts;
using BusinessAccess.Services;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")).LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddScoped<ITakmicarService, TakmicarService>();
builder.Services.AddScoped<ITakmicarRepository, TakmicarRepository>();

builder.Services.AddScoped<IPrijavaTakmicaraService, PrijavaTakmicaraService>();
builder.Services.AddScoped<IPrijavaTakmicaraRepository, PrijavaTakmicaraRepository>();

builder.Services.AddScoped<IKlubService, KlubService>();
builder.Services.AddScoped<IKlubRepository, KlubRepository>();

builder.Services.AddScoped<IEkipnoKateService, EkipnoKateService>();
builder.Services.AddScoped<IEkipnoKateRepository, EkipnoKateRepository>();

builder.Services.AddScoped<IPrijaveTakmicaraBorbeService, PrijavaTakmicaraBorbeService>();
builder.Services.AddScoped<IPrijavaTakmicaraBorbeRepository, PrijavaTakmicaraBorbeRepository>();

builder.Services.AddScoped<IEkipnoBorbeService, EkipnoBorbeService>();
builder.Services.AddScoped<IEkipnoBorbeRepository, EkipnoBorbeRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:5173", "http://localhost:5131")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Apply CORS policy

app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
