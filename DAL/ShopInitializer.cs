using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ShopV2.Models;

namespace ShopV2.DAL
{
    public class ShopInitializer : System.Data.Entity.DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            
            var itemCards = new List<ItemCard>
            {
                new ItemCard { name = "milk", measureType = "miligrams", articularNumber = "12a", nomenclatureNumber = "2a", barCode = 123 },
                new ItemCard { name = "bread", measureType = "killo", articularNumber = "13b", nomenclatureNumber = "3b", barCode = 124 },
                new ItemCard { name = "water", measureType = "miligrams", articularNumber = "13b", nomenclatureNumber = "4b", barCode = 125 },
                new ItemCard { name = "watermelon", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 },
                new ItemCard { name = "cats", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 },
                new ItemCard { name = "flowers", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 },
                new ItemCard { name = "chairs", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 },
                new ItemCard { name = "mersedes", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 },
                new ItemCard { name = "aspirin", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 },
                new ItemCard { name = "pillow", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 },
                new ItemCard { name = "sheet", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 },
                new ItemCard { name = "fabric", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 },
                new ItemCard { name = "dolphin", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 },
                new ItemCard { name = "cream", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 },
                new ItemCard { name = "tree", measureType = "grams", articularNumber = "15b", nomenclatureNumber = "5b", barCode = 126 }

            };
            itemCards.ForEach(i => context.ItemCards.Add(i));
            context.SaveChanges();

            var changeItemInfos = new List<ChangeItemInfo>
            {
                new ChangeItemInfo { price = 120, date = DateTime.Parse("2005-09-01"), ItemCardID = 1 },
                new ChangeItemInfo { price = 150, date = DateTime.Parse("2005-09-04"), ItemCardID = 1 },
                new ChangeItemInfo { price = 110, date = DateTime.Parse("2005-09-15"), ItemCardID = 2 },
                new ChangeItemInfo { price = 200, date = DateTime.Parse("2005-09-04"), ItemCardID = 3 },
                new ChangeItemInfo { price = 150, date = DateTime.Parse("2005-09-04"), ItemCardID = 4 },
                new ChangeItemInfo { price = 300, date = DateTime.Parse("2005-09-05"), ItemCardID = 5 },
            };
            changeItemInfos.ForEach(p => context.ChangeItemInfos.Add(p));
            context.SaveChanges();

            var packageTypes = new List<PackageType>
            {
                new PackageType { PackageTypeID = 1, typeName = "bottle"},
                new PackageType { PackageTypeID = 2, typeName = "box"},
                new PackageType { PackageTypeID = 3, typeName = "pack"}
            };
            packageTypes.ForEach(p => context.PackageTypes.Add(p));
            context.SaveChanges();

            var packageInfos = new List<PackageInfo>
            {
                new PackageInfo { ItemCardID = 1, PackageTypeID = 1, count = 10 },
                new PackageInfo { ItemCardID = 2, PackageTypeID = 1, count = 5 },
                new PackageInfo { ItemCardID = 2, PackageTypeID = 2, count = 6},
                new PackageInfo { ItemCardID = 3, PackageTypeID = 1, count = 12},
                new PackageInfo { ItemCardID = 4, PackageTypeID = 3, count = 20}
            };
            packageInfos.ForEach(p => context.PackageInfos.Add(p));
            context.SaveChanges();

            var vendors = new List<Vendor>
            {
                new Vendor { firmNameORsellerName = "Olifirova Natalka Ivanivna", edrpouORidenticCode = "123a", Sign = Sign.legalPerson },
                new Vendor { firmNameORsellerName = "Konotopez Ivanna", edrpouORidenticCode = "555d", Sign = Sign.phisPerson },
                new Vendor { firmNameORsellerName = "KrakenWagen", edrpouORidenticCode = "455a", Sign = Sign.legalPerson }
            };
            vendors.ForEach(v => context.Vendors.Add(v));
            context.SaveChanges();

            
            var countries = new List<Country>
            {
                new Country { name = "Ukraine" },
                new Country { name = "France" },
                new Country { name = "Greece" },
                new Country { name = "Netherlands" }
            };
            countries.ForEach(c => context.Countries.Add(c));
            context.SaveChanges();

            var cities = new List<City>
            {
                new City { name = "Kyiv"},
                new City { name = "San Francisco"}

            };
            cities.ForEach(c => context.Citites.Add(c));
            context.SaveChanges();

