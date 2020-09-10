using NhatDaiShop.Common;
using NhatDaiShop.Data.Infrastructure;
using NhatDaiShop.Data.Repositories;
using NhatDaiShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhatDaiShop.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
    }
    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private IUnitOfWork _unitOfWork;
        private ISlideRepository _slideRepository;
        public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork, ISlideRepository slideRepository)
        {
            this._footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
            this._slideRepository = slideRepository;
        }
        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x=> x.ID == CommonConstants.DefaultFooterID);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status);
        }
    }
}
