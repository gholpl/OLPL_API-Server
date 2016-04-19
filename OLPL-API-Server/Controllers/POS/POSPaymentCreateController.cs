using OLPL_API_Server.Models.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers.POS
{
    public class POSPaymentCreateController : ApiController
    {
        public int Post(ModelPOSPaymentCreate mPOS)
        {
            try
            {
                Models.POS.DataPOSPaymentTableAdapters.OLPL_Apps_POS_PaymentTableAdapter tbConnection = new Models.POS.DataPOSPaymentTableAdapters.OLPL_Apps_POS_PaymentTableAdapter();
                tbConnection.InsertQuery(mPOS.transID,mPOS.paymentType,mPOS.paymentAmount,mPOS.paymentChange,mPOS.paymentTotal,mPOS.paymentDate,mPOS.transType, mPOS.stationType);
                return 1;
            }
            catch (Exception) { return 0; }
        }
    }
}
