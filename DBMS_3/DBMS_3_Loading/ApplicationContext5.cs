using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Loading;

public class ApplicationContext5 : DbContext
{
    public DbSet<Mech4> Mech4 { get; set; } = null!;
    public DbSet<Corpus4> Corpus4 { get; set; } = null!;
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()        // подключение lazy loading
            .UseSqlite("Data Source=helloapp.db");
    }
}