using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public class ProductDataEccess
    {
        public List<Products> GetProduct()
        {
            List<Products> listProduct = new List<Products>();
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetProduct", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listProduct.Add(new Products()
                {
                    ProductId = Convert.ToInt32(rd["ProductId"].ToString()),
                    ProductName = rd["ProductName"].ToString(),
                    ProductType = rd["ProductType"].ToString(),
                    PDiscription = rd["PDiscription"].ToString(),
                });
            }
            return listProduct;
        }

        public void AddProduct(Products Item)
        {
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            SqlCommand cmd = new SqlCommand("AddProduct", conn);
            conn.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = Item.ProductId;
            cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 255).Value = Item.ProductName;
            cmd.Parameters.Add("@ProductType", SqlDbType.VarChar, 50).Value = Item.ProductType;
            cmd.Parameters.Add("@PDiscription", SqlDbType.VarChar, 255).Value = Item.PDiscription;

            cmd.ExecuteNonQuery();
        }

        public List<Products> GetProductId()
        {
            List<Products> listProduct = new List<Products>();
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            conn.Open();
            SqlCommand cmd = new SqlCommand("getProductId", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listProduct.Add(new Products()
                {
                    ProductId = Convert.ToInt32(rd["ProductId"])
                });
            }
            return listProduct;
        }

        public void UpdateProduct(Products products)
        {
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            SqlCommand cmd = new SqlCommand("updateProduct", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = products.ProductId;
            cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = products.ProductName;
            cmd.Parameters.Add("@ProductType", SqlDbType.VarChar, 50).Value = products.ProductType;
            cmd.Parameters.Add("@PDiscription", SqlDbType.VarChar, 255).Value = products.PDiscription;
           

            cmd.ExecuteNonQuery();
        }
        public void DeleteProduct(int ProductId)
        {
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            SqlCommand cmd = new SqlCommand("DeleteProduct", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = ProductId;


            cmd.ExecuteNonQuery();
        }

    }



}
