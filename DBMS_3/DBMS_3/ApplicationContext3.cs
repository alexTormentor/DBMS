using Microsoft.EntityFrameworkCore;

namespace DBMS_3;

public class ApplicationContext3 : DbContext
{
    public DbSet<Type> Type { get; set; }
    public DbSet<Pilot> Pilot { get; set; }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
    }
}