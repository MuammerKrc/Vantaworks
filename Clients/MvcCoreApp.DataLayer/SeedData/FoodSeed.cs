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
    public class FoodSeed : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            string description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.";
            builder.HasData(new List<Food>()
            {
                new Food(){Price=18.2m,ImageUrl="menu/pizza.jpg", IsHome=false,Id=1,CategoryId=1,Name="New York Pizza",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/pizza.jpg", IsHome=false,Id=2,CategoryId=1,Name="Neapolitan pizza",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/pizza.jpg", IsHome=false,Id=3,CategoryId=1,Name="Sicilya stili pizza",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/pizza.jpg", IsHome=false,Id=4,CategoryId=1,Name="Romana Pizza",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/pizza.jpg", IsHome=false,Id=5,CategoryId=1,Name="Chicago Pizza.",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/burger.jpg",IsHome=false,Id=6,CategoryId=2,Name="Beyaz Peynirli Burger",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/burger.jpg",IsHome=false,Id=7,CategoryId=2,Name="3. Rokforlu Burger",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/burger.jpg",IsHome=false,Id=8,CategoryId=2,Name="4. Tavuk Burger",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/burger.jpg",IsHome=false,Id=9,CategoryId=2,Name="Dana Baconlı Burger",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,Id=10,CategoryId=3,Name="Balık Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,Id=11,CategoryId=3,Name="Special Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,Id=12,CategoryId=3,Name="Tavuk Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,Id=13,CategoryId=3,Name="Körili Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,Id=14,CategoryId=3,Name="Gurme Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,Id=15,CategoryId=3,Name="Acılı Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,Id=16,CategoryId=3,Name="Balık Noodle",Description=description},
            });                               
        }
    }
}
