using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace Super_Shop_App.BLL
{
    class ShopGateWay
    {

        private SqlConnection connection;
        private string TABLE_NAME1;


        public ShopGateWay()
        {
            string connectionString = @"server=LAB1_59\SQLEXPRESS; 
                                database=ABC_SHOP;
                                integrated security=true";
            
            TABLE_NAME1 = "table_Shop";


            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

        }

        public int Save(Shop aShop)
        {
            connection.Open();

            string query = string.Format("INSERT INTO {2} VALUES('{0}','{1}');"
                ,aShop.Name ,aShop.Address,TABLE_NAME1);


            SqlCommand command = new SqlCommand(query ,connection);
            
            int affectedRow = command.ExecuteNonQuery();


            connection.Close();

            return affectedRow;
        }
    }
}
