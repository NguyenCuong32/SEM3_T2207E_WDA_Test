using Microsoft.EntityFrameworkCore;
using Test22_9.Models;

namespace Test22_9.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
      
    }
}