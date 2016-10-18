using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{
    public class IncomingItem
    {
        public int ID { get; set; }
        public DateTime date { get; set; }
        public int quantity { get; set; }

        public int ItemCardID { get; set; }
        public int VendorID { get; set; }

        public virtual ItemCard ItemCard { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}