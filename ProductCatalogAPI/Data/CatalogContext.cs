using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {

        public CatalogContext(DbContextOptions options) : base (options)
        {
 
        }
       
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogSize> CatalogSizes { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogBrand>(e =>
            {
                e.Property(b => b.Id)
                .ValueGeneratedOnAdd();
                e.Property(b => b.Brand)
                .HasMaxLength(100)
                .IsRequired();
            });
            modelBuilder.Entity<CatalogType>(t =>
            {
                t.Property(t => t.Id)
                .ValueGeneratedOnAdd();
                t.Property(t => t.Type)
                .HasMaxLength(100)
                .IsRequired();
            });
             modelBuilder.Entity<CatalogSize>(s => 
             {
                 s.Property(s => s.Id)
                 .ValueGeneratedOnAdd();
                 s.Property(s => s.Size)
                 .IsRequired();
            });
            modelBuilder.Entity<CatalogItem>(i =>
            {
                i.Property(i => i.Id)
                .ValueGeneratedOnAdd();
                i.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);
                i.Property(i => i.PictureUrl)
                .IsRequired();
                i.Property(i => i.Price)
                .IsRequired();
                i.Property(i => i.Description);
                i.HasOne(c => c.CatalogType)
                .WithMany()
                .HasForeignKey(c => c.CatalogTypeId);
                i.HasOne(s => s.CatalogSize)
                .WithMany()
                .HasForeignKey(s => s.CatalogSizeId);
                i.HasOne(b => b.CatalogBrand)
                .WithMany()
                .HasForeignKey(b => b.CatalogBrandId);
            });
        }

    }
}
