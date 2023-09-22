using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PhongBanModel>().ToTable("PhongBan");
            modelBuilder.Entity<NhanVienModel>().ToTable("NhanVien");
        }
        DbSet<PhongBanModel> PhongBanModels;
        DbSet<NhanVienModel> NhanVienModels;
        public DbSet<WebApplication1.Models.PhongBanModel>? PhongBanModel { get; set; }
        public DbSet<WebApplication1.Models.NhanVienModel>? NhanVienModel { get; set; }
        
    }
    
}




