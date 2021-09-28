using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PavluqueOrderGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace PavluqueOrderGenerator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private PavluqueContext context;
        public string Message { get; set; }
        public string SizeLink => "~/Index?handler=sizes";

        public string[] ProductNames => context.Products.OrderBy(p => p.SKU).Select(p => p.Name).ToArray();

        [BindProperty]
        [FromForm]
        public Order[] Orders { get; set; }

        public IndexModel(ILogger<IndexModel> logger, PavluqueContext context)
        {
            _logger = logger;
            this.context = context;


        }

        public void OnGet()
        {
            // Заполнить базу данных
            //if (!context.Products.Any())
            //{
            //    CreateProductDatabase();
            //}
            Console.WriteLine();
        }

        private void CreateProductDatabase()
        {
            var filePath = @"E:\Repos\PavluqueOrderGenerator\InitialData\Товар.csv";
            if (!System.IO.File.Exists(filePath))
                return;

            string csv = string.Empty;
            try
            {
                csv = System.IO.File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                return;
            }

            if (string.IsNullOrEmpty(csv))
                return;

            var data = csv.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Skip(1) // заголовки
                .Select(r => r.Trim().Split(';'))
                .ToArray();

            foreach (var row in data)
            {
                var name = row[0];
                var sku = row[1];
                var sizes = row[2].Split(',');
                var price = Convert.ToDouble(row[3]);

                var type = context.ProductTypes.Where(t => t.SkuCode == sku.Substring(0, 2)).FirstOrDefault();
                var print = context.ProductPrints.Where(p => p.SkuCode == sku.Substring(2)).FirstOrDefault();

                var product = new Product()
                {
                    Name = name,
                    Print = print,
                    Type = type,
                    Sizes = sizes,
                    SKU = sku,
                    Price = price,
                };

                context.Products.Add(product);
            }

            context.SaveChanges();
        }

        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var request = Request;
            var btn = Request.Form["Button"];

            Console.WriteLine("Yes");

            var order = Orders[0];

            Console.ReadLine();

            return new OkResult();
        }

        public IActionResult OnPostStickers()
        {
            if (!ModelState.IsValid)
                return Page();

            var stream = BarcodeGenerator.ExcelWriter.SaveBarcodes(@"E:\Repos\PavluqueOrderGenerator\Model\Barcode\Templates\templateRound.xlsx", Orders);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "barcodes.xlsx");

            return new OkResult();
        }

        public IActionResult OnGetSizes()
        {
            var prods = context.Products.ToArray();

            return new OkObjectResult(prods);
        }
    }
}
