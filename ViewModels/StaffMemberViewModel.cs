using System;
using Vodovoz.Models;

namespace Vodovoz.ViewModels
{
    internal class StaffMemberViewModel : ViewModelBase
    {
        private int _id;
        private string _lastName;
        private string _surName;
        private string _name;
        private string _birthday;
        private Gender _gender;
        private string _departmentName;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string SurName
        {
            get => _surName; 
            set
            {
                _surName = value;
                OnPropertyChanged(nameof(SurName));
            }
        }

        public string Name
        {
            get => _name; 
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Birthday
        {
            get => _birthday; 
            set
            {
                _birthday = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }

        public Gender Gender
        {
            get => _gender; 
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public string DepartmentName
        {
            get => _departmentName; 
            set
            {
                _departmentName = value;
                OnPropertyChanged(nameof(DepartmentName));
            }
        }

        public StaffMemberViewModel(StaffMember staffMember)
        {
            Id = staffMember.Id;
            LastName = staffMember.LastName;
            SurName = staffMember.SurName;
            Name = staffMember.Name;
            Birthday = staffMember.Birthday.ToString("d");
            Gender = staffMember.Gender;
            DepartmentName = staffMember.DepartmentName;
        }
    }
}
