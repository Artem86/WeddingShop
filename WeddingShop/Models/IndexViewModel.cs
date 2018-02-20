using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingShop.Models
{
    public class IndexViewModel
    {
        //Properties with listS of products, divided by type
        public IEnumerable<ProductViewModel> WeddingsList { get; set; }
        public IEnumerable<ProductViewModel> KidsList { get; set; }
        public IEnumerable<ProductViewModel> AccessoriesList { get; set; }
    }
}
