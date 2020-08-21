using Microsoft.VisualStudio.TestTools.UnitTesting;
using NhatDaiShop.Data.Infrastructure;
using NhatDaiShop.Data.Repositories;
using NhatDaiShop.Model.Models;

namespace NhatDaiShop.UnitTest.RepositoryTest
{
    [TestClass]
    internal class PostCategoryRepositoryTest
    {
        IDBFactory dBFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Inittialize()
        {
            dBFactory = new DBFactory();
            objRepository = new PostCategoryRepository(dBFactory);
            unitOfWork = new UnitOfWork(dBFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test_category";
            category.Status = true;

            var result=  objRepository.Add(category);
            unitOfWork.Commit();

            Assert.IsNotNull( result.ID);
            Assert.AreEqual(1, result.ID);
        }
    }
}