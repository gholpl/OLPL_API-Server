using OLPL_API_Server.Models.POS;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;

namespace OLPL_API_Server.Functions.POS
{
    public class controlPOS
    {
        internal static void postItemType(modelPOS mPOS)
        {
            string result = "";
            try
            {
                if (mPOS.reason.Length > 2)
                {

                            using (WebClient client = new WebClient { UseDefaultCredentials = true })
                            {

                                byte[] response = client.UploadValues("http://api.olpl.org/api/positemcreate", new NameValueCollection()
                        {
                            { "transID", mPOS.transID.ToString() },
                            { "itemType", mPOS.reason },
                            { "itemQuantity", mPOS.quantity.ToString() },
                            { "itemPrice", mPOS.amtCol.ToString() },
                            { "itemID", mPOS.itemID },
                            { "totalPrice", mPOS.totalBill.ToString() },
                            { "itemTitle", mPOS.title },
                            { "itemAuthor", mPOS.author },
                            { "itemCallNumber", mPOS.callnumber },
                            { "transType", mPOS.transType },
                            { "stationType", mPOS.stationType }
                        });

                        result = System.Text.Encoding.UTF8.GetString(response);
                    }
                }
            }
            catch (Exception e1) {  }
            //return int.Parse(result);
        }
        internal static void postPayment( modelPOS mPOS)
        {
            string result = "";
            try
            {
                if (mPOS.type.Length > 2)
                {
                    using (WebClient client = new WebClient { UseDefaultCredentials = true })
                    {

                        byte[] response = client.UploadValues("http://api.olpl.org/api/pospaymentcreate", new NameValueCollection()
                {
                    { "transID", mPOS.transID.ToString() },
                    { "paymentType", mPOS.type },
                    { "paymentAmount", mPOS.amtCol.ToString() },
                    { "paymentChange", mPOS.change.ToString() },
                    { "paymentTotal", mPOS.amtDrawer.ToString() },
                    { "paymentDate", mPOS.paymentDate.ToString() },
                    { "transType", mPOS.transType },
                    { "stationType", mPOS.stationType }

                });

                        result = System.Text.Encoding.UTF8.GetString(response);
                    }
                }
            }

            catch (Exception e1) {  }
            //return int.Parse(result);
        }
        internal static void closeTrans(modelPOS mPOS)
        {
            string result = "";
            try
            {

                using (WebClient client = new WebClient { UseDefaultCredentials = true })
                {

                    byte[] response = client.UploadValues("http://api.olpl.org/api/postranscomplete", new NameValueCollection()
                {
                    { "transID", mPOS.transID.ToString() }
                });

                    result = System.Text.Encoding.UTF8.GetString(response);
                }
            }
            catch (Exception e1) {  }
            //return int.Parse(result);
        }
    }
}