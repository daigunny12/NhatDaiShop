using AutoMapper;
using NhatDaiShop.Model.Models;
using NhatDaiShop.Service;
using NhatDaiShop.Web.Infrastructure.Core;
using NhatDaiShop.Web.Mappings;
using NhatDaiShop.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NhatDaiShop.Web.Infrastructure.Extentions;

namespace NhatDaiShop.Web.API
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponse(request, () =>
            {
                var ListCategory = _productCategoryService.GetAll();

                IMapper mapper = AutoMapperConfiguragtion.Mapper;
                var ListProductCategoryVm = mapper.Map<List<ProductCategoryViewModel>>(ListCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, ListProductCategoryVm);
                return response;
            });
        }

    }
}