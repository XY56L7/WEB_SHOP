using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WEB_SHOP_API.Data;
using WEB_SHOP_API.Entities;

namespace Repository.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory) 
        {
            try 
            {
                if (!context.ProductBrands.Any()) 
                {
                    var brandsData = File.ReadAllText("C:\\Users\\Martin\\Desktop\\Projektek\\WEB_SHOP\\WEB_SHOP_BACKEND\\WEB_SHOP_Repository\\Data\\SeedData\\ProductBrand.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands) 
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var typeData = File.ReadAllText("C:\\Users\\Martin\\Desktop\\Projektek\\WEB_SHOP\\WEB_SHOP_BACKEND\\WEB_SHOP_Repository\\Data\\SeedData\\ProductType.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("C:\\Users\\Martin\\Desktop\\Projektek\\WEB_SHOP\\WEB_SHOP_BACKEND\\WEB_SHOP_Repository\\Data\\SeedData\\Product.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }catch (Exception ex) 
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
