using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeLibary.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Class { get; set; }
        public decimal   Price { get; set; }
        public string Publisher { get; set; }
        public string DateOfPurchase { get; set; }
        public string Language { get; set; }
        public string  Type { get; set; }
    }

   
}
