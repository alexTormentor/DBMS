using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Requests;

public class ApplicationContext4 : DbContext
{
    public DbSet<Mech4> Mech4 { get; set; } = null!;
 
    public ApplicationContext4()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // добавляем один объект
        modelBuilder.Entity<Mech4>().HasData(new Mech4 { Id = 1, Name = "Tom" });
    }
}