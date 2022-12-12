using System;
using System.Threading.Tasks;
using System.Windows;
using Vodovoz.Stores;
using Vodovoz.ViewModels;

namespace Vodovoz.Commands
{
    internal class LoadStaffCommand : AsyncCommandBase
    {
        private readonly StaffStore _staffStore;
        private readonly StaffListingViewModel _staffListingViewModel;

        public LoadStaffCommand(StaffStore staffStore, StaffListingViewModel staffListingViewModel)
        {
            _staffStore = staffStore;
            _staffListingViewModel = staffListingViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _staffStore.Load();
                _staffListingViewModel.UpdateStaff(_staffStore.StaffMembers);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка загрузки сотрудников", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
