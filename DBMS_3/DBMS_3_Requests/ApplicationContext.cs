using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Requests;

public class ApplicationContext : DbContext
{
    public DbSet<Mech> Mech { get; set; } = null!; 
    public DbSet<Engine> Engine { get; set; } = null!;
     
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}