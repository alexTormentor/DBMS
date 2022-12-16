using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Requests;

public class ApplicationContext5 : DbContext
{
    public DbSet<Mech5> Mech5 { get; set; } = null!;
    public DbSet<Power> Power { get; set; } = null!;
    public int RoleId { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mech5>().HasQueryFilter(u => u.Age > 17 && u.RoleId == RoleId);
    }
}