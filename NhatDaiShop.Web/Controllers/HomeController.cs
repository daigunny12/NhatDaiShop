using AutoMapper;
using NhatDaiShop.Model.Models;
using NhatDaiShop.Service;
using NhatDaiShop.Web.Mappings;
using NhatDaiShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhatDaiShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        ICommonService _commonService;
        IProductService _productService;
        public HomeController(IProductCategoryService productCategoryService, ICommonService commonService, IProductService productService)
        {
            this._productCategoryService = productCategoryService;
            this._commonService = commonService;
            this._productService = productService;
        }

        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlides();
            IMapper mapper = AutoMapperConfiguragtion.Mapper;
            var slideViewModel = mapper.Map<IEnumerable<Slide>,IEnumerable<SlideViewModel>>(slideModel);

            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideViewModel;

            var lastestProductModel = _productService.GetLastest(3);
            var lastestProductViewModel = mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            homeViewModel.LastestProducts = lastestProductViewModel;

            var topsaleProductModel = _productService.GetHotProduct(3);
            var topsaleProductViewModel = mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topsaleProductModel);
            homeViewModel.TopSaleProducts = topsaleProductViewModel;

            return View(homeViewModel);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            IMapper mapper = AutoMapperConfiguragtion.Mapper;
            var footerViewModel = mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
        }


        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            IMapper mapper = AutoMapperConfiguragtion.Mapper;
            var ListProductCategoryViewModel = mapper.Map<IEnumerable<ProductCategory>,IEnumerable<ProductCategoryViewModel> >(model);
            return PartialView(ListProductCategoryViewModel);
        }
    }
}
