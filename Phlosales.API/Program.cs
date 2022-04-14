using Microsoft.EntityFrameworkCore;
using Phlosales.API.Data;
using Phlosales.API.DbContext;
using Phlosales.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
                policy =>
                {
                    policy.WithOrigins("https://phloview.com", "http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
});

// Add services to the di container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect to PostgreSQL Database
builder.Services.AddDbContext<PhloSysDbContext>(
    option => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// register my costome service
builder.Services.AddScoped<IProdOrderService, ProdOrderService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
