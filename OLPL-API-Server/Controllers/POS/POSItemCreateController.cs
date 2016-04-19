using OLPL_API_Server.Models.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers.POS
{
    public class POSItemCreateController : ApiController
    {
        public int Post(ModelPOSItemTypeCreate mPOS)
        {
            try
            {
                Models.POS.DataPOSItemTableAdapters.OLPL_Apps_POS_ItemTypeTableAdapter tbConnection = new Models.POS.DataPOSItemTableAdapters.OLPL_Apps_POS_ItemTypeTableAdapter();
                tbConnection.InsertQuery(mPOS.transID, mPOS.itemType, mPOS.itemQuantity, mPOS.itemPrice, mPOS.itemID, mPOS.totalPrice,mPOS.itemTitle,mPOS.itemCallNumber,mPOS.itemAuthor,"0",mPOS.transType, mPOS.stationType);
                return 1;
            }
            catch (Exception) { return 0; }
        }
    }
}
