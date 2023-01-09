using System;
using System.Windows;
using Vodovoz.Models;
using Vodovoz.Stores;
using Vodovoz.ViewModels;
using Vodovoz.Services;
using Vodovoz.DbContexts;
using Microsoft.EntityFrameworkCore;
using Vodovoz.Services.Staff;

namespace Vodovoz
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=vodovoz.db";
        private readonly Main _main;
        private readonly StaffStore _staffStore;
        private readonly NavigationStore _navigationStore;
        private readonly VodovozDbContextFactory _vodovozDbContextFactory;

        public App()
        {
            _vodovozDbContextFactory = new VodovozDbContextFactory(CONNECTION_STRING);
            IStaffMemberProvider staffMemberProvider = new DbStaffMemberProvider(_vodovozDbContextFactory);
            IStaffMemberCRU staffMemberCRU = new DbStaffMemberCRU(_vodovozDbContextFactory);
            IStaffConflictValidator staffConflictValidator = new DbStaffConflictValidator(_vodovozDbContextFactory);

            Staff staff = new Staff(staffMemberProvider, staffMemberCRU, staffConflictValidator);
            _main = new Main(staff);
            _staffStore = new StaffStore(_main);
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (ApplicationContext appContext = _vodovozDbContextFactory.CreateDbContext())
            {
                appContext.Database.Migrate();
            }

            _navigationStore.CurrentViewModel = CreateInitialViewModel();

            MainWindow = new MainWindow() 
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private InitialViewModel CreateInitialViewModel()
        {
            return new InitialViewModel(new NavigationService(_navigationStore, CreateStaffListingViewModel),
                                        new NavigationService(_navigationStore, CreateDepartmentsListingViewModel),
                                        new NavigationService(_navigationStore, CreateOrdersListingViewModel),
                                        new NavigationService(_navigationStore, CreateProductsListingViewModel));
        }

        private AddStaffMemberViewModel CreateAddStaffMemberViewModel()
        {
            return new AddStaffMemberViewModel(_staffStore, new NavigationService(_navigationStore, CreateStaffListingViewModel));
        }

        private UpdateStaffMemberViewModel CreateUpdateStaffMemberViewModel()
        {
            return new UpdateStaffMemberViewModel(_staffStore, new NavigationService(_navigationStore, CreateStaffListingViewModel));
        }

        private StaffListingViewModel CreateStaffListingViewModel()
        {
            return StaffListingViewModel.LoadViewModel(_staffStore, new NavigationService(_navigationStore, CreateAddStaffMemberViewModel), new NavigationService(_navigationStore, CreateUpdateStaffMemberViewModel), new NavigationService(_navigationStore, CreateInitialViewModel));
        }

        private DepartmentsListingViewModel CreateDepartmentsListingViewModel()
        {
            return DepartmentsListingViewModel.LoadViewModel();
        }

        private OrdersListingViewModel CreateOrdersListingViewModel()
        {
            return OrdersListingViewModel.LoadViewModel();
        }

        private ProductsListingViewModel CreateProductsListingViewModel()
        {
            return ProductsListingViewModel.LoadViewModel();
        }
    }
}
