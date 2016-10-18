using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{
    public class ChangeItemInfo
    {
        public int ID { get; set; }
        public float? price { get; set; }
        public DateTime date { get; set; }

        public int? ItemCardID { get; set; }

        public virtual ItemCard ItemCard { get; set; }

        public virtual ICollection<Waybill> Waybills { get; set; }
    }
}