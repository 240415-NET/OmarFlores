using Microsoft.EntityFrameworkCore; // To use DbContext and so on.
using miniLegacyRerater.Models;
using System.ComponentModel.DataAnnotations;
namespace miniLegacyRerater.DB;

// This manages interactions with the Northwind database.
public class NorthwindDb : DbContext
{
    // These two properties map to tables in the database.
    public DbSet<Group>? Groups { get; set; }
 [Required]
    [StringLength(40)]
    public DbSet<User>? Users { get; set; }


    protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
    {
        //string databaseFile = "Northwind.db";
        //string path = Path.Combine(
        //    Environment.CurrentDirectory, databaseFile);
        string connectionString = @"Data Source=GEIPW0785F8;Initial Catalog=miniLegacyRerater;Integrated Security=False;User Id=sa;Password=Revature_Omar;MultipleActiveResultSets=True;TrustServerCertificate=True;";
        Console.WriteLine($"Connection: {connectionString}");
        optionsBuilder.UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(
    ModelBuilder modelBuilder)
    {
        // // Example of using Fluent API instead of attributes
        // // to limit the length of a category name to 15.
        // modelBuilder.Entity<Category>()
        // .Property(category => category.CategoryName)
        // .IsRequired() // NOT NULL
        // .HasMaxLength(15);
        // // Some SQLite-specific configuration.
        // if (Database.ProviderName?.Contains("Sqlite") ?? false)
        // {
        //     // To "fix" the lack of decimal support in SQLite.
        //     modelBuilder.Entity<Product>()
        //     .Property(product => product.Cost)
        //     .HasConversion<double>();
        // }
    }
}