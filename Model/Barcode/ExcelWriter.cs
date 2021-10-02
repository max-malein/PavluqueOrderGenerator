using OfficeOpenXml;
using PavluqueOrderGenerator.Model;
using System.Collections.Generic;
using System.IO;


namespace BarcodeGenerator
{
    internal class ExcelWriter
    {
        

        public ExcelWriter()
        {
        }

        internal void CreateFile(List<Product> productData)
        { }

        public static FileInfo SaveBarcodes(string fileName, OrderItem[] productData)
        {
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo fileInfo = new(fileName);
            ExcelPackage p = new(fileInfo);
            ExcelWorksheet myWorksheet = p.Workbook.Worksheets["Лист1"];
            var row = 1;
            var col = 1;
            foreach (OrderItem product in productData)
            {
                //myWorksheet.Cells[row, col].Value = product.ProductName;
                //myWorksheet.Cells[row + 1, col].Value = "Размер - " + product.Size;
                //myWorksheet.Cells[row + 2, col].Value = "Артикул: PAV" + product.Sku.Split('-')[0];
                //myWorksheet.Cells[row + 3, col].Value = product.Code128Text;
                //myWorksheet.Cells[row + 4, col].Value = product.Sku;

                myWorksheet.Cells[row, col].Value = product.Size;
                myWorksheet.Cells[row + 1, col].Value = product.Type;
                myWorksheet.Cells[row + 2, col].Value = product.Code128Text;
                myWorksheet.Cells[row + 3, col].Value = product.Sku;
                myWorksheet.Cells[row + 4, col].Value = "Артикул: PAV" + product.Sku.Split('-')[0];
                myWorksheet.Cells[row + 5, col].Value = "Размер - " + product.Size;                

                NextCell(ref row, ref col);
            }
            //p.SaveAs(new FileInfo(saveAsPath));
            
            var finfo = new FileInfo(System.IO.Path.GetTempFileName());
            p.SaveAs(finfo);
            return finfo;

            //return p.Stream;
            //p.Save();
        }

        private static void NextCell(ref int row, ref int col)
        {
            if(col==7)
            {
                col = 1;
                row += 7;
            }
            else
            {
                col += 2;
            }
        }

        public static void SaveOrder(string fileName, string saveAsPath, List<OrderItem> productData)
        {

            FileInfo fileInfo = new FileInfo(fileName);
            ExcelPackage p = new ExcelPackage(fileInfo);
            ExcelWorksheet myWorksheet = p.Workbook.Worksheets["Заказ"];
            var row = 2;            
            foreach (OrderItem product in productData)
            {
                myWorksheet.Cells[row, 1].Value = product.Sku;
                myWorksheet.Cells[row, 2].Value = product.Quantity;

                row++;
            }
            p.SaveAs(new FileInfo(saveAsPath));
            //p.Save();
        }

    }
}
