using ConsultaCep.Application.Interfaces;
using ConsultaCep.Application.Services;
using ConsultaCep.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("sqlserver"));
});

builder.Services.AddScoped<IClienteService, ClienteService>();
AppContext.SetSwitch("Switch.Microsoft.Data.SqlClient.DisableCertificateValidation", true);

var app = builder.Build();

app.UseRouting();

// Habilitando CORS
app.UseCors(builder => builder
    .WithOrigins("http://localhost:3000") 
    .AllowAnyHeader()
    .AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
