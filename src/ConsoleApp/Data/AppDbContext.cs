using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<ArgumentPair> ArgumentPairs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=localhost;Database=arguments;Uid=dev;Pwd=dev123;");
    }
}