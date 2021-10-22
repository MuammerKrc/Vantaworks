using Microsoft.EntityFrameworkCore;
using MvcCoreApp.CoreLayer.Models;
using MvcCoreApp.DataLayer.Configurations;
using MvcCoreApp.DataLayer.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuration
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new FoodConfiguration());
            modelBuilder.ApplyConfiguration(new SliderConfiguration());
            //seed
            modelBuilder.ApplyConfiguration(new CategorySeed());
            modelBuilder.ApplyConfiguration(new FoodSeed());
            modelBuilder.ApplyConfiguration(new SliderSeed());
        }
    }
}
