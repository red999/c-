using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{
    public class Waybill
    {
        public int ID { get; set; }
        public int number { get; set; }
        public int VendorID { get; set; }
        public virtual Vendor Vendor { get; set; }

        public int FirmID { get; set; }
        public virtual Firm Firm { get; set; }

        public int ItemCardID { get; set; }
        public virtual ItemCard ItemCard { get; set; }

        public int ChangeInfoID { get; set; }
        public ChangeItemInfo ChangeItemInfo { get; set; }

        public DateTime date { get; set; }

        public int PackageTypeID { get; set; }
        public PackageType PackageType { get; set; }
        //(changeiteminfo.price по дате) * (PackageType.amount по дате)
        public int sum { get; set; }

    }
}