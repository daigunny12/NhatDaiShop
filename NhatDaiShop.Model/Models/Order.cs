using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhatDaiShop.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(250)]
        public string CustomerName { set; get; }
        [Required]
        [MaxLength(250)]
        public string CustomerAddress { set; get; }
        [Required]
        [MaxLength(250)]
        public string CustomerEmail { set; get; }
        [Required]
        [MaxLength(50)]
        public string CustomerMobile { set; get; }
        [MaxLength(250)]
        public string CustomerMessage { set; get; }

        public DateTime? CreatedDate { set; get; }

        [MaxLength(50)]
        public string CreatedBy { set; get; }

        [MaxLength(250)]
        public string PaymentMethod { set; get; }

        [Required]
        [MaxLength(50)]
        public string PaymentStatus { set; get; }

        public bool Status { set; get; }

        public virtual IEnumerable<OrderDetail> OrderDetails { set; get; }
    }
}
