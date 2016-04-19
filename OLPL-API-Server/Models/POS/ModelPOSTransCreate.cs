using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLPL_API_Server.Models.POS
{
    public class ModelPOSTransCreate
    {
        public string operatorID { get; set; }
        public string userID { get; set; }
        public string compName { get; set; }
        public string stationType { get; set; }
        public string strData { get; set; }
    }
}