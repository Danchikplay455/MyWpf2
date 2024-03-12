using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWpf2;

class ApplicationContext : DbContext
{
    public DbSet<client> client { get; set; } = null!;
    public DbSet<route> route { get; set; } = null!;
    public DbSet<ticket> ticket { get; set; } = null!;
    public ApplicationContext() 
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=buss;Username=user;Password=12345");
    }


}
     

    
