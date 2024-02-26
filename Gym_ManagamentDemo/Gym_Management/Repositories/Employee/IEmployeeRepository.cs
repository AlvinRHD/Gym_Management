using Gym_Management.Models;

namespace Gym_Management.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeModel> GetAll();

        EmployeeModel GetEmployeeById(int EmployeeID);

        void Add(EmployeeModel employee);

        void Edit(EmployeeModel employee);

        void Delete(int employeeID);
    }
}
