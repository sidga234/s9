using FCC_RestService.Entity;
using MirrorPlus.FrameWork2.LogManagement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FCC_RestService
{


    public class Service1 : IService1
    {
        string ms_Conn = ConfigurationManager.ConnectionStrings["CPT_ConnectionString"].ConnectionString;

        #region Customer

        public IList<Customer> GetAllCustomer()
        {
            List<Customer> listCustomer = new List<Customer>();
            try
            {


                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Customer_q", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@strCase", "1"));
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Customer objCustomer = new Customer();
                        objCustomer.CUSTOMER_ID = Convert.ToInt32(rdr["CUSTOMER_ID"]);
                        objCustomer.CUSTOMER_NO = Convert.ToString(rdr["CUSTOMER_NO"]);
                        objCustomer.CUSTOMER_NAME = Convert.ToString(rdr["CUSTOMER_NAME"]);
                        objCustomer.LANG_CODE = Convert.ToString(rdr["LANG_CODE"]);
                        objCustomer.SUBSCRIPTION_TYPE_ID = Convert.ToInt32(rdr["SUBSCRIPTION_TYPE_ID"]);
                        objCustomer.EmailID = Convert.ToString(rdr["EmailID"]);
                        objCustomer.Mobile = Convert.ToInt32(rdr["Mobile"]);
                        objCustomer.Active = Convert.ToBoolean(rdr["Active"]);

                        listCustomer.Add(objCustomer);
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService::Customer:GetAllCustomer::", ex);
            }
            return listCustomer;

        }

        public IList<Customer> GetCustomerById(int CustomerID)
        {
            List<Customer> listCustomer = new List<Customer>();
            try
            {


                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Customer_q", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@strCase", "2"));
                    cmd.Parameters.Add(new SqlParameter("@Customer_ID", CustomerID));
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Customer objCustomer = new Customer();
                        objCustomer.CUSTOMER_ID = Convert.ToInt32(rdr["CUSTOMER_ID"]);
                        objCustomer.CUSTOMER_NO = Convert.ToString(rdr["CUSTOMER_NO"]);
                        objCustomer.CUSTOMER_NAME = Convert.ToString(rdr["CUSTOMER_NAME"]);
                        objCustomer.LANG_CODE = Convert.ToString(rdr["LANG_CODE"]);
                        objCustomer.SUBSCRIPTION_TYPE_ID = Convert.ToInt32(rdr["SUBSCRIPTION_TYPE_ID"]);
                        objCustomer.EmailID = Convert.ToString(rdr["EmailID"]);
                        objCustomer.Mobile = Convert.ToInt32(rdr["Mobile"]);
                        objCustomer.Active = Convert.ToBoolean(rdr["Active"]);

                        listCustomer.Add(objCustomer);
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService::Customer:GetAllCustomer::", ex);
            }
            return listCustomer;

        }

        //To Add new customer record 
        public bool InsertCustomer(Customer objCustomer)


        {
            try
            {
                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Customer_i", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CUSTOMER_NO", objCustomer.CUSTOMER_NO);
                    cmd.Parameters.AddWithValue("@CUSTOMER_NAME", objCustomer.CUSTOMER_NAME);
                    cmd.Parameters.AddWithValue("@LANG_CODE", objCustomer.LANG_CODE);
                    cmd.Parameters.AddWithValue("@SUBSCRIPTION_TYPE_ID", objCustomer.SUBSCRIPTION_TYPE_ID);
                    cmd.Parameters.AddWithValue("@EmailID", objCustomer.EmailID);
                    cmd.Parameters.AddWithValue("@mobile", objCustomer.Mobile);
                    cmd.Parameters.AddWithValue("@Active", objCustomer.Active);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService::Customer:InsertCustomer::", ex);
                return false;
                
            }
        }

        public bool UpdateCustomer(Customer objCustomer)


        {
            try
            {
                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Customer_u", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CUSTOMER_ID", objCustomer.CUSTOMER_ID);
                    cmd.Parameters.AddWithValue("@CUSTOMER_NO", objCustomer.CUSTOMER_NO);
                    cmd.Parameters.AddWithValue("@CUSTOMER_NAME", objCustomer.CUSTOMER_NAME);
                    cmd.Parameters.AddWithValue("@LANG_CODE", objCustomer.LANG_CODE);
                    cmd.Parameters.AddWithValue("@SUBSCRIPTION_TYPE_ID", objCustomer.SUBSCRIPTION_TYPE_ID);
                    cmd.Parameters.AddWithValue("@EmailID", objCustomer.EmailID);
                    cmd.Parameters.AddWithValue("@mobile", objCustomer.Mobile);
                    cmd.Parameters.AddWithValue("@Active", objCustomer.Active);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService::Customer:UpdateCustomer::", ex);
                return false;

            }
        }

        public bool DeleteCustomer(int CustomerID)


        {
            try
            {
                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Customer_d", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Customer_ID", CustomerID);                   
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService::Customer:DeleteCustomer::", ex);
                return false;

            }
        }

        #endregion


        #region Product

        public IList<Product> GetAllProduct()
        {
            List<Product> listProduct = new List<Product>();
            try
            {


                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Product_q", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@strCase", "1"));
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Product objProduct = new Product();
                        objProduct.PRODUCTID = Convert.ToInt32(rdr["PRODUCTID"]);
                        objProduct.PRODUCT_NO = Convert.ToString(rdr["PRODUCT_NO"]);
                        objProduct.PRODUCT_NAME = Convert.ToString(rdr["PRODUCT_NAME"]);
                        objProduct.QUANTITY = Convert.ToInt32(rdr["QUANTITY"]);
                        objProduct.ACTIVE = Convert.ToBoolean(rdr["ACTIVE"]);
                        listProduct.Add(objProduct);
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService:GetAllProduct::", ex);
            }
            return listProduct;

        }

        public IList<Product> GetProductById(int ProductID)
        {
            List<Product> listProduct = new List<Product>();
            try
            {


                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Product_q", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@strCase", "2"));
                    cmd.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Product objProduct = new Product();
                        objProduct.PRODUCTID = Convert.ToInt32(rdr["PRODUCTID"]);
                        objProduct.PRODUCT_NO = Convert.ToString(rdr["PRODUCT_NO"]);
                        objProduct.PRODUCT_NAME = Convert.ToString(rdr["PRODUCT_NAME"]);
                        objProduct.QUANTITY = Convert.ToInt32(rdr["QUANTITY"]);
                        objProduct.ACTIVE = Convert.ToBoolean(rdr["ACTIVE"]);
                        listProduct.Add(objProduct);

                        
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService::GetProductById::", ex);
            }
            return listProduct;

        }

        //To Add new product record 
        public bool InsertProduct(Product objProduct)


        {
            try
            {
                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Product_i", con);
                    cmd.CommandType = CommandType.StoredProcedure;                     
                    cmd.Parameters.AddWithValue("@Product_No", objProduct.PRODUCT_NO);
                    cmd.Parameters.AddWithValue("@Product_Name", objProduct.PRODUCT_NAME);
                    cmd.Parameters.AddWithValue("@Quantity", objProduct.QUANTITY);
                    cmd.Parameters.AddWithValue("@Active", objProduct.ACTIVE);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService:InsertProduct::", ex);
                return false;

            }
        }

        public bool UpdateProduct(Product objProduct)


        {
            try
            {
                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Product_u", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", objProduct.PRODUCTID);
                    cmd.Parameters.AddWithValue("@Product_No", objProduct.PRODUCT_NO);
                    cmd.Parameters.AddWithValue("@Product_Name", objProduct.PRODUCT_NAME);
                    cmd.Parameters.AddWithValue("@Quantity", objProduct.QUANTITY);
                    cmd.Parameters.AddWithValue("@Active", objProduct.ACTIVE);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService:UpdateProduct::", ex);
                return false;

            }
        }

        public bool DeleteProduct(int ProductID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Product_d", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService:DeleteProduct::", ex);
                return false;

            }
        }

        #endregion


        #region Custom_Product

        public bool InsertCustomer_Product(Customer_Product objProduct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Customer_Product_i", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CUSTOMER_ID", objProduct.CUSTOMER_ID);
                    cmd.Parameters.AddWithValue("@ProductID", objProduct.PRODUCTID);
                    cmd.Parameters.AddWithValue("@Bought_Qty", objProduct.BOUGHT_QTY);
                    cmd.Parameters.AddWithValue("@Balance_Qty", objProduct.BALANCE_QTY);                    
                    cmd.Parameters.AddWithValue("@Active", objProduct.Active);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService:InsertCustomer_Product::", ex);
                return false;

            }
        }

        public IList<Balance> GetBalanceProduct()
        {
            List<Balance> listbalance = new List<Balance>();
            try
            {


                using (SqlConnection con = new SqlConnection(ms_Conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_Customer_Product_q", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@strCase", "2"));
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Balance objbalace = new Balance();
                        objbalace.Customer_no = Convert.ToString(rdr["Customer_no"]);
                        objbalace.Customer_Name= Convert.ToString(rdr["Customer_Name"]);
                        objbalace.Product_No= Convert.ToString(rdr["Product_No"]);
                        objbalace.Product_Name= Convert.ToString(rdr["Product_Name"]);
                        objbalace.Quantity = Convert.ToInt32(rdr["Quantity"]);
                        objbalace.Bought_Qty = Convert.ToInt32(rdr["Bought_Qty"]);
                        objbalace.Balance_Qty = Convert.ToInt32(rdr["Balance_Qty"]);
                        listbalance.Add(objbalace);
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                LogManager.Trace("FCC_RestService:GetBalanceProduct::", ex);
            }
            return listbalance;

        }

        #endregion 

    }


}
