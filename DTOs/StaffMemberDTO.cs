using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vodovoz.Models;

namespace Vodovoz.DTOs
{
    internal class StaffMemberDTO
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? SurName { get; set; }
        public string? Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string? DepartmentName { get; set; }
    }
}
