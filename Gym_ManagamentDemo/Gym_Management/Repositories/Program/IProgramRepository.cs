using Gym_Management.Models;

namespace Gym_Management.Repositories.Program
{
    public interface IProgramRepository
    {
        IEnumerable<ProgramModel> GetAll();

        ProgramModel GetById(int ProgramID);

        void Add(ProgramModel program);

        void Edit(ProgramModel program);

        void Delete(int ProgramID);
    }
}
