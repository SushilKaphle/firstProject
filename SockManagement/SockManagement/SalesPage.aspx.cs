using DataAccessTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SockManagement
{
    public partial class SalesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ProductDataEccess data = new ProductDataEccess();
                ddlProductId.DataSource = data.GetProductId();
                ddlProductId.DataValueField = "ProductId";
                ddlProductId.DataTextField = "ProductId";
                ddlProductId.DataBind();
                ddlProductId.Items.Insert(0, "select");
            }

                 
        }

        protected void ddlProductId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProductId.SelectedValue != "select")
            {
                int selectProductId = Convert.ToInt32(ddlProductId.SelectedValue);
                ProductDataEccess data = new ProductDataEccess();
               // var test = data.GetProduct().ToList().Select(x => new Products());
                var User = data.GetProduct().ToList().Select(x => new Products()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductType = x.ProductType,
                    PDiscription = x.PDiscription,
                })
                .ToList().Where(x => x.ProductId == selectProductId).FirstOrDefault();
                txtProductId.Text = Convert.ToString(User.ProductId);
                txtProductName.Text = User.ProductName;
                txtProductType.Text = User.ProductType;
                txtPDiscription.Text = User.PDiscription;
            }
        }
    }
}