using DataAccessTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;





namespace SockManagement
{
    public partial class Sign_Up : System.Web.UI.Page
    {
        //public string Value { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserDataAccess data = new UserDataAccess();

                ddlIds.DataSource = data.GetUsers();
                ddlIds.DataValueField = "Id";
                ddlIds.DataTextField = "Id";
                ddlIds.DataBind();
                ddlIds.Items.Insert(0, "select");
                //ddlIds.Items.Add(new ListItem("select", "0", true));
                if(Request.QueryString["UserType"].ToString() != "1")
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                }
                
            }

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            UserDataAccess data = new UserDataAccess();
            User user = new User();

            user.FirstName = txtFirstName.Text;
            user.LastName = txtLAstName.Text;
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.UserType = Convert.ToInt32(rblUserType.SelectedValue);
            data.AddUser(user);
            Response.Redirect("Login.aspx");

        }
        protected void ddlIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlIds.SelectedValue != "select")
            {
                int selectId = Convert.ToInt32(ddlIds.SelectedValue);
                UserDataAccess data = new UserDataAccess();
                //var test = data.GetUsers().ToList().Select(x => new User());
                var User = data.GetUsers().ToList().Select(x => new User()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Password = x.Password,
                    UserType = x.UserType
                })
                .ToList().Where(x => x.Id == selectId).FirstOrDefault();
                txtFirstName.Text = User.FirstName;
                txtLAstName.Text = User.LastName;
                txtUserName.Text = User.UserName;
                txtPassword.Text = User.Password;
                rblUserType.SelectedValue = User.UserType.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UserDataAccess data = new UserDataAccess();

            User user = new User();

            user.FirstName = txtFirstName.Text;
            user.LastName = txtLAstName.Text;
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.UserType = Convert.ToInt32(rblUserType.SelectedValue);
            user.Id = Convert.ToInt32(ddlIds.SelectedValue);
            data.UpdateUser(user);
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            UserDataAccess data = new UserDataAccess();
            data.DeleteUsers(Convert.ToInt32(ddlIds.SelectedValue));
        }
    }
}