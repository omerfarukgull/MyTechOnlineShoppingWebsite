using Microsoft.EntityFrameworkCore;
using MyTechEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyTechData.Concrete.Ef
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            //var context = new TechContext();

            //if (context.Database.GetPendingMigrations().Count() == 0)
            //{
            //    if (context.Categories.Count() == 0)
            //    {
            //        context.Categories.AddRange(

            //            new List<Category>()
            //            {
            //                new Category(){CategoryName="Masaüstü Bilgisayar"},
            //                new Category(){CategoryName="Laptop"},
            //                new Category(){CategoryName="Telefon"},
            //                new Category(){CategoryName="Akıllı Saat"},
            //                new Category(){CategoryName="Monitör"},
            //                new Category(){CategoryName="Ekran kartı"},
            //            }
            //        );
            //    }
            //    if (context.Products.Count() == 0)
            //    {
            //        context.Products.AddRange(
            //            new List<Product>()
            //            {
            //                new Product(){ProductName="MSI MAG INFINITE",ProductTitle="MSI MAG INFINITE",ProductDescription="MSI MAG INFINITE",ImgUrl1="msi-mag-infinite-s3.jpg",IsHome=true,IsApproved=true,ProductPrice=62100,CategoryId=1 },
            //                new Product(){ProductName="AORUS MODEL S",ProductTitle="AORUS MODEL S",ProductDescription="AORUS MODEL S",ImgUrl1="aorus-model-s.jpg",IsHome=true,IsApproved=true,ProductPrice=53000,CategoryId=1 },
            //                new Product(){ProductName="MSI MPG TRIDENT",ProductTitle="MSI MPG TRIDENT",ProductDescription="MSI MPG TRIDENT",ImgUrl1="msi-mpg-trident-as.jpg",IsHome=true,IsApproved=true,ProductPrice=400000,CategoryId=1 },
            //                new Product(){ProductName="MSI THIN GF63",ProductTitle="MSI THIN GF63 12UCX-427XTR i5-12450H 8GB DDR4 RTX2050 GDDR6 4GB 512GB SSD 15.6 FHD 144Hz FreeDos Notebook",ProductDescription="THIN GF63 12UCX-427XTR",ImgUrl1="msithingf63.jpg",IsHome=true,IsApproved=true,ProductPrice=220000,CategoryId=2 },
            //                new Product(){ProductName="Lenovo IdeaPad Gaming 3 ",ProductTitle="Lenovo IdeaPad Gaming 3 16ARH7 Ryzen 7 6800H 16GB DDR5 RTX 3050 Ti 4GB GDDR6 512GB SSD 16\" WUXGA 165Hz FreeDos Notebook",ProductDescription="Lenovo IdeaPad Gaming 3 ",ImgUrl1="lenovo-ideapad-gaming.jpg",IsHome=true,IsApproved=true,ProductPrice=25500,CategoryId=2},
            //                new Product(){ProductName="MacBook Pro",ProductTitle="MacBook Pro MNEH3TU/A M2 8Gb-256Gb Ssd-Retina-13.3inc-Uzay Grisi",ProductDescription="MacBook Pro ",ImgUrl1="macpro.jpg",IsHome=true,IsApproved=true ,ProductPrice=350000,CategoryId=2, },
            //                new Product(){ProductName="iPhone 11",ProductTitle="iPhone 11 64 Gb Siyah",ProductDescription="iPhone 11",ImgUrl1="iphone-11.jpg",IsHome=true,IsApproved=true,ProductPrice=18800,CategoryId=3 },
            //                new Product(){ProductName="iPhone 13",ProductTitle="iPhone 13 128 Gb Akıllı Telefon Mavi",ProductDescription="iPhone 13",ImgUrl1="iphone-13.jpg",IsHome=true,IsApproved=true,ProductPrice=300000,CategoryId=3 },
            //                new Product(){ProductName="iPhone 14 Pro",ProductTitle="iPhone 14 Pro 128 Gb Akıllı Telefon Derin Mor",ProductDescription="iPhone 14 Pro",ImgUrl1="iphone-14.jpg",IsHome=true,IsApproved=true,ProductPrice=46000,CategoryId=3 },
            //                new Product(){ProductName="Samsung Galaxy A04s",ProductTitle="Samsung Galaxy A04s 128 Gb Akıllı Telefon Si̇yah",ProductDescription="Samsung Galaxy A04s",ImgUrl1="samsung-galaxy-a04s.jpg",IsHome=true,IsApproved=true,ProductPrice=5300,CategoryId=3 },
            //                new Product(){ProductName="Samsung Galaxy S22",ProductTitle="128 Gb Akıllı Telefon Fantom Si̇yah",ProductDescription="Samsung Galaxy S22",ImgUrl1="samsung-galaxy-s22.jpg",IsHome=true,IsApproved=true,ProductPrice=18500,CategoryId=3 },
            //                new Product(){ProductName="Samsung Galaxy S22 Ultra",ProductTitle="Samsung Galaxy S22 Ultra 256 Gb Akıllı Telefon Fantom Si̇yah",ProductDescription="Samsung Galaxy S22 Ultra",IsHome=true,IsApproved=true,ImgUrl1="samsung-galaxy-s22-ultra.jpg",ProductPrice=34000,CategoryId=3 },
            //                new Product(){ProductName="HUAWEI Watch",ProductTitle="HUAWEI Watch GT3 Pro 46mm Titanyum Kasa Siyah Kauçuk Kayış Akıllı Saat",ProductDescription="HUAWEI Watch",ImgUrl1="huaweı-watch-gt3-pro.jpg",IsHome=true,IsApproved=true,ProductPrice=6500,CategoryId=4 },
            //                new Product(){ProductName="APPLE Watch Series 8",ProductTitle="APPLE Watch Series 8 GPS 45mm Midnight Aluminium Case with Midnight Sport Band",ProductDescription="APPLE Watch Series 8",ImgUrl1="apple-watch-series-8.jpg",IsHome=true,IsApproved=true,ProductPrice=10800,CategoryId=4 },
            //                new Product(){ProductName="GIGABYTE GeForce RTX 4070 ",ProductTitle="GIGABYTE GeForce RTX 4070 EAGLE OC 12GB GDDR6X DLSS 3 192 Bit Ekran Kartı",ProductDescription="GIGABYTE GeForce RTX 4070 ",ImgUrl1="gigabyte-geforce-rtx-4070.jpg",IsHome=true,IsApproved=true,ProductPrice=27000,CategoryId=6 },
            //                new Product(){ProductName="ASUS TUF GAMING",ProductTitle="ASUS TUF GAMING GeForce RTX 3060Ti 8GB GDDR6X 256 Bit Ekran Kartı",ProductDescription="ASUS TUF GAMING",ImgUrl1="asus-tuf-gaming-geforce-rtx-3060ti.jpg",IsHome=false,IsApproved=false,ProductPrice=16575,CategoryId=6 },
            //            });
            //    }
            //    if (context.Reviews.Count() == 0)
            //    {
            //        context.Reviews.AddRange
            //            (
            //                new List<Review>()
            //                {
            //                    new Review(){Name="Nuri Gül",Email="nurigul@gmail.com",Comment="Harika Bir Ürün",ReviewCreateDate=new DateTime(2023,05,20),ProductId=1},
            //                    new Review(){Name="Emine Kızıl",Email="emine@gmail.com",Comment="Garanti süresi ne kadar ?",ReviewCreateDate=new DateTime(2023,05,20),ProductId=1},
            //                    new Review(){Name="Barış Bayrak",Email="bayrak@gmail.com",Comment="Umarım indirime girer",ReviewCreateDate=new DateTime(2023,05,20),ProductId=1},
            //                    new Review(){Name="Enes Bağcı",Email="enesbagci@gmail.com",Comment="Fiyat Performans bir ürün",ReviewCreateDate=new DateTime(2023,05,20),ProductId=2},
            //                    new Review(){Name="Nihat Atak",Email="atak@gmail.com",Comment="Asus Harika",ReviewCreateDate=new DateTime(2023,05,20),ProductId=2},
            //                }
            //            );
            //    }

            //}
            //context.SaveChanges();
        }
    }
}
