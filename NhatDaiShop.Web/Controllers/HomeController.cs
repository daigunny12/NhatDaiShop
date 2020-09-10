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
        public HomeController(IProductCategoryService productCategoryService, ICommonService commonService)
        {
            this._productCategoryService = productCategoryService;
            this._commonService = commonService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
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
