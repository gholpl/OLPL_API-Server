using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLPL_API_Server.Models.POS
{
    public class ModelPOSCheckCount
    {
        public int checkNumber { get; set; }
        public decimal checkAmount { get; set; }
        public string countOperator { get; set; }
        public DateTime dateCount { get; set; }
        public DateTime dateTrans { get; set; }
        public string countType { get; set; }
    }
}