using AutoMapper;
using NhatDaiShop.Model.Models;
using NhatDaiShop.Service;
using NhatDaiShop.Web.Infrastructure.Core;
using NhatDaiShop.Web.Infrastructure.Extentions;
using NhatDaiShop.Web.Mappings;
using NhatDaiShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NhatDaiShop.Web.API
{
    [RoutePrefix("api/productcategory")]
    [Authorize]
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }


        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
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

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponse(request, () =>
            {
                var ListCategory = _productCategoryService.GetAll();

                IMapper mapper = AutoMapperConfiguragtion.Mapper;
                var reponseData = mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(ListCategory);
                var response = request.CreateResponse(HttpStatusCode.OK, reponseData);

                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return createHttpResponse(request, () =>
            {
                var ListCategory = _productCategoryService.GetById(id);

                IMapper mapper = AutoMapperConfiguragtion.Mapper;
                var reponseData = mapper.Map<ProductCategory, ProductCategoryViewModel>(ListCategory);
                var response = request.CreateResponse(HttpStatusCode.OK, reponseData);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {
            return createHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProductCategory = new ProductCategory();
                    newProductCategory.UpdateProductCategory(productCategoryViewModel);
                    newProductCategory.CreatedDate = DateTime.Now;
                    _productCategoryService.Add(newProductCategory);
                    _productCategoryService.Save();

                    IMapper mapper = AutoMapperConfiguragtion.Mapper;
                    var reponseData = mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);

                    response = request.CreateResponse(HttpStatusCode.OK, reponseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {
            return createHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProductCategory = _productCategoryService.GetById(productCategoryViewModel.ID);
                    dbProductCategory.UpdateProductCategory(productCategoryViewModel);
                    dbProductCategory.UpdatedDate = DateTime.Now;
                    _productCategoryService.Update(dbProductCategory);
                    _productCategoryService.Save();

                    IMapper mapper = AutoMapperConfiguragtion.Mapper;
                    var reponseData = mapper.Map<ProductCategory, ProductCategoryViewModel>(dbProductCategory);

                    response = request.CreateResponse(HttpStatusCode.Created, reponseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request,int  id)
        {
            return createHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProductCategory = _productCategoryService.Delete(id);          
                    _productCategoryService.Save();

                    IMapper mapper = AutoMapperConfiguragtion.Mapper;
                    var reponseData = mapper.Map<ProductCategory, ProductCategoryViewModel>(oldProductCategory);

                    response = request.CreateResponse(HttpStatusCode.OK, reponseData);
                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Deletemulti(HttpRequestMessage request, string checkedProductCategories)
        {
            return createHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);

                    foreach(var item in listProductCategory)
                    {
                        _productCategoryService.Delete(item);
                    }
                    _productCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
                }
                return response;
            });
        }
    }
}