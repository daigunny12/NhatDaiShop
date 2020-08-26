using AutoMapper;
using NhatDaiShop.Model.Models;
using NhatDaiShop.Web.Models;

namespace NhatDaiShop.Web.Mappings
{
    public class AutoMapperConfiguragtion
    {
        public static IMapper Mapper;
        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostTag, PostTagViewModel>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<OrderDetail, OrderDetailViewModel>();
            });
            Mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }

    }
}