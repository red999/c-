using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{
    public class AddressVendor
    {
        public int ID { get; set; }

        public int AddressInfoID { get; set; }
        public int VendorID { get; set; }

        public virtual AddressInfo AddressInfo { get; set; }
        public virtual Vendor Vendor { get; set; }

    }
}