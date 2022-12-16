using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Loading;

public class ApplicationContext4 : DbContext
{
    public DbSet<Mech> Mech { get; set; } = null!;
    public DbSet<Corpus> Corpus { get; set; } = null!;
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}