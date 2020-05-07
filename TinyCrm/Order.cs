using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string DeliveryAdress { get; set; }
        public decimal TotalAmount { get; set; }

        public List<Product> ProductsOfOrder = new List<Product>();
    }
}
