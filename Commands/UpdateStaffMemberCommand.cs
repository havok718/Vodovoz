using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using Vodovoz.Exceptions;
using Vodovoz.Models;
using Vodovoz.Stores;
using Vodovoz.ViewModels;

namespace Vodovoz.Commands
{
    internal class UpdateStaffMemberCommand : AsyncCommandBase
    {
        private readonly StaffStore _staffStore;
        private readonly UpdateStaffMemberViewModel _vm;

        public UpdateStaffMemberCommand(UpdateStaffMemberViewModel vm, StaffStore staffStore)
        {
            _vm = vm;
            _staffStore = staffStore;

            _vm.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(UpdateStaffMemberViewModel.LastName):
                    OnCanExecuteChanged();
                    break;
                case nameof(UpdateStaffMemberViewModel.SurName):
                    OnCanExecuteChanged();
                    break;
                case nameof(UpdateStaffMemberViewModel.Name):
                    OnCanExecuteChanged();
                    break;
                case nameof(UpdateStaffMemberViewModel.Gender):
                    OnCanExecuteChanged();
                    break;
                case nameof(UpdateStaffMemberViewModel.Department):
                    OnCanExecuteChanged();
                    break;
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_vm.LastName) &&
                !string.IsNullOrEmpty(_vm.SurName) &&
                !string.IsNullOrEmpty(_vm.Name) &&
                _vm.Department != null &&
                (_vm.Gender == Gender.Male || _vm.Gender == Gender.Female) &&
                base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _staffStore.EditStaffMember(new StaffMember(_vm.Id, _vm.LastName, _vm.SurName, _vm.Name, _vm.Birthday, _vm.Gender, _vm.Department));
                MessageBox.Show("Сотрудник изменен", "Выполнено", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (StaffConflictException)
            {
                MessageBox.Show("Сотрудник с таким Id уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка добавления сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
