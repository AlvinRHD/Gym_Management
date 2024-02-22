using System.Collections.Generic;
using Gym_Managment.Data;
using Gym_Managment.Models;
using Microsoft.Data.SqlClient;

namespace Gym_Managment.Repositories.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlDataAccess _sqlDataAccess;

        public CustomerRepository(SqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public CustomerModel GetCustomerById(int customerId)
        {
            // Implementa la lógica para obtener un cliente por ID desde la base de datos
            // Puedes utilizar el método ExecuteReader del SqlDataAccess para ejecutar una consulta SELECT
            // y mapear los resultados a un objeto CustomerModel
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetAllCustomers()
        {
            // Implementa la lógica para obtener todos los clientes desde la base de datos
            // Puedes utilizar el método ExecuteReader del SqlDataAccess para ejecutar una consulta SELECT
            // y mapear los resultados a una lista de CustomerModel
            throw new NotImplementedException();
        }

        public void CreateCustomer(CreateCustomer createCustomer)
        {
            createCustomer.Execute(_sqlDataAccess);
        }

        public void EditCustomer(EditCustomer editCustomer)
        {
            editCustomer.Execute(_sqlDataAccess);
        }

        public void DeleteCustomer(DeleteCustomer deleteCustomer)
        {
            deleteCustomer.Execute(_sqlDataAccess);
        }
    }
}
