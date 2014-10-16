using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Super_Shop_App
{
    class ProductGateWay
    {

        private SqlConnection connection;
        private string TABLE_NAME2;

        public ProductGateWay()
        {
            string connectionString = @"server=LAB1_59\SQLEXPRESS; 
                                database=ABC_SHOP;
                                integrated security=true";

            TABLE_NAME2 = "table_Product1";


            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
        }




        public bool GetProductQuantity(Product aNewProduct)
        {

            connection.Open();


            string query = string.Format("SELECT ProductQuantity " +
                                         "FROM {1} WHERE productId = {0}",aNewProduct.ProductId,TABLE_NAME2);




            SqlCommand aSqlCommand = new SqlCommand(query, connection);
            SqlDataReader aReader = aSqlCommand.ExecuteReader();

            bool returnVal = false;
            
            if (aReader.HasRows)
            {
                returnVal = true;
            }
            

            connection.Close();
            return returnVal;
        }

 

        public int UpdateNewQuantityWith(Product productWitNewQuantity)
        {
            string query = string.Format("UPDATE {2} SET ProductQuantity = {0} WHERE ProductId = {1}"
                                         ,productWitNewQuantity.Quantity , productWitNewQuantity.ProductId ,TABLE_NAME2);

            return ExecuteQuery(query);
        }





        public bool ProductIdMatchFound(string productId)
        {

            string query = string.Format("SELECT * FROM {1} WHERE ProductId={0}"
                ,productId,TABLE_NAME2);


            connection.Open();


            SqlCommand aSqlCommand = new SqlCommand(query, connection);
            SqlDataReader aReader = aSqlCommand.ExecuteReader();

            bool hasRows = aReader.HasRows;

            connection.Close();

            return hasRows;

        }

        public void InsertNewProdeuct(Product aNewProduct)
        {
            string query = string.Format("INSERT INTO {2} VALUES ({0} ,{1})", 
                aNewProduct.ProductId ,aNewProduct.Quantity, TABLE_NAME2);

            ExecuteQuery(query);
        }




        public int ExecuteQuery(string query)
        {
            connection.Open();

            SqlCommand aSqlCommand = new SqlCommand(query, connection);
            int result = aSqlCommand.ExecuteNonQuery();


            connection.Close();


            return result;
        }

        public int GetQuantity(Product aNewProduct)
        {
            string query = string.Format("SELECT ProductQuantity FROM " +
                                         "{1} WHERE ProductId = {0}",aNewProduct.ProductId , TABLE_NAME2);


            connection.Open();


            SqlCommand command = new SqlCommand(query , connection);

            SqlDataReader aSqlDataReader = command.ExecuteReader();

            if (aSqlDataReader.HasRows)
            {
                int tempQunatity = -10;

                while(aSqlDataReader.Read())
                    tempQunatity = Convert.ToInt32(aSqlDataReader.GetValue(0));


                connection.Close();
                return tempQunatity;
            }


            connection.Close();



            return -1;

        }

        public List<Product> GetListOfProducts()
        {

            List<Product> products = new List<Product>();
            Product aProduct;


            connection.Open();

            string query = string.Format("SELECT ProductId ,ProductQuantity FROM {0}", TABLE_NAME2);
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader aSqlDataReader = command.ExecuteReader();

            if (aSqlDataReader.HasRows)
            {
                int tempQunatity = -10;

                while (aSqlDataReader.Read())
                {
                    aProduct = new Product();
                    aProduct.ProductId = aSqlDataReader.GetValue(0).ToString();
                    aProduct.Quantity = Convert.ToInt32(aSqlDataReader.GetValue(1));

                   products.Add(aProduct);
                }
                connection.Close();
                
            }


            connection.Close();
            return products;
        }
    }
}
