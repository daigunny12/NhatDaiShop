using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhatDaiShop.Model.Models
{
    public class Page  :  Auditable
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Content { set; get; }
    }
}
