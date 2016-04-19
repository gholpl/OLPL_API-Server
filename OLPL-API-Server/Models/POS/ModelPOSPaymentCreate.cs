using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLPL_API_Server.Models.POS
{
    public class ModelPOSPaymentCreate
    {
        public int transID { get; set; }
        public string paymentType { get; set; }
        public decimal paymentAmount { get; set; }
        public decimal paymentChange { get; set; }
        public decimal paymentTotal { get; set; }
        public DateTime paymentDate { get; set; }
        public string transType { get; set; }
        public string stationType { get; set; }
    }
}