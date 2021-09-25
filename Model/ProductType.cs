using System.Collections.Generic;

namespace PavluqueOrderGenerator.Model
{
    public class ProductType
    {
        public string Id { get; set; }
        public string SkuCode { get; set; }
        public bool Male { get; set; }
        public bool Child { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}