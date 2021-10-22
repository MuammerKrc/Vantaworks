using MvcCoreApp.Service1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.SeedData
{
    public class RecipeSeedData
    {
        public List<Food> Foods{ get; set; }

        public RecipeSeedData(List<string> categoryIds)
        {
            string description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.";
            Foods = new List<Food>()
            {
                new Food(){Price=18.2m,ImageUrl="menu/pizza.jpg", IsHome=false,CategoryId=categoryIds[0],Name="New York Pizza",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/pizza.jpg", IsHome=false,CategoryId=categoryIds[0],Name="Neapolitan pizza",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/pizza.jpg", IsHome=false,CategoryId=categoryIds[0],Name="Sicilya stili pizza",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/pizza.jpg", IsHome=false,CategoryId=categoryIds[0],Name="Romana Pizza",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/pizza.jpg", IsHome=false,CategoryId=categoryIds[0],Name="Chicago Pizza.",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/burger.jpg",IsHome=false,CategoryId=categoryIds[1],Name="Beyaz Peynirli Burger",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/burger.jpg",IsHome=false,CategoryId=categoryIds[1],Name="3. Rokforlu Burger",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/burger.jpg",IsHome=false,CategoryId=categoryIds[1],Name="4. Tavuk Burger",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/burger.jpg",IsHome=false,CategoryId=categoryIds[1],Name="Dana Baconlı Burger",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,CategoryId=categoryIds[2],Name="Balık Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,CategoryId=categoryIds[2],Name="Special Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,CategoryId=categoryIds[2],Name="Tavuk Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,CategoryId=categoryIds[2],Name="Körili Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,CategoryId=categoryIds[2],Name="Gurme Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,CategoryId=categoryIds[2],Name="Acılı Noodle",Description=description},
                new Food(){Price=18.2m,ImageUrl="menu/noddle.jpg",IsHome=false,CategoryId=categoryIds[2],Name="Balık Noodle",Description=description}
            };
        }
    }
}
