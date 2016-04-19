using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OLPL_API_Server.Models.POS;

namespace OLPL_API_Server.Controllers
{
    public class POSTransCompleteController : ApiController
    {
        public int Post(ModelPOSTransComplete mPOS)
        {
            try
            {
                Models.POS.DataPOSTransCreateTableAdapters.OLPL_Apps_POS_TransTableAdapter tbConnection = new Models.POS.DataPOSTransCreateTableAdapters.OLPL_Apps_POS_TransTableAdapter();
                tbConnection.UpdateQuery(DateTime.Now, mPOS.transID);
                return 1;
            }
            catch (Exception) { return 0; }
        }
    }
}
