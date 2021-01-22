using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // One category can have many products
        // Navigation property..
        // To be able to go one object o another
        public IList<Product> Products { get; set; }
    }
}
