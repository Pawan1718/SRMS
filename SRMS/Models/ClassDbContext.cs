// ClassDbContext.cs
using Microsoft.EntityFrameworkCore;
using SRMS.Models;

public class ClassDbContext : DbContext
{
    public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
    {
    }

    // DbSet for ClassModel
    public DbSet<ClassModel> Classes { get; set; }

    // Add other DbSets for additional models if needed

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your model relationships and constraints here
        // Example: modelBuilder.Entity<ClassModel>().HasKey(c => c.ClassId);

        base.OnModelCreating(modelBuilder);
    }
}
