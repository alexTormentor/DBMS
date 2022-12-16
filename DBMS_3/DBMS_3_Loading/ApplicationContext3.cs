using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Loading;

public class ApplicationContext3 : DbContext
{
    public DbSet<Mech3> Mech3 { get; set; } = null!;
    public DbSet<Corpus3> Corpus3 { get; set; } = null!;
    public DbSet<Weapon> Weapon { get; set; } = null!;
    public DbSet<Corporation2> Corporation2 { get; set; } = null!;
    public DbSet<Status> Status { get; set; } = null!;
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}