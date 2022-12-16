using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Loading;

public class ApplicationContext : DbContext
{
    public DbSet<Mech> Mech { get; set; } = null!;
    public DbSet<Corpus> Corpus { get; set; } = null!;
    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}