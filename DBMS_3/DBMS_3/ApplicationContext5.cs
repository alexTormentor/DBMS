using Microsoft.EntityFrameworkCore;

namespace DBMS_3;

public class ApplicationContext5 : DbContext
{
    public DbSet<Type3> Types { get; set; }
    public DbSet<Pilot3> Pilot { get; set; }
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MechDifficult>()
            .HasKey(t => new { t.PilotID, t.TypeID });
 
        modelBuilder.Entity<MechDifficult>()
            .HasOne(sc => sc.Pilot)
            .WithMany(s => s.MechDifficult)
            .HasForeignKey(sc => sc.PilotID);
 
        modelBuilder.Entity<MechDifficult>()
            .HasOne(sc => sc.Type)
            .WithMany(c => c.MechDifficult)
            .HasForeignKey(sc => sc.TypeID);
    }
     
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
    }
}