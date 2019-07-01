using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FCC_RestService.Entity
{
    [DataContract]
    public class Customer_Product
    {
        [DataMember]
        public int CUSTOMER_PRODUCT_ID { get; set; }
        [DataMember]
        public int  CUSTOMER_ID { get; set; }

        [DataMember]
        public int PRODUCTID { get; set; }
        [DataMember]
        public int BOUGHT_QTY { get; set; }
        [DataMember]
        public int BALANCE_QTY { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}