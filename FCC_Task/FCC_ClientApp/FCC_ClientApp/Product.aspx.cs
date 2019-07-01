using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FCC_ClientApp.Models;
using System.Collections;
using FCC_ClientApp.WCFServiceReference1;
using MirrorPlus.FrameWork2.LogManagement;

namespace FCC_ClientApp
{
    public partial class Product : System.Web.UI.Page
    {
        WCFServiceReference1.Service1Client _ServiceObj = new WCFServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindProductDetails();
                ClearControls();
                lblStatus.Text = String.Empty;
            }

        }
        private void ClearControls() //Defined a function to reset asp.net server controls.  
        {
            txtProductNo.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
          
            btnSubmit.Text = "Submit";
            txtProductNo.Focus();
        }
        private void BindProductDetails() //This function defined for bind to grid view.  
        {
            try
            {
                IList li = null;
                li = _ServiceObj.GetAllProduct();
                if (li != null && li.Count > 0)
                    Productgrid.DataSource = li;
                Productgrid.DataBind();
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_Calient APP :BindProduct::", ex);
            }
        }
        private void SaveProductDetails() //This function defined for save data.  
        {
            bool result = false;
            try
            {
                WCFServiceReference1.Product objProduct = new WCFServiceReference1.Product();

                objProduct.PRODUCT_NO = txtProductNo.Text.Trim();
                objProduct.PRODUCT_NAME = txtProductName.Text.Trim();
                objProduct.QUANTITY = Convert.ToInt32(txtQuantity.Text);
               
                result = _ServiceObj.InsertProduct(objProduct);

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
                ClearControls();
                BindProductDetails();
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_Calient APP   ::Product:SaveProductDetails::", ex);
            }
        }

        private void UpdateProductDetails() //This function defined for update data.  
        {
            bool result = false;
            try
            {
                WCFServiceReference1.Product objProduct = new WCFServiceReference1.Product();
                objProduct.PRODUCTID = Convert.ToInt32(ViewState["PRODUCTID"]);
                objProduct.PRODUCT_NO = txtProductNo.Text.Trim();
                objProduct.PRODUCT_NAME = txtProductName.Text.Trim();
                objProduct.QUANTITY = Convert.ToInt32(txtQuantity.Text);
              
                objProduct.ACTIVE = true;
                result = _ServiceObj.UpdateProduct(objProduct);

                if (result)
                {
                    lblStatus.Text = "Record update successfully...";
                    lblStatus.ForeColor = System.Drawing.Color.AliceBlue;
                }
                else
                {
                    lblStatus.Text = "Error !!!";
                    lblStatus.ForeColor = System.Drawing.Color.DarkRed;

                }

                ClearControls();
                BindProductDetails();
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_Calient APP   ::Product:UpdateProductDetails::", ex);
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Update")
            {
                UpdateProductDetails();
            }
            else
            {
                SaveProductDetails();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void lnkEdit_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            WCFServiceReference1.Product objProduct = new WCFServiceReference1.Product();
            try
            {
                objProduct.PRODUCTID = int.Parse(e.CommandArgument.ToString());
                IList<WCFServiceReference1.Product> li = null;
                ViewState["PRODUCTID"] = objProduct.PRODUCTID;

                li = _ServiceObj.GetProductById(objProduct.PRODUCTID);
                if (li != null && li.Count > 0)
                {
                    foreach (var i in li)
                    {
                        if (!string.IsNullOrEmpty(i.PRODUCT_NO))
                            txtProductNo.Text = i.PRODUCT_NO;
                        if (!string.IsNullOrEmpty(i.PRODUCT_NAME))
                            txtProductName.Text = i.PRODUCT_NAME;                    
                            this.txtQuantity.Text = Convert.ToString(i.QUANTITY);
                        
                    }
                    btnSubmit.Text = "Update";
                }
            }
            catch (Exception ex)
            {

                LogManager.Trace("FCC_Calient APP   ::Product:lnk Edit_Command::", ex);
            }
        }

        protected void lnkDelete_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            bool result = false;
            WCFServiceReference1.Product objProduct = new WCFServiceReference1.Product();

            try
            {
                objProduct.PRODUCTID = int.Parse(e.CommandArgument.ToString());

                result = _ServiceObj.DeleteProduct(objProduct.PRODUCTID);
                if (result)
                {
                    lblStatus.Text = "Record Is Deleted Successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblStatus.Text = "Record couldn't be deleted";
                    lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
                }
                BindProductDetails();
            }
            catch (Exception ex)
            {

                LogManager.Trace("FCC_Calient APP   ::Product:lnkDelete_Command::", ex);
            }

        }


    }
}