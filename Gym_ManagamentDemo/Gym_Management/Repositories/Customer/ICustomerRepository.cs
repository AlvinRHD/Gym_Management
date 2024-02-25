using Gym_Management.Models;

namespace Gym_Management.Repositories.Customer
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerModel> GetAll();

        CustomerModel GetCustomerById(int id);

        void Add(CustomerModel customer);

        void Edit(CustomerModel customer);

        void Delete(CustomerModel customer);
    }
}
