using System.ComponentModel;

namespace Gym_Management.Models
{
    public class ProgramModel
    {
        public int ProgramsID { get; set; }


        [DisplayName("Nombre del programa")]
        public string NameP { get; set; }

        [DisplayName("Descripción")]
        public string DescriptionP { get; set; }

        [DisplayName("Indica si está activo o no")]
        public bool IsActive { get; set; }

    }
}
