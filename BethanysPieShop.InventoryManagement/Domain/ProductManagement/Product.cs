using BethanysPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public partial class Product
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
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value.Length > 50 ? value[..50] : value; }
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
        public UnitType UnitType { get; set; }
        public int AmountInStock { get; private set; }
        public bool IsBelowStockTreshold { get; private set; }
        //these are auto properties, no need for the private fields above
        public Price Price { get; set; }
        public Product(int id) : this(id, string.Empty)
        {
        }
        public Product(int Id, string Name)
        {
            this.Id = Id; //using the this keyword, ge ar referencing an istance of the property passing in the value from the cosntructor
            this.Name = Name;
        }
        public Product(int id, string name, string? description, Price price, UnitType unitType, int maxAmountinStock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            UnitType = unitType;
            maxItemsInStock = maxAmountinStock;
            UpdateLowStockFlag();
        }
        //Constructor Overloading


        public void UseProduct(int items)
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
        public void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount;
            if (newStock <= maxItemsInStock)
            {
                AmountInStock = amount;
            }
            else
            {
                AmountInStock = maxItemsInStock; //storing what is possible, overstock is ignored
                Log($"{SimpleProductRepresetation} stock overflow. {newStock - AmountInStock}item(s) ordered that could not be stored.");
            }
            UpdateLowStockFlag();
        }

        public void DecreaseStock(int items, string reason)
        {
            if (items <= AmountInStock)
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
            return DisplayDetailsFull("");
        }

        public string DisplayDetailsFull(string extraDetails)
        {
            StringBuilder sb = new StringBuilder();
            //ToDo: add price here too
            sb.Append($"{id} {name} \n{description}\n{Price}\n{AmountInStock} item(s) in stock");
            sb.Append(extraDetails);

            if (IsBelowStockTreshold)
            {
                sb.Append("\nSTOCK LOW!!");
            }
            return sb.ToString();
        }
        //Method Overloading
    }
}
