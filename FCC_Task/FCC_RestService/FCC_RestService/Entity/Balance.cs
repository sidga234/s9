using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FCC_RestService.Entity
{
    [DataContract]
    public class Balance
    {
        [DataMember]
        public string Customer_no { get; set; }
        [DataMember]
        public string Customer_Name { get; set; }
        [DataMember]
        public string Product_No { get; set; }
        [DataMember]
        public string Product_Name { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public int Bought_Qty { get; set; }
        [DataMember]
        public int Balance_Qty { get; set; }


        
    }
}