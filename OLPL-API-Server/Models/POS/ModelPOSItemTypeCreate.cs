using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLPL_API_Server.Models.POS
{
    public class ModelPOSItemTypeCreate
    {
        public int transID { get; set; }
        public string itemType { get; set; }
        public int itemQuantity { get; set; }
        public decimal itemPrice { get; set; }
        public string itemID { get; set; }
        public decimal totalPrice { get; set; }
        public string itemTitle { get; set; }
        public string itemAuthor { get; set; }
        public string itemCallNumber { get; set; }
        public string transType { get; set; }
        public string stationType { get; set; }
    }
}