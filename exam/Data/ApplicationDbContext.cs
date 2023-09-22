using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using exam.Models;

namespace exam.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<exam.Models.Department> Department { get; set; } = default!;
        public DbSet<exam.Models.Employee> Employee { get; set; } = default!;
    }
}