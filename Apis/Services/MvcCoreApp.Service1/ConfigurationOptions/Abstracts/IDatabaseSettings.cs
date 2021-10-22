using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.ConfigurationOptions.Abstracts
{
    public interface IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string FoodCollectionName { get; set; }
        public string SliderCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
