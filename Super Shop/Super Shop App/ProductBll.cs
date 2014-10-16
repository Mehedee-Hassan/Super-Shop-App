using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Super_Shop_App
{
    class ProductBll
    {

        private ProductGateWay aProductGateWay;
        

   

        public ProductBll()
        {
            aProductGateWay = new ProductGateWay();
        }


        public string Add(Product aNewProduct)
        {
            
            
            int tempProductQuantity = aNewProduct.Quantity;

            if (ProductExixts(aNewProduct.ProductId))
            {
                if (aProductGateWay.GetProductQuantity(aNewProduct))
                {


                    tempProductQuantity = aProductGateWay.GetQuantity(aNewProduct);


                    aNewProduct.Quantity += tempProductQuantity;

                    if (aProductGateWay.UpdateNewQuantityWith(aNewProduct) <= 0)
                    {
                        return "update failed";
                    }
                
                }

                return "Updated !!";
            }


            aProductGateWay.InsertNewProdeuct(aNewProduct);
            return "Added";
        }

        private bool ProductExixts(string productId)
        {

           
            if (aProductGateWay.ProductIdMatchFound(productId))
            {
                return true;
            }
            return false;
        }
    }

}
