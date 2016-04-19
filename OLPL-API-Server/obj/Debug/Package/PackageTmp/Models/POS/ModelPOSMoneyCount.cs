using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLPL_API_Server.Models.POS
{
    public class ModelPOSMoneyCount
    {
        public string countType { get; set; }
        public string countOperator { get; set; }
        public DateTime dateTrans { get; set; }
        public DateTime dateCount { get; set; }
        public int coinsPennyNumber { get; set; }
        public decimal coinsPennyValue { get; set; }
        public int coinsNickelNumber { get; set; }
        public decimal coinsNickelValue { get; set; }
        public int coinsDimeNumber { get; set; }
        public decimal coinsDimeValue { get; set; }
        public int coinsQuarterNumber { get; set; }
        public decimal coinsQuarterValue { get; set; }
        public int coinsHalfDollarNumber { get; set; }
        public decimal coinsHalfDollarValue { get; set; }
        public int coinsDollarNumber { get; set; }
        public decimal coinsDollarValue { get; set; }
        public int billsDollarNumber { get; set; }
        public decimal billsDollarValue { get; set; }
        public int bills2DollarNumber { get; set; }
        public decimal bills2DollarValue { get; set; }
        public int bills5DollarNumber { get; set; }
        public decimal bills5DollarValue { get; set; }
        public int bills10DollarNumber { get; set; }
        public decimal bills10DollarValue { get; set; }
        public int bills20DollarNumber { get; set; }
        public decimal bills20DollarValue { get; set; }
        public int rollsNickelNumber { get; set; }
        public decimal rollsNickelValue { get; set; }
        public int rollsDimeNumber { get; set; }
        public decimal rollsDimeValue { get; set; }
        public int rollsQuarterNumber { get; set; }
        public decimal rollsQuarterValue { get; set; }
        public decimal totalCounted { get; set; }
        public int checkOverride { get; set; }
    }
}