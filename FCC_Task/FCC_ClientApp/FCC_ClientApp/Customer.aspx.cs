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
    public partial class Customer : System.Web.UI.Page
    {
        WCFServiceReference1.Service1Client _ServiceObj = new WCFServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {        
            if (!Page.IsPostBack)
            {
                BindCustomerDetails();
                ClearControls();
                lblStatus.Text = String.Empty;
            }

        }
        private void ClearControls() //Defined a function to reset asp.net server controls.  
        {
            txtCustomerNo.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            ddlLanguageCode.SelectedIndex = ddlLanguageCode.Items.IndexOf(ddlLanguageCode.Items.FindByValue("0"));
            ddlSubcription.SelectedIndex = ddlSubcription.Items.IndexOf(ddlSubcription.Items.FindByValue("0"));
            btnSubmit.Text = "Submit";
            txtCustomerNo.Focus();
        }
        private void BindCustomerDetails() //This function defined for bind to grid view.  
        {
            try
            {
                IList li = null;
                li = _ServiceObj.GetAllCustomer();
                if (li != null && li.Count > 0)
                    Customergrid.DataSource = li;
                Customergrid.DataBind();
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_Calient APP   ::Customer:BindCustomer::", ex);
            }
        }
        private void SaveCustomerDetails() //This function defined for save data.  
        {
            bool result = false;
            try { 
            WCFServiceReference1.Customer objCustomer = new WCFServiceReference1.Customer();

            objCustomer.CUSTOMER_NO = txtCustomerNo.Text.Trim();
            objCustomer.CUSTOMER_NAME = txtCustomerName.Text.Trim();
            objCustomer.LANG_CODE = ddlLanguageCode.SelectedItem.Value;
            objCustomer.SUBSCRIPTION_TYPE_ID = Convert.ToInt32(ddlSubcription.SelectedItem.Value);
            objCustomer.Mobile = Convert.ToInt32(txtMobile.Text);
            objCustomer.EmailID = txtEmail.Text.Trim();
                objCustomer.Active = true;
            result = _ServiceObj.InsertCustomer(objCustomer);

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
            BindCustomerDetails();
        }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_Calient APP   ::Customer:SaveCustomerDetails::", ex);
            }
        }

        private void UpdateCustomerDetails() //This function defined for update data.  
        {
            bool result = false;
            try
            {
                WCFServiceReference1.Customer objCustomer = new WCFServiceReference1.Customer();
                objCustomer.CUSTOMER_ID = Convert.ToInt32(ViewState["CUSTOMER_ID"]);
                objCustomer.CUSTOMER_NO = txtCustomerNo.Text.Trim();
                objCustomer.CUSTOMER_NAME = txtCustomerName.Text.Trim();
                objCustomer.LANG_CODE = ddlLanguageCode.SelectedItem.Value;
                objCustomer.SUBSCRIPTION_TYPE_ID = Convert.ToInt32(ddlSubcription.SelectedItem.Value);
                objCustomer.Mobile = Convert.ToInt32(txtMobile.Text);
                objCustomer.EmailID = txtEmail.Text.Trim();
                objCustomer.Active = true;
                result = _ServiceObj.UpdateCustomer(objCustomer);

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
                BindCustomerDetails();
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_Calient APP   ::Customer:UpdateCustomerDetails::", ex);
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {            
            if (btnSubmit.Text == "Update")
            {
                UpdateCustomerDetails();
            }
            else
            {
                SaveCustomerDetails();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void lnkEdit_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            WCFServiceReference1.Customer objCustomer = new WCFServiceReference1.Customer();
            try
            {
                objCustomer.CUSTOMER_ID = int.Parse(e.CommandArgument.ToString());
                IList<WCFServiceReference1.Customer> li = null;
                ViewState["CUSTOMER_ID"] = objCustomer.CUSTOMER_ID;

                li = _ServiceObj.GetCustomerById(objCustomer.CUSTOMER_ID);
                if (li != null && li.Count > 0)
                {
                    foreach (var i in li)
                    {
                        if (!string.IsNullOrEmpty(i.CUSTOMER_NO))
                            txtCustomerNo.Text = i.CUSTOMER_NO;
                        if (!string.IsNullOrEmpty(i.CUSTOMER_NAME))
                            txtCustomerName.Text = i.CUSTOMER_NAME;
                        if (!string.IsNullOrEmpty(i.EmailID))
                            this.txtEmail.Text = i.EmailID;
                        txtMobile.Text = Convert.ToString(i.Mobile);
                       
                        ddlLanguageCode.SelectedIndex = ddlLanguageCode.Items.IndexOf(ddlLanguageCode.Items.FindByValue(i.LANG_CODE));
                        ddlSubcription.SelectedIndex = ddlSubcription.Items.IndexOf(ddlSubcription.Items.FindByValue(Convert.ToString(i.SUBSCRIPTION_TYPE_ID)));
                        //ddlActive.SelectedIndex = ddlActive.Items.IndexOf(ddlActive.Items.FindByValue(Convert.ToString(i.Active)));

                    }
                    btnSubmit.Text = "Update";
                }
            }
            catch (Exception ex) {

                LogManager.Trace("FCC_Calient APP   ::Customer:lnk Edit_Command::", ex);
            }
        }
        
        protected void lnkDelete_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            bool result = false;
            WCFServiceReference1.Customer objCustomer = new WCFServiceReference1.Customer();

            try
            {
                objCustomer.CUSTOMER_ID = int.Parse(e.CommandArgument.ToString());

                result = _ServiceObj.DeleteCustomer(objCustomer.CUSTOMER_ID);
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
                BindCustomerDetails();
            }
            catch (Exception ex)
            {

                LogManager.Trace("FCC_Calient APP   ::Customer:lnkDelete_Command::", ex);
            }

        }
    }
}