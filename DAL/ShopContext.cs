using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ShopV2.Models;

namespace ShopV2.DAL
{
    public class ShopContext : DbContext
    {

        public ShopContext() : base("ShopContext")
        {
        }

        public DbSet<ItemCard> ItemCards { get; set; }
        public DbSet<PackageInfo> PackageInfos { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<ChangeItemInfo> ChangeItemInfos { get; set; }
        public DbSet<IncomingItem> IncomingItems { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<AddressVendor> AddressVendors { get; set; }
        public DbSet<AddressInfo> AddressInfos { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<City> Citites { get; set; }
        public DbSet<OutcomingItem> OutcomingItem { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<AddressBuyer> AddressBuyers { get; set; }
        public DbSet<Firm> Firms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ShopV2.Models.Waybill> Waybills { get; set; }
    }
}