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
        //private UnitType unitType;
        //private int amountInStock = 0;
        //private bool isBelowStockTreshold = false;

        public int Id 
        { 
            get { return id; } 
            set {  id = value; } 
        }
        public string Name 
        { 
            get { return name; } 
            set { name = value.Length > 50 ? value[..50] : value;} 
        }
        //checks the value of the name, if longer than 50, truncate it to 50
        public string? Description 
        { 
            get { return description; } 
            set 
            { 
                if (value == null) 
                { 
                    description = string.Empty; 
                } 
                else 
                { 
                    description = value.Length > 250 ? value[..250] : value;
                    //checks the value of the desc, if longer than 250, truncate it to 250
                }
            } 
        }
        public UnitType UnitType { get;  set; }
        public int AmountInStock { get; private set; }
        public bool IsBelowStockTreshold { get; private set; }
        //these are auto properties, no need for the private fields above

        public void UseProduct (int items)
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;
                UpdateLowStockFlag();
                Log($"Amount in stock updated. Now {AmountInStock} items in stock.");
            }
            else
            {
                Log($"Not enough items on stock for {SimpleProductRepresetation()}. {AmountInStock} available but {items} requested.");
            }
        }

        public void IncreaseStock()
        {
            AmountInStock++;
        }

        public void DecreaseStock(int items, string reason)
        {
            if (items <=AmountInStock)
            {
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }
            UpdateLowStockFlag();
            Log(reason);
        }
        public string DisplayDetailsFull()
        {
            StringBuilder sb = new ();
            //ToDo: add price here too
            sb.Append($"{id} {name} \n{description}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
            {
                sb.Append("\nSTOCK LOW!!");
            }
            return sb.ToString();
        }

        private void UpdateLowStockFlag()
        {
            if (AmountInStock < 10) //for now a fixed value, can be updated to set a low stock value for different products
            {
                IsBelowStockTreshold = true;
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
