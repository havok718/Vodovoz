namespace Vodovoz.Models
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Head { get; set; }

        public Department(int id, string name, int head)
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
