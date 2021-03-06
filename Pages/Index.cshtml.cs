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
    public class IndexModel : PageModel
    {
        private readonly PavluqueOrderGenerator.PavluqueContext _context;

        public IndexModel(PavluqueOrderGenerator.PavluqueContext context)
        {
            _context = context;
        }

        public IList<Order> SavedOrder { get;set; }

        public async Task OnGetAsync()
        {
            SavedOrder = await _context.Orders.ToListAsync();
        }
    }
}
