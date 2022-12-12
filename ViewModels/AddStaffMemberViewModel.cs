using System;
using System.Windows.Input;
using Vodovoz.Commands;
using Vodovoz.Models;
using Vodovoz.Services;
using Vodovoz.Stores;

namespace Vodovoz.ViewModels
{
    internal class AddStaffMemberViewModel : ViewModelBase
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _surName;
        public string SurName
        {
            get
            {
                return _surName;
            }
            set
            {
                _surName = value;
                OnPropertyChanged(nameof(SurName));
            }
        }

        private DateTime _birthday = new DateTime(2022, 1, 1);
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }

        private Gender _gender;
        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        private int _department;
        public int Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                OnPropertyChanged(nameof(Department));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddStaffMemberViewModel(StaffStore staffStore, NavigationService staffListingViewNavigationService)
        {
            SubmitCommand = new AddStaffMemberCommand(this, staffStore);
            CancelCommand = new NavigateCommand(staffListingViewNavigationService);
        }
    }
}
