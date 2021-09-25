using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PavluqueOrderGenerator.Model
{
    public class ProductPrint
    {
        public string Id { get; set; }
        public string SkuCode { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}