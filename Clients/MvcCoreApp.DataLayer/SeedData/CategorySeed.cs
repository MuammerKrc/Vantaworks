using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcCoreApp.CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.DataLayer.SeedData
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            string description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.";
            builder.HasData(new List<Category>() {
            new Category(){Id=1,Description=description,Name="Pizza"},
            new Category(){Id=2,Description=description,Name="Burger"},
            new Category(){Id=3,Description=description,Name="Noodle"},
            });
        }
    }
}
