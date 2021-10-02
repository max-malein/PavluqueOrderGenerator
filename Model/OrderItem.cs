using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PavluqueOrderGenerator.Model
{
    public class OrderItem
    {
        [Key]
        public string Sku { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public string Code128Text => BarcodeGenerator.Code128.Encode(Sku);

        public ICollection<Order> SavedOrders { get; set; }
    }
}
