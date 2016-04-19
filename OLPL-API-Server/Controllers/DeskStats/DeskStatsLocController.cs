using OLPL_API_Server.Models.DeskStats;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers
{
    public class DeskStatsLocController : ApiController
    {
        public string Get()
        {
            return "11111";
        }
        public string Get(string id)
        {
            Models.DeskStats.DeskStatsLocTableAdapters.DeskStatsLocationsTableAdapter tb = new Models.DeskStats.DeskStatsLocTableAdapters.DeskStatsLocationsTableAdapter();
            Models.DeskStats.DeskStatsLoc.LocationsDataTable tb1 = new Models.DeskStats.DeskStatsLoc.LocationsDataTable();
            tb.FillBy(tb1, id);
            if (tb1.Count > 0)
            {
                string name = "";
                foreach(DeskStatsLoc.LocationsRow row1 in tb1)
                {
                    name= row1.Name;
                }
                return name;
                //return String.Join(Environment.NewLine, tb1.Rows.OfType<DataRow>().Select(x => String.Join(" ; ", x.ItemArray)));
            }
            else { return "NotFound"; }
        }

        // POST: api/DeskStatsLoc
        public void Post(Models.DeskStats.ModelDeskStatsLoc dd1)
        {
            if (dd1.CPUName != null)
            {
                Models.DeskStats.DeskStatsLocTableAdapters.DeskStatsLocationsTableAdapter tb = new Models.DeskStats.DeskStatsLocTableAdapters.DeskStatsLocationsTableAdapter();
                Models.DeskStats.DeskStatsLoc.LocationsDataTable tb1 = new Models.DeskStats.DeskStatsLoc.LocationsDataTable();
                tb.FillBy(tb1, dd1.CPUName);
                if (tb1.Count > 0)
                {
                    tb.UpdateQuery(dd1.Location, dd1.CPUName);
                }
                else
                {
                    tb.InsertQuery(dd1.Location, dd1.CPUName);
                }
            }

        }
    }
}
