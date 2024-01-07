using Microsoft.EntityFrameworkCore;
using SRMS.Models;

namespace SRMS.Models
{
    public class AdminDbContext : DbContext
    {
       
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {
                
        }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<SRMS.Models.StudentModel>? StudentModel { get; set; }
    }
}
