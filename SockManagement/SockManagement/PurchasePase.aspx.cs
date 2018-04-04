using DataAccessTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SockManagement
{
    public partial class PurchasePase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {

                ProductDataEccess data = new ProductDataEccess();
                //PurchaseDataAccess data = new PurchaseDataAccess();
                 ddlProductId.DataSource = data.GetProductId();
                 ddlProductId.DataValueField = "ProductId";
                 ddlProductId.DataTextField = "ProductId";
                 ddlProductId.DataBind();
                 ddlProductId.Items.Insert(0, "select");
                 
                //PurchaseDataAccess data = new PurchaseDataAccess();


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
                   // PurchaseId = x.PurchaseId
                })
                .ToList().Where(x => x.ProductId == selectProductId).FirstOrDefault();
                txtProductId.Text = Convert.ToString(User.ProductId);
                txtProductName.Text = User.ProductName;
                txtProductType.Text = User.ProductType;
                txtPDiscription.Text = User.PDiscription;
               // txtPurchaseId.Text = User.PurchaseId;
            }


        }

        protected void btnAddPurchase_Click(object sender, EventArgs e)
        {
            PurchaseDataAccess data = new PurchaseDataAccess();
            StockDataAccess stockData = new StockDataAccess();
            //ProductDataEccess data = new ProductDataEccess();
            Purchase items = new Purchase();
            Stock stockItems = new Stock();

            items.ProductId = Convert.ToInt32(txtProductId.Text);
            items.PurchaseQty = Convert.ToInt32(txtQty.Text);
            items.PurchasePrice = Convert.ToInt32(txtPrice.Text);
            
           // items.PurchaseId = Convert.ToInt32(txtPurchaseId.Text);
            //items
            data.AddPurchase(items);
            stockItems.ProductId = Convert.ToInt32(txtProductId.Text);
            stockItems.StockQty = Convert.ToInt32(txtQty.Text);
            stockData.AddStock(stockItems);
        }
    }
}