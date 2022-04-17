using System;
using Microsoft.EntityFrameworkCore;
namespace BoardGames.Models
{
    public class ApplicationContext : DbContext
            {
                //public DbSet<User> Users { get; set; }
                public ApplicationContext()
                {
                    Database.EnsureCreated();
                }
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=isttp1;Username=postgres;Password=231202");
                }
            }
}
