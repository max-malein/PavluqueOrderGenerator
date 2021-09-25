using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PavluqueOrderGenerator.Model
{
    public class Product
    {
        [Key]
        public string SKU { get; set; }
        public ProductType Type { get; set; }
        public ProductPrint Print { get; set; }
        public string Name { get; set; }
        public string[] Sizes { get; set; }
        public double Price { get; set; }
    }
}
