using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data
{
    public class MiniShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //modeli oluştururken kullanılacak metod
        //2 tablomuz var product ve categories
        //tablolar arasında olmayan bir ilişki kullanmamak icin foreign key kullanmalıyız.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .HasMany(cat => cat.Products) //her categorynin birden fazla productu var
                        .WithOne(product => product.Category)//her productın bir categorysi var
                        .HasForeignKey(product => product.CategoryId); //category ve product arasındaki foreign key categoryId denetleme yapar.

            /* //Bu şekilde de yapabilirsin , ama ikisi bir arada olamaz birini kullanmalısın
             *modelBuilder.Entity<Product>()
             *           .HasOne(p => p.Category)
             *          .WithMany(c => c.Products)
             *         .HasForeignKey(p => p.CategoryId);
             */
            base.OnModelCreating(modelBuilder);
        }
        // Veritabanını  masaüstü uygulamasında ayağa kaldırmak için yazıyoruz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Databasein nerde oluşturacağını söyleyeceğiz
            if (!optionsBuilder.IsConfigured)
            {
                // sql serveri kullanarak oluştur
                optionsBuilder.UseSqlServer("Server=(localdb)\\Mssqllocaldb ;Database=TrendyolDb ;Integrated Security=yes"); //connection string

            }
        }
    }
}
