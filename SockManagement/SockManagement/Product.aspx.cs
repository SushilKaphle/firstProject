using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataAccessTier;
using System.Web.UI.WebControls;

namespace SockManagement
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductDataEccess data = new ProductDataEccess();
                grdProduct.DataSource = data.GetProduct();
                grdProduct.DataBind();
                ddlProductId.DataSource = data.GetProductId();
                ddlProductId.DataValueField = "ProductId";
                ddlProductId.DataTextField = "ProductId";
                ddlProductId.DataBind();
                ddlProductId.Items.Insert(0, "select");
            }
          
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductDataEccess data = new ProductDataEccess();
            Products items = new Products();

            items.ProductId = Convert.ToInt32(txtProductId.Text);
            items.ProductName = txtProductName.Text;
            items.ProductType = txtProductType.Text;
            items.PDiscription = txtPDiscription.Text;
            data.AddProduct(items);
            Response.Redirect("Product.aspx");
       
        }

        protected void ddlProductId_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                
                if (ddlProductId.SelectedValue != "Select");
            { 
                int selectProductId = Convert.ToInt32(ddlProductId.SelectedValue);
                ProductDataEccess data = new ProductDataEccess();
                var test = data.GetProduct().ToList().Select(x => new Products());
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductDataEccess data = new ProductDataEccess();

            Products item = new Products();

            item.ProductId = Convert.ToInt32(txtProductId.Text);
            item.ProductName = txtProductName.Text;
            item.ProductType = txtProductType.Text;
            item.PDiscription = txtPDiscription.Text;
            
            data.UpdateProduct(item);
            Response.Redirect("Product.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ProductDataEccess data = new ProductDataEccess();
            data.DeleteProduct(Convert.ToInt32(ddlProductId.SelectedValue));
            Response.Redirect("Product.aspx");
        }
    }
}