using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLPL_API_Server.Models.SendEMail
{
    public class DataModelSendEMail
    {
        public string from { get; set; }
        public string fromname { get; set; }
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}
