using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{
    public class ItemCard
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string measureType { get; set; }
        public string nomenclatureNumber { get; set; }
        public string articularNumber { get; set; } 
        public int barCode { get; set; }

        public virtual ICollection<PackageInfo> PackageInfos { get; set; }
        public virtual ICollection<ChangeItemInfo> ChangeItemInfos { get; set; }
        public virtual ICollection<IncomingItem> IncomingItems { get; set; }
        public virtual ICollection<OutcomingItem> OutcomingItems { get; set; }

        public virtual ICollection<Waybill> Waybills { get; set; }
    }
}