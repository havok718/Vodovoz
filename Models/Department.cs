namespace Vodovoz.Models
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StaffMember? Head { get; set; }

        public Department(int id, string name, StaffMember? head = null)
        {
            Id = id;
            Name = name;
            Head = head;
        }

        internal bool Confilcts(Department department)
        {
            if (department.Id != Id)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
