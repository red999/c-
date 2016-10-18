using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{
    public class Buyer
    {
        public int ID { get; set; }
        public string firmNameORsellerName { get; set; }
        //National State Registry of Ukrainian Enterprises and Organizations
        //The identification number of an individual
        public string edrpouORidenticCode { get; set; }
        public Sign? Sign { get; set; }

        public virtual ICollection<AddressBuyer> AddressBuyers { get; set; }
        public virtual ICollection<OutcomingItem> OutcomingItems { get; set; }

    }
}