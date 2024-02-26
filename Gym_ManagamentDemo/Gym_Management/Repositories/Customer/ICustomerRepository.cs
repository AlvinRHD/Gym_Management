using Gym_Management.Models;

namespace Gym_Management.Repositories.Customer
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerModel> GetAll();

        CustomerModel GetById(int CustomerID);

        void Add(CustomerModel customer);

        void Edit(CustomerModel customer);

        void Delete(int customerID);
    }
}
