using Microsoft.EntityFrameworkCore;
using WCD_test.Models;

namespace WCD_test.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>().ToTable("Employee_Tbl");
        modelBuilder.Entity<Department>().ToTable("Department_Tbl");
    }
}