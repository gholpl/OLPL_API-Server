using OLPL_API_Server.Models.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers.POS
{
    public class POSMoneyCountDupController : ApiController
    {
        public int Post(ModelPOSMoneyCountDup mPOS)
        {
            Models.POS.DataSet1TableAdapters.OLPL_Apps_POS_MoneyCountTableAdapter tbConnection = new Models.POS.DataSet1TableAdapters.OLPL_Apps_POS_MoneyCountTableAdapter();
            Models.POS.DataSet1.OLPL_Apps_POS_MoneyCountDataTable dt = new DataSet1.OLPL_Apps_POS_MoneyCountDataTable();
            tbConnection.FillByDuplicate(dt, mPOS.countType, mPOS.dateTrans);
            if (dt.Count > 0) { return 1; }
            else { return 0; }
        }
    }
}
