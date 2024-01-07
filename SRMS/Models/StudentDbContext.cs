using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;

namespace SRMS.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext()
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Error");
            }
        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options)
        {
                
        }
        public DbSet<StudentModel>Students { get; set; }
    }
}
