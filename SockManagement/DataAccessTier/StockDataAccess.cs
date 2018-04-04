using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public class StockDataAccess
    {
        public void AddStock(Stock Item)
        {
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            SqlCommand cmd = new SqlCommand("AddStock", conn);
            conn.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = Item.ProductId;

            //cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 255).Value = Item.ProductName;
            //cmd.Parameters.Add("@ProductType", SqlDbType.VarChar, 50).Value = Item.ProductType;
            //cmd.Parameters.Add("@PDiscription", SqlDbType.VarChar, 255).Value = Item.PDiscription;
            //cmd.Parameters.Add("@PurchaseId", SqlDbType.Int).Value = Item.PurchaseId;

            cmd.Parameters.Add("@StockQty", SqlDbType.Int).Value = Item.StockQty;
            

            cmd.ExecuteNonQuery();
        }

    }
}
