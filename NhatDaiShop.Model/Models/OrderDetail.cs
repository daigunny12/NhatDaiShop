using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhatDaiShop.Model.Models
{
    [Table("OderDetails")]
    public class OrderDetail
    {
        [Key]
        public int OrderID { set; get; }

        [Key]
        public int ProductID { set; get; }

        public int Quantity { set; get; }

        [ForeignKey("ProductID")]
        public virtual ProductCategory ProductCategory { set; get; }

        [ForeignKey("OrderID")]
        public virtual Order Order { set; get; }

    }
}