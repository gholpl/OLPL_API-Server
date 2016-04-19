using OLPL_API_Server.Models.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers.POS
{
    public class POSCheckCountCreateController : ApiController
    {
        public string Post(ModelPOSCheckCount mPOS)
        {
            try
            {

                Models.POS.DataPOSCheckCountTableAdapters.OLPL_Apps_POS_CheckCountTableAdapter tbConnection = new Models.POS.DataPOSCheckCountTableAdapters.OLPL_Apps_POS_CheckCountTableAdapter();
                tbConnection.InsertQuery(mPOS.checkNumber,mPOS.checkAmount,mPOS.countOperator,DateTime.Now,mPOS.dateTrans,mPOS.countType);
                return "OK";
            }
            catch (Exception e) { return e.ToString(); }
        }
    }
}
