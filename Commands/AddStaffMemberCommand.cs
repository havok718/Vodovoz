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
    internal class AddStaffMemberCommand : AsyncCommandBase
    {
        private readonly StaffStore _staffStore;
        private readonly AddStaffMemberViewModel _vm;

        public AddStaffMemberCommand(AddStaffMemberViewModel vm, StaffStore staffStore)
        {
            _staffStore = staffStore;
            _vm = vm;

            _vm.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(AddStaffMemberViewModel.LastName):
                    OnCanExecuteChanged();
                    break;
                case nameof(AddStaffMemberViewModel.SurName):
                    OnCanExecuteChanged();
                    break;
                case nameof(AddStaffMemberViewModel.Name):
                    OnCanExecuteChanged();
                    break;
                case nameof(AddStaffMemberViewModel.Gender):
                    OnCanExecuteChanged();
                    break;
                case nameof(AddStaffMemberViewModel.DepartmentName):
                    OnCanExecuteChanged();
                    break;
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_vm.LastName) && 
                !string.IsNullOrEmpty(_vm.SurName) && 
                !string.IsNullOrEmpty(_vm.Name) && 
                _vm.DepartmentName != null && 
                (_vm.Gender == Gender.Male || _vm.Gender == Gender.Female) &&
                base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _staffStore.AddStaffMember(new StaffMember(_vm.Id, _vm.LastName, _vm.SurName, _vm.Name, _vm.Birthday, _vm.Gender, _vm.DepartmentName));
                MessageBox.Show("Сотрудник добавлен", "Выполнено", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (StaffConflictException)
            {
                MessageBox.Show("Сотрудник с таким Id уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка добавления сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
