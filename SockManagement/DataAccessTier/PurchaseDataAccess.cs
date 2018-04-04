using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public class PurchaseDataAccess
    {
        public List<Purchase> GetPurchase()
        {
            List<Purchase> listPurchase = new List<Purchase>();
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetPurchase", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listPurchase.Add(new Purchase()
                {
                    ProductId = Convert.ToInt32(rd["ProductId"].ToString()),
                    PurchaseId = Convert.ToInt32(rd["PurchaseId"].ToString()),
                    PurchaseQty = Convert.ToInt32(rd["PurchaseQty"].ToString()),
                    PurchasePrice = Convert.ToInt32(rd["Price"].ToString())
                });
            }
            return listPurchase;
        }
        public void AddPurchase(Purchase Item)
        {
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            SqlCommand cmd = new SqlCommand("AddPurchase", conn);
            conn.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = Item.ProductId;

            //cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 255).Value = Item.ProductName;
            //cmd.Parameters.Add("@ProductType", SqlDbType.VarChar, 50).Value = Item.ProductType;
            //cmd.Parameters.Add("@PDiscription", SqlDbType.VarChar, 255).Value = Item.PDiscription;
            //cmd.Parameters.Add("@PurchaseId", SqlDbType.Int).Value = Item.PurchaseId;

            cmd.Parameters.Add("@PurchaseQty", SqlDbType.Int).Value = Item.PurchaseQty;
            cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Item.PurchasePrice;

            cmd.ExecuteNonQuery();
        }

    }
}
