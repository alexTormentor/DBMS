using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Mech> Mechas { get; set; }
    public DbSet<MechSystem> MechSys { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mech>()
            .HasOne(u => u.MechSys).WithOne(p => p.Mech)
            .HasForeignKey<MechSystem>(up => up.Id);
        modelBuilder.Entity<Mech>().ToTable("Users");
        modelBuilder.Entity<MechSystem>().ToTable("Users");
    }
}