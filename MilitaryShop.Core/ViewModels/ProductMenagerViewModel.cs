using MilitaryShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryShop.Core.ViewModels
{
    public class ProductMenagerViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<ProductCategory> productCategories { get; set; }
    }
}
