using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLPL_API_Server.Models.POS
{
    class modelPOS
    {
        internal string operatorID { get; set; }
        internal string userID { get; set; }
        internal string title { get; set; }
        internal string itemID { get; set; }
        internal DateTime paymentDate { get; set; }
        internal Decimal totalBill { get; set; }
        internal string author { get; set; }
        internal string callnumber { get; set; }
        internal string status { get; set; }
        internal string type { get; set; }
        internal Decimal amtCol { get; set; }
        internal string reason { get; set; }
        internal Decimal tax { get; set; }
        internal Decimal change { get; set; }
        internal Decimal amtDrawer { get; set; }
        internal string transType { get; set; }
        internal int quantity { get; set; }
        internal int transID { get; set; }
        internal string stationType { get; set; }
        internal string strData { get; set; }
    }
}
