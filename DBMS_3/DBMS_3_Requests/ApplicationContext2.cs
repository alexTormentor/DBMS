using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Requests;

public class ApplicationContext2 : DbContext
{
    public DbSet<Type> Type { get; set; } = null!;
    public DbSet<Mech2> Mech2 { get; set; } = null!; 
    public DbSet<Corpus2> Corpus2 { get; set; } = null!;
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}