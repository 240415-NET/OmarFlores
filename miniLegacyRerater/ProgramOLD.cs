using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using miniLegacyRerater.Data;
using miniLegacyRerater.Models;
using miniLegacyRerater.Presentation;

namespace miniLegacyRerater;

class ProgramOLD
{
    static void Main(string[] args)
    {
        //Console.Clear();
         // To use Northwind.
// using miniLegacyReraterContext db = new();
// Console.WriteLine($"Provider: {db.Database.ProviderName}");
// //List<Models.Group> l = db.Groups.Select(x => x).ToList();
// //l.ForEach(x => Console.WriteLine($"{x._groupId} {x._groupName} {x._userName}"));
//         Console.WriteLine($"Welcome to mini Legacy Rerater!\nThe Legacy Rerater is used to set the price of policies.\nGiven a rategen, the new premium is" +
//         $" calculated. The process is iterated until the right price is achieved.\nIn this example, two rategens are used, one that has a factor 1.1 (10% increase) and another with 1.2.\n" +
//         $"I use two lists, one to keep the policies prior to rerating and the second to keep the policies after rerating.");
//         /*
//         object that mimics the Legacy Rerater
//         - class for the UI
//         - class for rating
//         */
//         Menu UI = new Menu();

//        Menu.StartMenu();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

    }

}
