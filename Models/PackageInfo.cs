using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{

    public class PackageInfo
    {
        public int PackageInfoID { get; set; }
        public int? count { get; set; }

        public int PackageTypeID { get; set; }
        public int ItemCardID { get; set; }

        public virtual ItemCard ItemCard { get; set; }
        public virtual PackageType PackageType { get; set; }
    }
}