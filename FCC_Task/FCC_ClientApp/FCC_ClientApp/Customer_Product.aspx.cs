using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FCC_ClientApp.Models;
using System.Collections.Generic;
using System.Collections;
using FCC_ClientApp.WCFServiceReference1;
using MirrorPlus.FrameWork2.LogManagement;

namespace FCC_ClientApp
{
    public partial class Customer_Product : System.Web.UI.Page
    {
        WCFServiceReference1.Service1Client _ServiceObj = new WCFServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateCustomer();
                PopulateProduct();
                BindCustomer_Product();
               // textBox1.Attributes.Add("onblur", "validate(this);");
            }

        }
        private void BindCustomer_Product()
        {

            IList<WCFServiceReference1.Balance> myObjectList = null;
            try
            {
                myObjectList = _ServiceObj.GetBalanceProduct();
                if (myObjectList != null && myObjectList.Count > 0)
                {
                    this.CustomerProductgrid.DataSource = myObjectList;
                    this.CustomerProductgrid.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_Calient APP :Customer_Product:BindCustomer_Product::", ex);
            }
        }
        private void PopulateCustomer()
        {
            IList<WCFServiceReference1.Customer> myObjectList = null;
            try
            {
                myObjectList = _ServiceObj.GetAllCustomer();
                if (myObjectList != null && myObjectList.Count > 0)
                {
                    ddlCustomer.DataSource = myObjectList;
                    ddlCustomer.DataTextField = "CUSTOMER_NAME"; // exact name of field in class
                    ddlCustomer.DataValueField = "CUSTOMER_ID";
                    ddlCustomer.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_Calient APP :Customer_Product:PopulateCustomer::", ex);
            }
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string dropdownvalue = string.Empty;
            int _value = 0;
            IList<WCFServiceReference1.Product> myObjectList = null;
            try
            {
                _value = Convert.ToInt32(ddlProduct.SelectedItem.Value);          
                myObjectList = _ServiceObj.GetAllProduct();
                if (myObjectList != null && myObjectList.Count > 0)
                {
                    var quty = myObjectList.Where(x => x.PRODUCTID == _value).Select(x => x.QUANTITY).FirstOrDefault();
                       txtProductQuantity.Text = Convert.ToString(quty);
                    
                }
            }
            catch(Exception ex)
            {
                LogManager.Trace("FCC_Calient APP :Customer_Product:OnSelectedIndexChanged::", ex);
            }
            
           
        }
        private void PopulateProduct()
        {
            IList<WCFServiceReference1.Product> myObjectList = null;
            try
            {
                myObjectList = _ServiceObj.GetAllProduct();
                if (myObjectList != null && myObjectList.Count > 0)
                {
                    ddlProduct.DataSource = myObjectList;
                    ddlProduct.DataTextField = "PRODUCT_NAME"; // exact name of field in class
                    ddlProduct.DataValueField = "PRODUCTID";
                    ddlProduct.DataBind();
                   
                }
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_Calient APP :Customer_Product:PopulateProduct::", ex);
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SavetDetails();
        }
        private void SavetDetails() //This function defined for save data.  
        {
            bool result = false;
            try
            {
                WCFServiceReference1.Customer_Product objProduct = new WCFServiceReference1.Customer_Product();
                objProduct.CUSTOMER_ID = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
                objProduct.PRODUCTID = Convert.ToInt32(ddlProduct.SelectedItem.Value);
                objProduct.BALANCE_QTY = Convert.ToInt32(txtProductQuantity.Text) - Convert.ToInt32(txtBoughtPrduct.Text);
                objProduct.BOUGHT_QTY = Convert.ToInt32(txtBoughtPrduct.Text);
                result = _ServiceObj.InsertCustomer_Product(objProduct);

                if (result)
                {
                    lblStatus.Text = "Record save successfully...";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblStatus.Text = "Error !!!";
                    lblStatus.ForeColor = System.Drawing.Color.DarkRed;

                }
               // ClearControls();
                BindCustomer_Product();
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_Calient APP::Customer_Product:SavetDetails::", ex);
            }
        }

        //protected void txtBoughtPrduct_TextChanged(object sender, EventArgs e)

        //{
        //    int a = Convert.ToInt32(txtProductQuantity.Text);
        //    int b = Convert.ToInt32(txtBoughtPrduct.Text);
        //    int c = a - b;
        //    txtProductBalance.Text = Convert.ToString(c);
            
        //}
    }
}