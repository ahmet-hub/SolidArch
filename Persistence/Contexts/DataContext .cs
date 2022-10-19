using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class DataContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ModelImage> ModelImages { get; set; }

        public DataContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DemoDbConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(a =>
            {
                a.ToTable("Brands").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id").HasDefaultValueSql("newsequentialid()");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Model>(a =>
            {
                a.ToTable("Models").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id").HasDefaultValueSql("newsequentialid()");
                a.Property(p => p.BrandId).HasColumnName("BrandId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                a.HasOne(p => p.Brand);
                a.HasMany(p => p.Images);

            });

            modelBuilder.Entity<ModelImage>(a =>
            {
                a.ToTable("ModelImage").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id").HasDefaultValueSql("newsequentialid()");
                a.Property(p => p.ImageUrl).HasColumnName("ImageUrl").HasMaxLength(5);
                a.HasOne(p => p.Model);
            });
        }
    }
}
