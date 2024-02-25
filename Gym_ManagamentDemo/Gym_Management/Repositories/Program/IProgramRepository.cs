using Gym_Management.Models;

namespace Gym_Management.Repositories.Program
{
    public interface IProgramRepository
    {
        IEnumerable<ProgramModel> GetAll();

        ProgramModel GetProgramById(int id);

        void Add(ProgramModel program);

        void Edit(ProgramModel program);

        void Delete(ProgramModel program);
    }
}
