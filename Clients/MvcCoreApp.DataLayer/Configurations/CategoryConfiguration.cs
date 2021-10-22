using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcCoreApp.CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.DataLayer.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i=>i.Id).UseIdentityColumn();
            builder.Property(i => i.Name).IsRequired().HasMaxLength(30);
            builder.Property(i => i.Description).IsRequired().HasMaxLength(500);
        }
    }
}
