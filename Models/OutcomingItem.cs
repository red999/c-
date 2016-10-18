using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{
    public class OutcomingItem
    {
        public int ID { get; set; }
        public DateTime date { get; set; }
        public int quantity { get; set; }

        public int ItemCardID { get; set; }
        public int BuyerID { get; set; }

        public virtual ItemCard ItemCard { get; set; }
        public virtual Buyer Buyer { get; set; }
    }
}