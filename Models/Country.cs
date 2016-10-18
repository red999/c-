using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string name { get; set; }

        public virtual ICollection<AddressInfo> AddressInfos { get; set; }
    }
}