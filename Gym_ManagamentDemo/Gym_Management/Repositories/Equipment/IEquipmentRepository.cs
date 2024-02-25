using Gym_Management.Models;

namespace Gym_Management.Repositories.Equipment
{
    public interface IEquipmentRepository
    {

        IEnumerable<EquipmentModel> GetAll();

        EquipmentModel GetEquipmentById(int id);

        void Add(EquipmentModel equipment);

        void Edit(EquipmentModel equipment);

        void Delete(EquipmentModel equipment);
    }
}
