using Microsoft.EntityFrameworkCore;
using WDATest_NgoMinhKhoi.Models;

namespace WDATest_NgoMinhKhoi.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }

        DbSet<Department> departments;
        DbSet<Employee> employees;
        public DbSet<WDATest_NgoMinhKhoi.Models.Department> Department { get; set; } = default!;
        public DbSet<WDATest_NgoMinhKhoi.Models.Employee> Employee { get; set; } = default!;
    }
}
