using Microsoft.EntityFrameworkCore;
using PhamNgocDung.Models;

namespace PhamNgocDung.DAL
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext()
        {

        }
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
        {
        }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeModel>().ToTable("Employee_Tbl");
            modelBuilder.Entity<DepartmentModel>().ToTable("Department_Tbl")
                .HasMany(department => department.Employees)
                .WithOne(employee => employee.Department)
                .HasForeignKey(employee => employee.departmentId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = "Server=localhost,1433;Database=FPT_SEM3;User Id=sa;Password=Hoilamgi#201092;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    
}
