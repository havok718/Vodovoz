using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodovoz.ViewModels
{
    internal class ProductsListingViewModel : ViewModelBase
    {
        public static ProductsListingViewModel LoadViewModel()
        {
            var vm = new ProductsListingViewModel();
            //TODO: LOAD PRODUCTS
            return vm;
        }
    }
}
