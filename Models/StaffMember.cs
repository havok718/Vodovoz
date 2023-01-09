using System;

namespace Vodovoz.Models
{
    internal enum Gender
    {
        Male,
        Female
    }

    internal class StaffMember
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string DepartmentName { get; set; }
        public bool IsSelected { get; set; }

        public StaffMember(int id, string lastName, string surName, string name, DateTime birthday, Gender gender, string departmentName)
        {
            Id = id;
            LastName = lastName;
            SurName = surName;
            Name = name;
            Birthday = birthday;
            Gender = gender;
            DepartmentName = departmentName;
        }
    }
}
