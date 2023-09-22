using System;
using Microsoft.EntityFrameworkCore;
using Test_Tranthimaihien.Models;

namespace Test_Tranthimaihien.DAL
{
	public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}

