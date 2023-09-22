using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaiThi.Models;

    public class BaiThiContext : DbContext
    {
        public BaiThiContext (DbContextOptions<BaiThiContext> options)
            : base(options)
        {
        }

        public DbSet<BaiThi.Models.Department> Department { get; set; } = default!;

        public DbSet<BaiThi.Models.Employee>? Employee { get; set; }
    }
