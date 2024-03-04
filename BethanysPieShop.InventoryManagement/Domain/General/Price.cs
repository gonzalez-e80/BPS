﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.General
{
    internal class Price
    {
        public double ItemPrice { get; set; }
        public Currency Currency { get; set; }
        public override string ToString()
        {
            return $"{ItemPrice}{Currency}";
        }
    }
}