            var streets = new List<Street>
            {
                new Street { name = "Dovnar"},
                new Street { name = "Maidan"},
                new Street { name = "Peremohy Avenue"},
                new Street { name = "Oleny Teligy"}
            };
            streets.ForEach(s => context.Streets.Add(s));
            context.SaveChanges();

            var addressinfos = new List<AddressInfo>
            {
                new AddressInfo { homeName = "20b", CountryID = 1, CityID = 1, StreetID = 1 },
                new AddressInfo { homeName = "3b", CountryID = 2, CityID = 1, StreetID = 3 },
                new AddressInfo { homeName = "6e", CountryID = 3, CityID = 2, StreetID = 4 }
            };
            addressinfos.ForEach(a => context.AddressInfos.Add(a));
            context.SaveChanges();

            var addressvendors = new List<AddressVendor>
            {
                new AddressVendor { VendorID = 1, AddressInfoID = 1 },
                new AddressVendor { VendorID = 1, AddressInfoID = 2 },
                new AddressVendor { VendorID = 2, AddressInfoID = 1 },
                new AddressVendor { VendorID = 3, AddressInfoID = 3 }
            };
            addressvendors.ForEach(a => context.AddressVendors.Add(a));
            context.SaveChanges();

            
            var incomingitems = new List<IncomingItem>
            {
                new IncomingItem { ItemCardID = 1, VendorID = 1, date = DateTime.Parse("2005-02-03"), quantity = 20 },
                new IncomingItem { ItemCardID = 1, VendorID = 1, date = DateTime.Parse("2005-02-03"), quantity = 10 },
                new IncomingItem { ItemCardID = 2, VendorID = 1, date = DateTime.Parse("2005-02-03"), quantity = 5 },
                new IncomingItem { ItemCardID = 3, VendorID = 2, date = DateTime.Parse("2005-02-03"), quantity = 10 },
                new IncomingItem { ItemCardID = 4, VendorID = 2, date = DateTime.Parse("2005-02-03"), quantity = 100 }
            };
            incomingitems.ForEach(i => context.IncomingItems.Add(i));
            context.SaveChanges();
         
            var buyers = new List<Buyer>
            {
                new Buyer { firmNameORsellerName = "Neville Co", edrpouORidenticCode = "123a", Sign = Sign.phisPerson },
                new Buyer { firmNameORsellerName = "Trembli", edrpouORidenticCode = "444aw", Sign = Sign.legalPerson }
            };
            buyers.ForEach(b => context.Buyers.Add(b));
            context.SaveChanges();

            var addressbuyers = new List<AddressBuyer>
            {
                new AddressBuyer { AddressInfoID = 1, BuyerID = 1 },
                new AddressBuyer { AddressInfoID = 2, BuyerID = 2 }
            };
            addressbuyers.ForEach(a => context.AddressBuyers.Add(a));
            context.SaveChanges();

            var outcomingitems = new List<OutcomingItem>
            {
                new OutcomingItem { ItemCardID = 1, date = DateTime.Parse("2001-02-04"), quantity = 10, BuyerID = 1 },
                new OutcomingItem { ItemCardID = 1, date = DateTime.Parse("2001-02-04"), quantity = 20, BuyerID = 1 },
                new OutcomingItem { ItemCardID = 2, date = DateTime.Parse("2001-02-04"), quantity = 5, BuyerID = 1 },
                new OutcomingItem { ItemCardID = 3, date = DateTime.Parse("2001-02-04"), quantity = 10, BuyerID = 2 },
                new OutcomingItem { ItemCardID = 4, date = DateTime.Parse("2001-02-04"), quantity = 12, BuyerID = 2 },
            };
            outcomingitems.ForEach(o => context.OutcomingItem.Add(o));
            context.SaveChanges();

            var firms = new List<Firm>
            {
                new Firm { name = "Firm 1", num = "1b" }
            };
            firms.ForEach(f => context.Firms.Add(f));
            context.SaveChanges();

            var waybills = new List<Waybill>
            {
                new Waybill { ItemCardID = 1, ChangeInfoID = 1, FirmID = 1, PackageTypeID = 2, VendorID = 1, date = DateTime.Parse("2002-02-03") }
            };
            waybills.ForEach(w => context.Waybills.Add(w));
            context.SaveChanges();

        }
    }
}