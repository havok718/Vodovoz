using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Vodovoz.Commands;
using Vodovoz.Models;
using Vodovoz.Services;
using Vodovoz.Stores;

namespace Vodovoz.ViewModels
{
    internal class StaffListingViewModel : ViewModelBase
    {
        private ObservableCollection<StaffMemberViewModel> _staffMembers;
        private readonly StaffStore _staffStore;
        private StaffMemberViewModel? _selectedStaffMember;

        public ObservableCollection<StaffMemberViewModel> StaffMembers
        {
            get => _staffMembers;
            set
            {
                _staffMembers = value;
                OnPropertyChanged(nameof(StaffMembers));
            }
        }

        public ICommand AddStaffMemberCommand { get; }
        public ICommand RemoveStaffMemberCommand { get; }
        public ICommand UpdateStaffMemberCommand { get; }
        public ICommand LoadStaffCommand { get; }
        public ICommand BackCommand { get; }

        public StaffMemberViewModel? SelectedStaffMember
        {
            get => _selectedStaffMember;
            set
            {
                _selectedStaffMember = value;

                if (_selectedStaffMember != null)
                {
                    var currentSelected = _staffStore.StaffMembers.Where(x => x.IsSelected == true).FirstOrDefault();
                    
                    if (currentSelected != null)
                    {
                        currentSelected.IsSelected = false;
                    }

                    _staffStore.StaffMembers.Where(_x => _x.Id == _selectedStaffMember.Id).First().IsSelected = true;
                }

                OnPropertyChanged(nameof(SelectedStaffMember));
            }
        }

        public StaffListingViewModel(StaffStore staffStore, NavigationService addStaffMemberViewNavigationService, NavigationService updateStaffMemberNavigationService, NavigationService backNavigationService)
        {
            _staffMembers = new ObservableCollection<StaffMemberViewModel>();
            AddStaffMemberCommand = new NavigateCommand(addStaffMemberViewNavigationService);
            UpdateStaffMemberCommand = new NavigateCommand(updateStaffMemberNavigationService);
            RemoveStaffMemberCommand = new RemoveStaffMemberCommand(this, staffStore);
            LoadStaffCommand = new LoadStaffCommand(staffStore, this);
            BackCommand = new NavigateCommand(backNavigationService);

            _staffStore = staffStore;
            _staffStore.StaffMemberAdded += OnStaffMemberAdded;
            _staffStore.StaffMemberRemoved += OnStaffMemberRemoved;
        }

        private void OnStaffMemberRemoved(StaffMember staffMember)
        {
            var vmToRemove = _staffMembers.Where(x => x.Id == staffMember.Id).FirstOrDefault();
            _staffMembers.Remove(vmToRemove);
            SelectedStaffMember = null;
        }

        private void OnStaffMemberAdded(StaffMember staffMember)
        {
            var staffMemberViewModel = new StaffMemberViewModel(staffMember);
            _staffMembers.Add(staffMemberViewModel);
        }

        public static StaffListingViewModel LoadViewModel(StaffStore staffStore, NavigationService addStaffMemberViewNavigationService, NavigationService editStaffMemberNavigationService, NavigationService backNavigationService)
        {
            var vm = new StaffListingViewModel(staffStore, addStaffMemberViewNavigationService, editStaffMemberNavigationService, backNavigationService);
            vm.LoadStaffCommand.Execute(null);
            return vm;
        }

        public void UpdateStaff(IEnumerable<StaffMember> staffMembers)
        {
            _staffMembers.Clear();

            foreach (var staffMember in staffMembers)
            {
                _staffMembers.Add(new StaffMemberViewModel(staffMember));
            }
        }

        public override void Dispose()
        {
            _staffStore.StaffMemberAdded -= OnStaffMemberAdded;
            _staffStore.StaffMemberRemoved -= OnStaffMemberRemoved;
            base.Dispose();
        }
    }
}
