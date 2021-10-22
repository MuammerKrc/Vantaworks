using MvcCoreApp.Service1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.SeedData
{
    public class CategorySeedData
    {
        public List<Category> Categories { get; set; }

        public CategorySeedData()
        {
            string description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.";

            Categories = new List<Category>()
            {
            new Category(){Description=description,Name="Pizza"},
            new Category(){Description=description,Name="Burger"},
            new Category(){Description=description,Name="Noodle"},
            };
        }
    }
}
