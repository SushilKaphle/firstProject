using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SockManagement
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source=sushil;Initial Catalog=Batch36;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from UserInfo", cnn);
            cnn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();

        }
    }
}