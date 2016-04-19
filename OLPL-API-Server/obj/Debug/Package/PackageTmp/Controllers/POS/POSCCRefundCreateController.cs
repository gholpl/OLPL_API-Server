using OLPL_API_Server.Models.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers.POS
{
    public class POSCCRefundCreateController : ApiController
    {
        public int Post(ModelPOSCCRefund mPOS)
        {
            try
            {
                Models.POS.DataPOSCCRefundTableAdapters.OLPL_Apps_POS_CCRefundTableAdapter tbConnection = new Models.POS.DataPOSCCRefundTableAdapters.OLPL_Apps_POS_CCRefundTableAdapter();
                tbConnection.InsertQuery(mPOS.transID,mPOS.cc4digits, mPOS.contactPreference,mPOS.contactInfo,mPOS.note,mPOS.recieptNumber,mPOS.stationType);
                return 1;
            }
            catch (Exception) { return 0; }
        }
    }
}
