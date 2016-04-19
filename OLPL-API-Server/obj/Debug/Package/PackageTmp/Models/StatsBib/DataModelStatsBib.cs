using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLPL_API_Server.Models.StatsBib
{
    public class DataModelStatsBib
    {
        public DateTime dateReport { get; set; }
        public string iType { get; set; }
        public string iAudiance { get; set; }
        public int stat { get; set; }
        public string statType { get; set; }
    }
}