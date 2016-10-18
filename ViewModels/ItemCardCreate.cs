using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopV2.ViewModels
{
    public class ItemCardCreate
    {
        public string name { get; set; }
        public string measureType { get; set; }
        public string nomenclatureNumber { get; set; }
        public string articularNumber { get; set; }
        public int barCode { get; set; }
        //count of goods
        public int count { get; set; }
        
        public int PackageTypeID { get; set; }

        public float price { get; set; }
        public DateTime date { get; set; }

        public int VendorID { get; set; }
        
    }
}