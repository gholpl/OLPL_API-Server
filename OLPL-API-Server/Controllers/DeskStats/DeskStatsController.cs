using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers
{
    public class DeskStatsController : ApiController
    {
        public string Get()
        {
            return "11111";
        }

        // POST: api/DeskStats
        public void Post(Models.DeskStats.ModelDeskStats dd1)
        {
            if (dd1.strCPU != null)
            {
                Models.DeskStats.DeskStatsMainTableAdapters.MainTableAdapter tbm = new Models.DeskStats.DeskStatsMainTableAdapters.MainTableAdapter();
                Models.DeskStats.DeskStatsMain.MainDataTable tbm1 = new Models.DeskStats.DeskStatsMain.MainDataTable();
                tbm.InsertQuery(dd1.stringLoc, DateTime.Now, dd1.stringComment, dd1.stringType, dd1.strCPU);
            }

        }
    }
}
