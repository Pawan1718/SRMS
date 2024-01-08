using Microsoft.EntityFrameworkCore;

namespace SRMS.Models
{
    public class SubjectDbContext : DbContext
    {
        public SubjectDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Error");
            }
        }
        public SubjectDbContext(DbContextOptions options) : base(options) 
        {
                
        }
        public DbSet<SubjectModel>Subjects { get; set; }
    }
}
