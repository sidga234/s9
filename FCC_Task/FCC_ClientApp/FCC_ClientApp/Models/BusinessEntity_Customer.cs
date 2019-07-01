using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCC_ClientApp.Models
{
    public class BusinessEntity_Customer
    {
       
        public int CUSTOMER_ID { get; set; }
       
        public string CUSTOMER_NO { get; set; }
        
        public string CUSTOMER_NAME { get; set; }
       
        public string LANG_CODE { get; set; }
        
        public int SUBSCRIPTION_TYPE_ID { get; set; }
       
        public string EmailID { get; set; }
      
        public int Mobile { get; set; }
        
        public bool Active { get; set; }
    }
}