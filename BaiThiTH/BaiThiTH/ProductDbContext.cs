using BaiThiTH.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiThiTH;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {}
    public DbSet<Department> Department_Tbl { get; set; }
    public DbSet<Employee> Employee_Tbl { get; set; }
}