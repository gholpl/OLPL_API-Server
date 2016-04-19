using OLPL_API_Server.Models.StatsBib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLPL_API_Server.Functions
{
    public class StatsBibFunctions
    {
        public DataModelStatsBibRecord getSQLData(DataModelStatsBibRecord tempData, DataModelStatsBib dd1)
        {
            Models.StatsBib.DataSetStatsBibTableAdapters.OLPL_Apps_Stats_BibTableAdapter tbConnection = new Models.StatsBib.DataSetStatsBibTableAdapters.OLPL_Apps_Stats_BibTableAdapter();
            DataSetStatsBib.OLPL_Apps_Stats_BibDataTable tbResults = new DataSetStatsBib.OLPL_Apps_Stats_BibDataTable();
            tbConnection.FillByFilter(tbResults, dd1.dateReport, dd1.iType, dd1.iAudiance);
            if (tbResults.Count > 0)
            {
                DataSetStatsBib.OLPL_Apps_Stats_BibRow row1 = (DataSetStatsBib.OLPL_Apps_Stats_BibRow)tbResults.Rows[0];
                tempData.iType = row1.iType;
                tempData.id = row1.id;
                tempData.iAudiance = row1.iAudiance;
                tempData.statNet = row1.statNet;
                tempData.statAdds = row1.statAdds;
                tempData.statPTotal = row1.statPTotal;
                tempData.dateCreated = row1.dateCreated;
                tempData.dateReport = row1.dateReport;
                tempData.statDeletes = row1.statDeletes;
                tempData.statTotal = row1.statTotal;
                
            }
            else { tempData.id = 0; }
            return tempData;
        }
        public int getPTotal(DataModelStatsBibRecord tempData, DataModelStatsBib dd1)
        {
            Models.StatsBib.DataSetStatsBibTableAdapters.OLPL_Apps_Stats_BibTableAdapter tbConnection = new Models.StatsBib.DataSetStatsBibTableAdapters.OLPL_Apps_Stats_BibTableAdapter();
            DataSetStatsBib.OLPL_Apps_Stats_BibDataTable tbResults = new DataSetStatsBib.OLPL_Apps_Stats_BibDataTable();
            DateTime datePTotal;
            if (dd1.dateReport.Month == 1)
            {
                int year = dd1.dateReport.Year-1;
                datePTotal = DateTime.Parse("12/1/" + year.ToString());

            }
            else
            {
                datePTotal = dd1.dateReport.AddMonths(-1);
            }
            tbConnection.FillByFilter(tbResults, datePTotal, dd1.iType, dd1.iAudiance);
            if (tbResults.Count > 0)
            {
                DataSetStatsBib.OLPL_Apps_Stats_BibRow row1 = (DataSetStatsBib.OLPL_Apps_Stats_BibRow)tbResults.Rows[0];
                return row1.statTotal;
            }
            else { return 0; }
        }
        public DataModelStatsBibRecord setTempData()
        {
            DataModelStatsBibRecord tempData = new DataModelStatsBibRecord(); ;
            tempData.statPTotal = 0;
            tempData.iType = "None";
            tempData.iAudiance = "None";
            tempData.dateReport = DateTime.Now;
            tempData.dateCreated = DateTime.Now;
            tempData.statAdds = 0;
            tempData.statDeletes = 0;
            tempData.statNet = 0;
            tempData.id = 0;
            tempData.statTotal = 0;
            return tempData;
        }
        public void proccessData(DataModelStatsBibRecord tempData)
        {
            Models.StatsBib.DataSetStatsBibTableAdapters.OLPL_Apps_Stats_BibTableAdapter tbConnection = new Models.StatsBib.DataSetStatsBibTableAdapters.OLPL_Apps_Stats_BibTableAdapter();
            if (tempData.id == 0)
            {
                tbConnection.Insert(tempData.dateReport, tempData.dateCreated, tempData.iType, tempData.iAudiance, tempData.statAdds, tempData.statDeletes, tempData.statTotal, tempData.statNet, tempData.statPTotal);
            }
            else
            {
                tbConnection.UpdateQuery(tempData.dateReport, tempData.dateCreated, tempData.iType, tempData.iAudiance, tempData.statAdds, tempData.statDeletes, tempData.statTotal, tempData.statNet, tempData.statPTotal, tempData.id);
            }
        }
    }
}