using Microsoft.EntityFrameworkCore;
using miniLegacyRerater.Models;

namespace miniLegacyRerater.Data;

//This class is going to be our "Database Context" class for our application.
//We only need one class that inherits from the EF Core DbContext class in our app 
//(assuming you have one database and one database only.)
//This class is what will handle our EF Core database communication for us. 
public class miniLegacyReraterContext : DbContext
{
    //We need to make our Context class aware of the model classes it needs to track for us
    //We do this by creating DbSets for our model classes. MAKE SURE YOU HAVE A GET; SET;
    public DbSet<User> Users {get; set;}
    public DbSet<Group> Groups {get; set;}
    public DbSet<Policies> PolicyDetails {get; set;}
    
    //Here is a parameterless constructor
    public miniLegacyReraterContext () {}

    //In order to create/apply a migration we need a constructor that accepts a DbContextOptions and 
    //passes it to the base constructor that comes in from the DbContext parent class 
    public miniLegacyReraterContext(DbContextOptions options) : base (options) {}

    //In order to tweak EF Core's default behavior/assumptions of what we want in our database
    //whether it is with regards to things like table structure, relationships pk/fk, how it handles
    //inheritance, etc - we need to explicitly override a method that comes from that DbContext base class
    //called OnModelCreating()
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {   
    //     //Here we override EF Core's default assumption as to how we want our items/pets/documents modeled
    //     //in our database, by forcing to use Table-Per-Concrete-Type mapping. This will create
    //     //a separate table with all columns for objects that are part of an inheritance hierarchy. 
    //     modelBuilder.Entity<Item>().UseTpcMappingStrategy()
    //         .ToTable("Items");
    //     modelBuilder.Entity<Pet>()
    //         .ToTable("Pets");
    //     modelBuilder.Entity<Document>()
    //         .ToTable("Documents");

    //     //We explicitly named our other tables, so why not?
    //     modelBuilder.Entity<User>()
    //         .ToTable("Users");

    //     // modelBuilder.Entity<User>()
    //     //     .HasMany(e => e.items)
    //     //     .WithOne(e => e.user)

    // }

}