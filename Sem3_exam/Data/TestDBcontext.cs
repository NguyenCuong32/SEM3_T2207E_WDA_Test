using Sem3_exam.Mains.Models;
using Microsoft.EntityFrameworkCore;


namespace Sem3_exam.Data
{
    public class TestDBcontext :DbContext
    {
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestUser>().ToTable("Employee_Tbl");//Employee_Tbl là tên bảng bên SQL Server
            modelBuilder.Entity<TestJob>().ToTable("Department_Tbl");
        }

        public TestDBcontext(DbContextOptions<TestDBcontext> options) : base(options)
        { }


        public DbSet<TestJob> Department_Tbl { get; set; }
        public DbSet<TestUser> Employee_Tbl { get; set; }
        // Thuộc tính kiểu DbSet đại diện cho bảng or tập hợp các đối tượng có kiểu  User Model.

    }
}
