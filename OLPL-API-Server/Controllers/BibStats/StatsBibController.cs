using OLPL_API_Server.Models.StatsBib;
using OLPL_API_Server.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers
{
    public class StatsBibController : ApiController
    {
        public string Get(string id)
        {
            return "1";
        }
        public void Post(DataModelStatsBib dd1)
        {
            StatsBibFunctions fn1 = new StatsBibFunctions();
            DataModelStatsBibRecord tempData = fn1.setTempData();
            tempData = fn1.getSQLData(tempData, dd1);
            if (tempData.statPTotal == 0) { tempData.statPTotal = fn1.getPTotal(tempData, dd1); }
            if (dd1.statType == "Adds") { tempData.statAdds = dd1.stat; }
            if (dd1.statType == "Total") { tempData.statTotal = dd1.stat; }
            tempData.iType = dd1.iType;
            tempData.iAudiance = dd1.iAudiance;
            tempData.dateReport = dd1.dateReport;
            tempData.dateCreated = DateTime.Now;
            tempData.statNet = tempData.statTotal - tempData.statPTotal;
            tempData.statDeletes = tempData.statPTotal + tempData.statAdds - tempData.statTotal;
            if (tempData.statDeletes < 0) { tempData.statDeletes = tempData.statDeletes * -1; }
            fn1.proccessData(tempData);
        }
    }
}
