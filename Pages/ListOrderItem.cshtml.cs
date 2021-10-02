using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PavluqueOrderGenerator;
using PavluqueOrderGenerator.Model;

namespace PavluqueOrderGenerator.Pages
{
    public class ListOrderModel : PageModel
    {
        private readonly PavluqueOrderGenerator.PavluqueContext _context;

        public ListOrderModel(PavluqueOrderGenerator.PavluqueContext context)
        {
            _context = context;
        }

        public IList<OrderItem> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.OrderItems.ToListAsync();
        }
    }
}
