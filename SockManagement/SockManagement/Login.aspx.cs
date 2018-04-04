using DataAccessTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SockManagement
{
    public partial class Login : System.Web.UI.Page
    {
       // private object txtPassword;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=Sushil;Initial Catalog=Batch36;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from UserInfo", conn);
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                if (txtUserName.Text== rd.GetString(3)  && (txtPassword1.Text == rd.GetString(4)))
                {
                    Response.Redirect("Home.aspx");
                }
            }
            txtMessage.Text = "Access Denied";
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            UserDataAccess data = new UserDataAccess();
            User user = new User();
            if(data.GetUsers().ToList().Where(x=>(x.UserName == txtUserName.Text && x.Password == txtPassword1.Text)).Any())
            {
                string userType = data.GetUsers().ToList().Where(x => x.UserName == txtUserName.Text).ToList().Select(xx => 
                xx.UserType).FirstOrDefault().ToString();

                Response.Redirect("Sign Up.aspx?UserType=" + userType);

            }
            else
            {
                Response.Redirect("Sign Up.aspx?UserType=-1");
            }

        }
    }
}