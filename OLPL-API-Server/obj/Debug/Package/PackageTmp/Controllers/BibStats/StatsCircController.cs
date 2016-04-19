using OLPL_API_Server.Models.StatsCirc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers
{
    public class StatsCircController : ApiController
    {
        public string Get(string id)
        {
            return "1";
        }
        public string Post(DataModelStatsCirc dd1)
        {
            try
            {
                Models.StatsCirc.DataSetStatsCircTableAdapters.OLPL_Apps_Stats_CircTableAdapter tbConnection = new Models.StatsCirc.DataSetStatsCircTableAdapters.OLPL_Apps_Stats_CircTableAdapter();
                DataSetStatsCirc.OLPL_Apps_Stats_CircDataTable tbResults = new DataSetStatsCirc.OLPL_Apps_Stats_CircDataTable();
                tbConnection.FillBySearch(tbResults,dd1.dateReport,dd1.iAudiance,dd1.iType);
                if (tbResults.Count > 0)
                {
                    foreach(DataSetStatsCirc.OLPL_Apps_Stats_CircRow row1 in tbResults)
                    {
                        tbConnection.UpdateQuery(dd1.dateReport, dd1.iType, dd1.iAudiance,dd1.stat,row1.id);
                    }
                   
                }
                else
                {
                    tbConnection.InsertQuery(dd1.dateReport, dd1.iAudiance, dd1.iType, dd1.stat);
                }
                return "OK";
            }
            catch(Exception e)
            {
                return "Error Accured " + e.Message;
            }
           
               
        }
    }
}
