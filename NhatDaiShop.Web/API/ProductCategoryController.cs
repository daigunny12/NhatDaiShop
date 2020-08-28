using AutoMapper;
using NhatDaiShop.Model.Models;
using NhatDaiShop.Service;
using NhatDaiShop.Web.Infrastructure.Core;
using NhatDaiShop.Web.Mappings;
using NhatDaiShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public HttpResponseMessage Get(HttpRequestMessage request,string  keyword,  int page, int pageSize = 20)
        {
            return createHttpResponse(request, () =>
            {
                int totalRow = 0;
                var ListCategory = _productCategoryService.GetAll(keyword);

                totalRow = ListCategory.Count();

                var query = ListCategory.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                IMapper mapper = AutoMapperConfiguragtion.Mapper;
                var reponseData = mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = reponseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }
    }
}