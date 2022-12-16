using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Loading;

public class ApplicationContext2 : DbContext
{
    public DbSet<Mech2> Mech { get; set; } = null!;
    public DbSet<Corpus2> Corpus { get; set; } = null!;
    public DbSet<MechCore> Core { get; set; } = null!;
     
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}