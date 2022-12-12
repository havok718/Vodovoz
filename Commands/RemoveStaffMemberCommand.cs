using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Vodovoz.Models;
using Vodovoz.Stores;
using Vodovoz.ViewModels;

namespace Vodovoz.Commands
{
    internal class RemoveStaffMemberCommand : AsyncCommandBase
    {
        private readonly StaffStore _staffStore;
        private readonly StaffListingViewModel _vm;

        public RemoveStaffMemberCommand(StaffListingViewModel vm, StaffStore staffStore)
        {
            _staffStore = staffStore;
            _vm = vm;

            _vm.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(StaffListingViewModel.SelectedStaffMember))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _vm.SelectedStaffMember != null;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите удалить сотрудника?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    await _staffStore.RemoveStaffMember(_staffStore.StaffMembers.FirstOrDefault(x => x.Id == _vm.SelectedStaffMember.Id));
                    MessageBox.Show("Сотрудник удален", "Выполнено", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка удаления сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
