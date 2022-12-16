using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Requests;

public class ApplicationContext3 : DbContext
{
    public DbSet<Mech3> Mech3 { get; set; } = null!;
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}