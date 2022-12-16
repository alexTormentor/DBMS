using Microsoft.EntityFrameworkCore;

namespace DBMS_3;

public class ApplicationContext2 : DbContext
{
    public DbSet<Corporation> Corporations { get; set; }
    public DbSet<Mech2> Mech { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
    }
}