using Microsoft.EntityFrameworkCore;

namespace DBMS_3;

public class ApplicationContext4 : DbContext
{
    public DbSet<Type2> Type { get; set; }
    public DbSet<Pilot2> Pilot { get; set; }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
    }
         
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Type2>()
            .HasMany(c => c.Pilot)
            .WithMany(s => s.Type)
            .UsingEntity<Testing>(
                j => j
                    .HasOne(pt => pt.Pilot)
                    .WithMany(t => t.Testing)
                    .HasForeignKey(pt => pt.StudentId),
                j => j
                    .HasOne(pt => pt.Type)
                    .WithMany(p => p.Testing)
                    .HasForeignKey(pt => pt.CourseId),
                j =>
                {
                    j.Property(pt => pt.TestDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.Property(pt => pt.Mark).HasDefaultValue(3);
                    j.HasKey(t => new { t.CourseId, t.StudentId });
                    j.ToTable("Enrollments");
                });
    }
}