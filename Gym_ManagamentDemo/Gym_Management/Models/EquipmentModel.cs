using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gym_Management.Models
{
    public class EquipmentModel
    {
        public int EquipmentID { get; set; }

        [DisplayName("Nombre del equipo")]
        public string NameE { get; set; }

        [DisplayName("Cantidad Disponible")]
        public int Quantity { get; set; }

        [DisplayName("Indica si está activo o no")]
        public bool IsActive { get; set; }


    }
}
