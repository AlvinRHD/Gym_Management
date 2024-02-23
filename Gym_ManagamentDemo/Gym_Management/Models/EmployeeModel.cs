using System.ComponentModel;

namespace Gym_Management.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Indica si está activo o no")]
        public bool IsActive { get; set; }
    }
}
