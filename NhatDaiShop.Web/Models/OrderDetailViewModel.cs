namespace NhatDaiShop.Web.Models
{
    public class OrderDetailViewModel
    {
        public int OrderID { set; get; }

        public int ProductID { set; get; }

        public int Quantity { set; get; }

        public virtual ProductCategoryViewModel ProductCategory { set; get; }

        public virtual OrderViewModel Order { set; get; }
    }
}