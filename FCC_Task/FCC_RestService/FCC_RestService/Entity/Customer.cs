using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FCC_RestService.Entity
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int CUSTOMER_ID { get; set; }
        [DataMember]
        public string  CUSTOMER_NO { get; set; }
        [DataMember]
        public string CUSTOMER_NAME { get; set; }
        [DataMember]
        public string LANG_CODE { get; set; }
        [DataMember]
        public int SUBSCRIPTION_TYPE_ID { get; set; }
        [DataMember]
        public string EmailID { get; set; }
        [DataMember]
        public int  Mobile { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}



