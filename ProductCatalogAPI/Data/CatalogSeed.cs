using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public static  class CatalogSeed
    {
        public static void  Seed(CatalogContext catalogContext)
        {
            catalogContext.Database.Migrate();
            if (!catalogContext.CatalogBrands.Any())
            {
                catalogContext.CatalogBrands.AddRange(GetCatalogBrands());
                catalogContext.SaveChanges();
            }
           if  (!catalogContext.CatalogSizes.Any())
            {
                catalogContext.CatalogSizes.AddRange(GetCatalogSize());
                catalogContext.SaveChanges();

            }
           if(!catalogContext.CatalogTypes.Any())
            {
                catalogContext.CatalogTypes.AddRange(GetCatalogType());
                catalogContext.SaveChanges();

            }
           if (!catalogContext.CatalogItems.Any())
            {
                catalogContext.CatalogItems.AddRange(GetCatalogItem());
                catalogContext.SaveChanges();
            }

        }

        private static IEnumerable< CatalogItem> GetCatalogItem()
        {
            return new List<CatalogItem>() {
                 new CatalogItem
                 {
                             Name = "Adidds",
                      Description = "BasketBall Shoes", 
                            Price = 150,
                       PictureUrl = "http://externalcatalogbaseurltoberplaced/api/pic/1",
                      
                    CatalogBrandId =1,
                    CatalogTypeId =1,
                    CatalogSizeId = 3     
                 },
                      new CatalogItem
                 {
                             Name = "Adidds",
                      Description = "walking Shoes",
                            Price = 180,
                       PictureUrl = "http://externalcatalogbaseurltoberplaced/api/pic/2",

                    CatalogBrandId =1,
                    CatalogTypeId =3,
                    CatalogSizeId = 2
                 },
                           new CatalogItem
                 {
                             Name = "NIke",
                      Description = "walking  Shoes",
                            Price = 170,
                       PictureUrl = "http://externalcatalogbaseurltoberplaced/api/pic/6",

                    CatalogBrandId =2,
                    CatalogTypeId =2,
                    CatalogSizeId = 4
                 },
             };
        }

        private static IEnumerable<CatalogType> GetCatalogType()
        {
            return new List<CatalogType>()
            {
                new CatalogType
                {
                     Type = "BasketBall"
                },
                new CatalogType
                {
                    Type = "Runing"
                },
                new CatalogType
                {
                    Type = "Walking"
                }
                 

            };
        }

        private static IEnumerable< CatalogSize> GetCatalogSize()
        {
            return new List<CatalogSize>()
            {
                 new CatalogSize
                 {
                     Size =8
                 },
                 new CatalogSize
                 {
                     Size =9
                 },
                 new CatalogSize
                 {
                    Size = 10
                 },
                 new CatalogSize
                 {
                     Size =12
                 },
                 new CatalogSize
                 {
                     Size =13
                 }
                 
            };
        }

        private static IEnumerable<CatalogBrand> GetCatalogBrands()
        {
            return new List<CatalogBrand>
            {
                new CatalogBrand
                {
                    Brand = "Adidds"
                },
                new CatalogBrand
                {
                    Brand = "Nike"
                },
                new CatalogBrand
                {
                    Brand = "puma"
                }
            };
        }
    }
}
