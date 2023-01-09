using System.CodeDom;
using System.Windows.Input;
using Vodovoz.Commands;
using Vodovoz.Services;

namespace Vodovoz.ViewModels
{
    internal class InitialViewModel : ViewModelBase
    {
        public ICommand ProductsCommand { get; set; }
        public ICommand StaffCommand { get; set; }
        public ICommand DepartmentsCommand { get; set; }
        public ICommand OrdersCommand { get; set; }

        public InitialViewModel(NavigationService staffNavigationService, NavigationService departmentsNavigationService, NavigationService ordersNavigationService, NavigationService productsNavigationService)
        {
            StaffCommand = new NavigateCommand(staffNavigationService);
            DepartmentsCommand = new NavigateCommand(departmentsNavigationService);
            OrdersCommand= new NavigateCommand(ordersNavigationService);
            ProductsCommand = new NavigateCommand(productsNavigationService);
        }
    }
}
