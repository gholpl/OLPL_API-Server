using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLPL_API_Server.Models.POS
{
    public class ModelPOSCCRefund
    {
        public int transID { get; set; }
        public int cc4digits { get; set; }
        public string contactPreference { get; set; }
        public string contactInfo { get; set; }
        public string note { get; set; }
        public string recieptNumber { get; set; }
        public string stationType { get; set; }
    }
}