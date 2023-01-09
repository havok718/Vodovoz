using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodovoz.ViewModels
{
    internal class OrdersListingViewModel : ViewModelBase
    {
        public static OrdersListingViewModel LoadViewModel()
        {
            var vm = new OrdersListingViewModel();
            //TODO: LOAD ORDERS
            return vm;
        }
    }
}
