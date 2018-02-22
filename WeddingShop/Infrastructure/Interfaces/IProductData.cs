using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingShop.Models;

namespace WeddingShop.Infrastructure.Interfaces
{
    public interface IProductData
    {
        IEnumerable<ProductViewModel> Products { get; set; }

        /// <summary>
        /// Gets list of Products, filtered by specified Type
        /// </summary>
        /// <param name="type"></param>
        /// <returns>List of Pruducts</returns>
        IEnumerable<ProductViewModel> GetProductsByType(string type);

        /// <summary>
        /// Gets list with 3 random Products of specified Type
        /// </summary>
        /// <param name="type"></param>
        /// <returns>list of 3 random Products of specified type</returns>
        IEnumerable<ProductViewModel> GetThreeRandomProducts(string type = "");
    }
}
