using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OLPL_API_Server.Models.POS;

namespace OLPL_API_Server.Controllers
{
    public class POSTransCreateController : ApiController
    { 
        public int Get()
        {
            return 1;
        }
        public int Post(Models.POS.ModelPOSTransCreate mPOS)
        {
            Models.POS.DataPOSTransCreateTableAdapters.OLPL_Apps_POS_TransTableAdapter tbConnection = new Models.POS.DataPOSTransCreateTableAdapters.OLPL_Apps_POS_TransTableAdapter();
            DataPOSTransCreate.OLPL_Apps_POS_TransDataTable tbResults = new DataPOSTransCreate.OLPL_Apps_POS_TransDataTable();
            tbConnection.Fill(tbResults);
            int transID = int.Parse(tbResults.Rows[0].ItemArray[0].ToString())+1;

            tbConnection.InsertQuery(transID, mPOS.compName, mPOS.operatorID.ToUpper(), mPOS.userID, DateTime.Now, mPOS.stationType,mPOS.strData);
            return transID;
        }
    }
}
