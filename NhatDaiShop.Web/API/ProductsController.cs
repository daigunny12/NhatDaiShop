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
    [RoutePrefix("api/products")]
    public class ProductsController: ApiControllerBase
    {
        private IProductService _productService;

        public ProductsController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return createHttpResponse(request, () =>
            {
                int totalRow = 0;
                var List = _productService.GetAll(keyword);

                totalRow = List.Count();

                var query = List.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                IMapper mapper = AutoMapperConfiguragtion.Mapper;
                var reponseData = mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query);

                var paginationSet = new PaginationSet<ProductViewModel>()
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


        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return createHttpResponse(request, () =>
            {
                var List = _productService.GetById(id);

                IMapper mapper = AutoMapperConfiguragtion.Mapper;
                var reponseData = mapper.Map<Product, ProductViewModel>(List);
                var response = request.CreateResponse(HttpStatusCode.OK, reponseData);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productViewModel)
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
                    var newProduct = new Product();
                    newProduct.UpdateProduct(productViewModel);
                    newProduct.CreatedDate = DateTime.Now;
                    _productService.Add(newProduct);
                    _productService.Save();

                    IMapper mapper = AutoMapperConfiguragtion.Mapper;
                    var reponseData = mapper.Map<Product, ProductViewModel>(newProduct);

                    response = request.CreateResponse(HttpStatusCode.OK, reponseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productViewModel)
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
                    var dbProduct = _productService.GetById(productViewModel.ID);
                    dbProduct.UpdateProduct(productViewModel);
                    dbProduct.UpdatedDate = DateTime.Now;
                    _productService.Add(dbProduct);
                    _productService.Save();

                    IMapper mapper = AutoMapperConfiguragtion.Mapper;
                    var reponseData = mapper.Map<Product, ProductViewModel>(dbProduct);

                    response = request.CreateResponse(HttpStatusCode.Created, reponseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
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
                    var oldProduct = _productService.Delete(id);
                    _productService.Save();

                    IMapper mapper = AutoMapperConfiguragtion.Mapper;
                    var reponseData = mapper.Map<Product, ProductViewModel>(oldProduct);

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
                    var listProduct = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);

                    foreach (var item in listProduct)
                    {
                        _productService.Delete(item);
                    }
                    _productService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listProduct.Count);
                }
                return response;
            });
        }
    }
}