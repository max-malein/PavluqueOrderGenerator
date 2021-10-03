using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using PavluqueOrderGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PavluqueOrderGenerator.Pages.Shared.Components
{
    public class OrderItemsViewComponent : ViewComponent
    {
        private readonly PavluqueContext context;

        public OrderItemsViewComponent(PavluqueContext context)
        {
            this.context = context;
        }
        public async Task<ViewViewComponentResult> InvokeAsync(int orderId)
        {
            ViewBag.ProductNames = context.Products.OrderBy(p => p.SKU).Select(p => p.Name).ToArray();
            ViewBag.OrderIdDisabled = "disabled";

            var order = await context.Orders.FindAsync(orderId);
            if (order == null || !order.Orders.Any())
            {
                ViewBag.OrderIdDisabled = "";

                order = new Order()
                {
                    Id = orderId,
                    DateCreated = DateTime.Now,
                    LastEdited = DateTime.Now,                    
                    Orders = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Quantity = 1,
                        }
                    },                    
                };
            }

            return View(order);
        }
    }
}
