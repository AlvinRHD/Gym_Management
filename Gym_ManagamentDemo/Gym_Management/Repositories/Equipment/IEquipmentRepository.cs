using Gym_Management.Models;

namespace Gym_Management.Repositories.Equipment
{
    public interface IEquipmentRepository
    {

        IEnumerable<EquipmentModel> GetAll();

        EquipmentModel GetById(int EquipmentID);

        void Add(EquipmentModel equipment);

        void Edit(EquipmentModel equipment);

        void Delete(int equipmentID);
    }
}
