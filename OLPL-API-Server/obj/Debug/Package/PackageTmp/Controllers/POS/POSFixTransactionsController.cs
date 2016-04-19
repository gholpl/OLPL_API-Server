using OLPL_API_Server.Functions.POS;
using OLPL_API_Server.Models.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers.POS
{
    public class POSFixTransactionsController : ApiController
    {
        public string Get()
        {
            string ret1 = "";
            bool test = true;
            Models.POS.DataPOSTransCreateTableAdapters.OLPL_Apps_POS_TransTableAdapter tbConnection = new Models.POS.DataPOSTransCreateTableAdapters.OLPL_Apps_POS_TransTableAdapter();
            DataPOSTransCreate.OLPL_Apps_POS_TransDataTable tbResults = new DataPOSTransCreate.OLPL_Apps_POS_TransDataTable();
            tbConnection.FillBy(tbResults);
            foreach(Models.POS.DataPOSTransCreate.OLPL_Apps_POS_TransRow row in tbResults)
            {
                if (test)
                {
                    test = true;
                    if (!row.strData.Contains("Operator ID"))
                    {
                        modelPOS mPOS = new modelPOS();
                        mPOS.stationType = "Workstation";
                        #region NonCashManagementTrans
                        string[] stringSeparators = new string[] { "Original bi" };

                        string[] dataStr1 = row.strData.Split(stringSeparators, StringSplitOptions.None);
                        mPOS.transID = row.transID;
                        foreach (string str1 in dataStr1)
                        {
                            if (str1.Contains("Payment date:"))
                            {
                                string[] intStr = str1.Split('|');
                                foreach (string str2 in intStr)
                                {
                                    //MessageBox.Show(str.Replace("Payment date: ", ""));
                                    if (str2.Contains("Payment date:")) { mPOS.paymentDate = DateTime.Parse(str2.Replace("Payment date: ", "")); }
                                }
                            }
                            else
                            {
                                modelPOS mPOS1 = mPOS;
                                mPOS1.transType = "Sale";
                                mPOS1.quantity = 1;
                                bool nextLine = false;
                                bool change = false;
                                bool exceptionData = false;
                                string[] intStr = str1.Split('|');
                                if (row.strData.Contains("Remaining balance:")) { exceptionData = true; }
                                //MessageBox.Show(exceptionData.ToString());
                                foreach (string str2 in intStr)
                                {
                                    if (str2.Contains("ll: $")) { mPOS1.totalBill = Decimal.Parse(str2.Replace("ll: $", "")); }
                                    if (str2.Contains("Author:")) { mPOS1.author = str2.Replace("Author: ", ""); }
                                    if (str2.Contains("Change:")) { mPOS1.change = Decimal.Parse(str2.Replace("Change: $", "")); change = true; }
                                    if (str2.Contains("Call number:")) { mPOS1.callnumber = str2.Replace("Call number: ", ""); }
                                    if (str2.Contains("Title:")) { mPOS1.title = str2.Replace("Title: ", ""); }
                                    if (str2.Contains("Item ID:")) { mPOS1.itemID = str2.Replace("Item ID: ", ""); }
                                    if (nextLine && !String.IsNullOrEmpty(str2) && !exceptionData)
                                    {
                                        string[] intStr1 = str2.Split(' ');
                                        mPOS1.type = intStr1[0];
                                        mPOS1.amtCol = Decimal.Parse(intStr1[1]);
                                        nextLine = false;
                                    }
                                    if (str2.Contains("Payment status:")) { mPOS1.status = str2.Replace("Payment status: ", ""); nextLine = true; }
                                    if (!change) { mPOS1.change = Decimal.Parse("0.00"); }
                                    if (str2.Contains("Bill reason:")) { mPOS1.reason = str2.Replace("Bill reason: ", ""); }
                                    if (str2.Contains("Original tax:")) { mPOS1.tax = Decimal.Parse(str2.Replace("Original tax: $", "")); }
                                    if (exceptionData && str2.Contains("Payment type:")) { mPOS1.type = (str2.Replace("Payment type: ", "")); }
                                    if (exceptionData && str2.Contains("Amount paid:")) { mPOS1.amtCol = Decimal.Parse(str2.Replace("Amount paid: $", "")); }
                                }
                                mPOS1.amtDrawer = mPOS1.amtCol - mPOS1.change;
                                controlPOS.postItemType(mPOS1);
                                controlPOS.postPayment(mPOS1);
                                controlPOS.closeTrans(mPOS);
                            }
                        }
                        #endregion
                    }
                    else
                    {

                    }
                }
                
            }
            return ret1;
        }
    }
}
