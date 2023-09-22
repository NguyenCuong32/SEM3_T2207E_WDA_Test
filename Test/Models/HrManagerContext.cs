using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test.Models;

public partial class HrManagerContext : DbContext
{
    public HrManagerContext()
    {
    }

    public HrManagerContext(DbContextOptions<HrManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DepartmentTbl> DepartmentTbls { get; set; }

    public virtual DbSet<EmployeeTbl> EmployeeTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=125.212.224.99,1433;Initial Catalog=HR_Manager;User ID=Duclv;Password=123456a@;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentTbl>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__C2232422F50214FD");

            entity.ToTable("Department_Tbl");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(128)
                .HasColumnName("department_id");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(128)
                .HasColumnName("department_name");
            entity.Property(e => e.Location)
                .HasMaxLength(128)
                .HasColumnName("location");
        });

        modelBuilder.Entity<EmployeeTbl>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__1299A861D5F85EBC");

            entity.ToTable("Employee_Tbl");

            entity.Property(e => e.EmpId)
                .HasMaxLength(128)
                .HasColumnName("emp_id");
            entity.Property(e => e.Department)
                .HasMaxLength(128)
                .HasColumnName("department");
            entity.Property(e => e.EmpName)
                .HasMaxLength(128)
                .HasColumnName("emp_name");
            entity.Property(e => e.Mail)
                .HasMaxLength(128)
                .HasColumnName("mail");
            entity.Property(e => e.Password)
                .HasMaxLength(512)
                .HasColumnName("password");
            entity.Property(e => e.Rank)
                .HasMaxLength(128)
                .HasColumnName("rank");

            entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.EmployeeTbls)
                .HasForeignKey(d => d.Department)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Tbl_Department_Tbl");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
