using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.Models
{
    public class AddressInfo
    {
        public int ID { get; set; }
        public string homeName { get; set; }
        
        public int CountryID { get; set; }
        public int CityID { get; set; }
        public int StreetID { get; set; }

        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public virtual Street Street { get; set; }
        
        public virtual ICollection<AddressVendor> AddressVendors { get; set; }
        public virtual ICollection<AddressBuyer> AddressBuyers { get; set; }

    }
}