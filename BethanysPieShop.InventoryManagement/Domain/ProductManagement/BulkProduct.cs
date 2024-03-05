using BethanysPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public class BulkProduct : Product
    {
        public BulkProduct(int id, string name, string? descritpion, Price price, int maxAmountInStock) : base(id, name, descritpion, price, UnitType.PerKg, maxAmountInStock) { }
    }
}
