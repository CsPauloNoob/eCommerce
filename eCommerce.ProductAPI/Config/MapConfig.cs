using AutoMapper;
using eCommerce.ProductAPI.Data.ValueObjects;
using eCommerce.ProductAPI.Models;

namespace eCommerce.ProductAPI.Config
{
    public class MapConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });

            return mapConfig;
        }
    }
}
