using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{
    public class Firm
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string num { get; set; }

        public virtual ICollection<Waybill> Waybills { get; set; }
    }
}