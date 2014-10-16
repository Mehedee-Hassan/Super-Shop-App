using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Super_Shop_App.BLL;

namespace Super_Shop_App
{
    class ShopBll
    {

        Shop aShop;
        ShopGateWay aShopGateWay;
        public string Save(Shop aShop)
        {
 
            aShopGateWay = new ShopGateWay();



            aShop = new Shop(aShop.Name ,aShop.Address);
            int isSaved = aShopGateWay.Save(aShop);

            if (isSaved > 0)
            {
                return "Saved !";
            }

            return "Could not Insert";
        }
    }
}
