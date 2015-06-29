using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLPL_API_Server
{
    public class SecDataModel
    {
        public string CPUName { get; set; }
        public string TimeContact { get; set; }
        public string Result_Admin_User { get; set; }
        public string Result_Admin_Group { get; set; }
        public string Result_User_Pass_Changed { get; set; }
        public string Result_Maint_User { get; set; }
    }
}