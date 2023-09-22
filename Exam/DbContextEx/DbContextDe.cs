using Microsoft.EntityFrameworkCore;
using Exam.Models;

namespace Exam.DBcontextEx
{
    public class DbContextDe : DbContext
    {
        public DbContextDe(DbContextOptions<DbContextDe> options):base(options) { }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DepartmentModel>().ToTable("Department_Tbl");
            modelBuilder.Entity<EmployeeModel>().ToTable("Employee_Tbl");
        }

        DbSet<DepartmentModel> DepartmentModels;
        public DbSet<Exam.Models.DepartmentModel> DepartmentModel { get; set; } = default!;
        public DbSet<Exam.Models.EmployeeModel> EmployeeModel { get; set; } = default!;

    }

}
 