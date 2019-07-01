using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FCC_RestService.Entity;
namespace FCC_RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here

        #region Customer
        [OperationContract]
         IList<Customer> GetAllCustomer();
        [OperationContract]
        bool InsertCustomer(Customer c);
        [OperationContract]
        bool UpdateCustomer(Customer c);
        [OperationContract]
        bool DeleteCustomer(int CustomerID);
        [OperationContract]
        IList<Customer> GetCustomerById(int  ProductID);
        #endregion

        #region Product
        [OperationContract]
        IList<Product> GetAllProduct();
        [OperationContract]
        bool InsertProduct(Product c);
        [OperationContract]
        bool UpdateProduct(Product c);
        [OperationContract]
        bool DeleteProduct(int ProductID);
        [OperationContract]
        IList<Product> GetProductById(int ProductID);
        #endregion

        #region Customer_Product
        [OperationContract]
        bool InsertCustomer_Product(Customer_Product c);
        [OperationContract]
        IList<Balance> GetBalanceProduct();

        #endregion



    }


 
}


