using Microsoft.EntityFrameworkCore;
using NguyenQuangTao.Models;

namespace NguyenQuangTao
{
    public class DepartmentDbContext:DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DepartmentDbContext() : base() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DepartmentDbContext(DbContextOptions<DepartmentDbContext> options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DbSet<DepartmentDbContext> Departments;
        public object Department { get; internal set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().ToTable("Department_Tbl");

        }
        
        public DbSet<NguyenQuangTao.Models.Department> Department_1 { get; set; } = default!;
        
        public DbSet<NguyenQuangTao.Models.Employee> Employee { get; set; } = default!;
    }
}
