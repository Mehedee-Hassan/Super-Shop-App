using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Shop_App
{
    public partial class SuperShopUI : Form
    {
        public SuperShopUI()
        {
            InitializeComponent();
        }

        private Shop aShop;
        ShopBll aShopBll;
        private ProductBll aProductBll;



        private void saveButton_Click(object sender, EventArgs e)
        {
            aShop = new Shop(shopAddressTextBox.Text , shopAddressTextBox.Text);
            aShopBll = new ShopBll();
            
            
            
            aShopBll.Save(aShop);
            showDetailsButton.Enabled = true;
            MessageBox.Show("Shop Created");

        }




        private void addItemButton_Click(object sender, EventArgs e)
        {
            Product aProduct = new Product(itemIdTextBox.Text ,Convert.ToInt32(productQuantityTextBox.Text));

            aProductBll = new ProductBll();
            string msg = aProductBll.Add(aProduct);


            MessageBox.Show(msg);
        }




        private void showDetailsButton_Click(object sender, EventArgs e)
        {
            
            
            
            string msg ="";
            msg += aShop.GetDetailsProduct(aShop);

            MessageBox.Show(msg);
        }

        private void SuperShopUI_Load(object sender, EventArgs e)
        {
            showDetailsButton.Enabled = false;
        }

        
     
    }
}
