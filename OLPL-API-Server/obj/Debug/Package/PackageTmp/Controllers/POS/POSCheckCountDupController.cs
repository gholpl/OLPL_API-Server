using OLPL_API_Server.Models.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers.POS
{
    public class POSCheckCountDupController : ApiController
    {
        public bool Post(ModelPOSCheckCount mPOS)
        {
            Models.POS.DataPOSCheckCountTableAdapters.OLPL_Apps_POS_CheckCountTableAdapter tbConnection = new Models.POS.DataPOSCheckCountTableAdapters.OLPL_Apps_POS_CheckCountTableAdapter();
            Models.POS.DataPOSCheckCount.OLPL_Apps_POS_CheckCountDataTable dt = new Models.POS.DataPOSCheckCount.OLPL_Apps_POS_CheckCountDataTable();
            tbConnection.FillBy(dt,mPOS.checkNumber,mPOS.checkAmount,mPOS.dateTrans,mPOS.countType);
            if (dt.Count > 0) { return false; }
            else { return true; }
        }
    }
}
