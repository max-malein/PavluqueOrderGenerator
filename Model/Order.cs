using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PavluqueOrderGenerator.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastEdited { get; set; }

        [Column(TypeName ="jsonb")]
        public List<OrderItem> Orders { get; set; }
    }
}
