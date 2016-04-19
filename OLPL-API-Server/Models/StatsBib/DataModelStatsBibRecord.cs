using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLPL_API_Server.Models.StatsBib
{
    public class DataModelStatsBibRecord
    {
        public int id { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateReport { get; set; }
        public string iType { get; set; }
        public string iAudiance { get; set; }
        public int statPTotal { get; set; }
        public int statAdds { get; set; }
        public int statDeletes { get; set; }
        public int statNet { get; set; }
        public int statTotal { get; set; }
    }
}