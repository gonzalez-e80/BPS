using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    internal partial class Product
    {
        private void UpdateLowStockFlag()
        {
            if (AmountInStock < 10) //for now a fixed value, can be updated to set a low stock value for different products
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
