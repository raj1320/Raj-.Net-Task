using ASP.NETCORE_WEB_API_Project1.Application.Interface;
using ASP.NETCORE_WEB_API_Project1.Application.Mappings;
using ASP.NETCORE_WEB_API_Project1.Application.Services;
using ASP.NETCORE_WEB_API_Project1.Domain.Interfaces;
using ASP.NETCORE_WEB_API_Project1.Infrastructure.Data;
using ASP.NETCORE_WEB_API_Project1.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductService,ProductService>();

builder.Services.AddAutoMapper(typeof(ProductProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



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
