using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement
{
    internal class Product
    {
        private int id;
        private string name = string.Empty;
        private string? description;

        private int maxItemsInStock = 0;
        private UnitType unitType;
        private int amountInStock = 0;
        private bool isBelowStockTreshold = false;

        public void UseProduct (int items)
        {
            if (items <= amountInStock)
            {
                amountInStock -= items;
                UpdateLowStockFlag();
                Log($"Amount in stock updated. Now {amountInStock} items in stock.");
            }
            else
            {
                Log($"Not enough items on stock for {SimpleProductRepresetation()}. {amountInStock} available but {items} requested.");
            }
        }

        public void IncreaseStock()
        {
            amountInStock++;
        }

        public void DecreaseStock(int items, string reason)
        {
            if (items <=amountInStock)
            {
                amountInStock -= items;
            }
            else
            {
                amountInStock = 0;
            }
            UpdateLowStockFlag();
            Log(reason);
        }
        public string DisplayDetailsFull()
        {
            StringBuilder sb = new ();
            //ToDo: add price here too
            sb.Append($"{id} {name} \n{description}\n{amountInStock} item(s) in stock");

            if (isBelowStockTreshold)
            {
                sb.Append("\nSTOCK LOW!!");
            }
            return sb.ToString();
        }

        private void UpdateLowStockFlag()
        {
            if (amountInStock < 10) //for now a fixed value, can be updated to set a low stock value for different products
            {
                isBelowStockTreshold = true;
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
