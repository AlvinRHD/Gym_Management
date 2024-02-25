using Gym_Management.Data;
using Gym_Management.Models;

namespace Gym_Management.Repositories.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public CustomerRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<CustomerModel> GetAll() 
        {
            List<CustomerModel> Customerlist = new List<CustomerModel>();

            using (var connection = _dbConnection.GetConnection())
            {

            }

        }

    }
}
