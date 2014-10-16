using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Shop_App
{
    class Shop
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public List<Product> products { set; get; }
        public Dictionary<string, Product> products1 { set; get; }


        public Shop(string name , string address)
        {
            Name = name;
            Address = address;

            products = new List<Product>();
            products1 = new Dictionary<string, Product>();
        }

        public string AddProduct(Product aProduct)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].ProductId == aProduct.ProductId)
                {
                    products[i].Quantity += aProduct.Quantity;
                    return "Product Updated";
                }
            }
            
            products.Add(aProduct);
            return "Product Added";
        }


        public string GetDetailsProduct(Shop aShop)
        {
            ProductGateWay aProductGateWay = new ProductGateWay();
          

            string msg = "Shop : " + aShop.Name + "\n" + "Address :" + aShop.Address + "\n";

            msg += "product Id\t\tQuantity\n"; 
            
          
            products = aProductGateWay.GetListOfProducts();


            foreach (Product aProduct in products)
            {
                msg += aProduct.ProductId + "\t\t" + aProduct.Quantity.ToString()+"\n";
            }

            return msg;
        }


        public string AddUsingDictionary(Product aProduct)
        {
            if (products1.ContainsKey(aProduct.ProductId))
            {
                products1[aProduct.ProductId.ToString()].Quantity += aProduct.Quantity;
                return "Product Updated";
            }
            products1.Add(aProduct.ProductId ,aProduct);
            return "Product Added"; 
        }
    }
}
