using OLPL_API_Server.Models.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers.POS
{
    public class POSMoneyCountCreateController : ApiController
    {
       
        public string Post(ModelPOSMoneyCount mPOS)
        {
            try
            {
                
                    Models.POS.DataSet1TableAdapters.OLPL_Apps_POS_MoneyCountTableAdapter tbConnection = new Models.POS.DataSet1TableAdapters.OLPL_Apps_POS_MoneyCountTableAdapter();
                    tbConnection.InsertQuery(mPOS.countType, mPOS.countOperator, mPOS.dateTrans, DateTime.Now, mPOS.coinsPennyNumber, mPOS.coinsPennyValue, mPOS.coinsNickelNumber,
                        mPOS.coinsNickelValue, mPOS.coinsDimeNumber, mPOS.coinsDimeValue, mPOS.coinsQuarterNumber, mPOS.coinsQuarterValue, mPOS.coinsHalfDollarNumber, mPOS.coinsHalfDollarValue,
                        mPOS.coinsDollarNumber, mPOS.coinsDollarValue, mPOS.billsDollarNumber, mPOS.billsDollarValue, mPOS.bills2DollarNumber, mPOS.bills2DollarValue, mPOS.bills5DollarNumber, mPOS.bills5DollarValue,
                        mPOS.bills10DollarNumber, mPOS.bills10DollarValue, mPOS.bills20DollarNumber, mPOS.bills20DollarValue, mPOS.rollsNickelNumber, mPOS.rollsNickelValue, mPOS.rollsDimeNumber,
                        mPOS.rollsDimeValue, mPOS.rollsQuarterNumber, mPOS.rollsQuarterValue, mPOS.totalCounted);
                
                
                return "OK";
            }
            catch (Exception e) { return e.ToString(); }
        }
    }
}
