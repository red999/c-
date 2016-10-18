using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{
    public class AddressBuyer
    {
        public int ID { get; set; }

        public int AddressInfoID { get; set; }
        public int BuyerID { get; set; }

        public virtual AddressInfo AddressInfo { get; set; }
        public virtual Buyer Buyer { get; set; }

    }
}