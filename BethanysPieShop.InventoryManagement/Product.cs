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
            if (items <= 0) { return; }
        }
    }
}
