using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public partial class Product
    {
        public static int StockThreshold = 5;
        public static void ChangeStockThreshold (int newStockThreshold)
        {
            if (newStockThreshold > 0)//only update if value is above 0
                StockThreshold = newStockThreshold;
        }
        private void UpdateLowStockFlag()
        {
            if (AmountInStock < StockThreshold) //for now a fixed value, can be updated to set a low stock value for different products
            {
                IsBelowStockTreshold = true;
            }
            else
            {
                IsBelowStockTreshold = false;
            }
        }

        private void Log(string message)
        {
            Console.WriteLine(message); //Messages are printed to the console but the method is implemented in case you wanted to write them somewhere else
        }

        private string SimpleProductRepresetation()
        {
            return $"Product {id} ({name})";
        }
    }
}
