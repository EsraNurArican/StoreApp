using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class Product
    {
        // ıd is primary key
        public int Id { get; set; }
        public string ImageAddress { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }

        public Category Category { get; set; }
        public string ProductInfos { get; set; }
        public int CategoryId { get; set; }
       
        /* We deleted vendor class for now
         * It had only one ILıst<Product> property
         * public Vendor Vendor { get; set; }
         */
    }
}
