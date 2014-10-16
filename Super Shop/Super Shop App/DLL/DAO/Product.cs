using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Shop_App
{
    class Product
    {

        public string ProductId { get; set; }
        public int Quantity { get; set; }
        
        
        public Product(string productId  , int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public Product()
        {
        }


    }
}
