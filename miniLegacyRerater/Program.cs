using Microsoft.EntityFrameworkCore;
using miniLegacyRerater.Data;
using miniLegacyRerater.Models;
using miniLegacyRerater.Presentation;

//Connections
string connectionString = File.ReadAllText(@"./ConnectionString.txt");
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<miniLegacyReraterContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Add services to the container.

var myBadCorsPolicy = "_myBadCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myBadCorsPolicy,
    policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

builder.Services.AddScoped<ISQLUserStorage, SQLUserStorage>();

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

app.MapControllers();

app.Run();
