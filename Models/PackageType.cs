using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopV2.Models
{
    public class PackageType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageTypeID { get; set; }

        public string typeName { get; set; }

        public virtual ICollection<PackageInfo> PackageInfos { get; set; }

        public virtual ICollection<Waybill> Waybills { get; set; }

    }
}