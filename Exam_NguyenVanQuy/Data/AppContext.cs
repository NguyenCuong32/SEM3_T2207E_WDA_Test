using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamMVC_NguyenVanQuy.Models;

    public class AppContext : DbContext
    {
        public AppContext (DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<ExamMVC_NguyenVanQuy.Models.Department> Department { get; set; } = default!;

        public DbSet<ExamMVC_NguyenVanQuy.Models.Employee>? Employee { get; set; }
    }
