using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodovoz.ViewModels
{
    internal class DepartmentsListingViewModel : ViewModelBase
    {
        public static DepartmentsListingViewModel LoadViewModel()
        {
            var vm = new DepartmentsListingViewModel();
            //TODO: LOAD DEPARTMENTS
            return vm;
        }
    }
}
