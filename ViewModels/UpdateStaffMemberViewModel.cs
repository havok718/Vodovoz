using System;
using System.Linq;
using System.Windows.Input;
using Vodovoz.Commands;
using Vodovoz.Models;
using Vodovoz.Services;
using Vodovoz.Stores;

namespace Vodovoz.ViewModels
{
    internal class UpdateStaffMemberViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public int Department { get; set; }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public UpdateStaffMemberViewModel(StaffStore staffStore, NavigationService navigationService)
        {
            var selectedStaffMember = staffStore.StaffMembers.Where(x => x.IsSelected).FirstOrDefault();

            Id = selectedStaffMember.Id;
            LastName = selectedStaffMember.LastName;
            Name = selectedStaffMember.Name;
            Gender = selectedStaffMember.Gender;
            Birthday = selectedStaffMember.Birthday;
            SurName = selectedStaffMember.SurName;
            Department = selectedStaffMember.Department;

            SubmitCommand = new UpdateStaffMemberCommand(this, staffStore);
            CancelCommand = new NavigateCommand(navigationService);
        }
    }
}
