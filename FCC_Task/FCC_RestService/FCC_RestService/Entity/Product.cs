using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FCC_RestService.Entity
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int  PRODUCTID { get; set; }
        [DataMember]
        public string  PRODUCT_NO { get; set; }
        [DataMember]
        public string PRODUCT_NAME { get; set; }
        [DataMember]
        public bool ACTIVE { get; set; }
        [DataMember]
        public int QUANTITY { get; set; }
    }
}