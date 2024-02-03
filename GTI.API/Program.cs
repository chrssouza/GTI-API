using GTI.Domain.Entities;
using GTI.Infra;
using GTI.Infra.Data.Interfaces;
using GTI.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GTIDataContext>(options =>
{
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("GTI.Infra"));
});

// Add services to the container.
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

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<GTIDataContext>(options =>
    {
        options.UseSqlServer(connectionString, x => x.MigrationsAssembly("GTI.Infra"));
    });

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    var services = GetServiceCollection(builder);
}

IServiceCollection GetServiceCollection(WebApplicationBuilder builder)
{
    // Adicionando servi�os
    var services = builder.Services;
    services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
    services.AddScoped<IReadRepository<Cliente>, ApplicationRepository<Cliente>>();
    services.AddScoped<IWriteRepository<Cliente>, ApplicationRepository<Cliente>>();
    services.AddScoped<IReadRepository<Endereco>, ApplicationRepository<Endereco>>();
    services.AddScoped<IWriteRepository<Endereco>, ApplicationRepository<Endereco>>();

    return services;
}