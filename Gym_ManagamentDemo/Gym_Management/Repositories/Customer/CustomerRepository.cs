using Gym_Management.Data;
using Gym_Management.Models;
using Microsoft.Data.SqlClient;
using System.Data;

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
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT CustomerID, FirstName, LastName, DateOfBirth, IsActive FROM Customer;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerModel customer = new CustomerModel();
                            customer.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                            customer.FirstName = reader["FirstName"].ToString();
                            customer.LastName = reader["LastName"].ToString();
                            customer.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            customer.IsActive = Convert.ToBoolean(reader["IsActive"]);


                            Customerlist.Add(customer);
                        }
                    }
                }
            }
            return Customerlist;
        }

        public CustomerModel? GetCustomerById(int CustomerID)

        {
            CustomerModel? customer = null;

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT CustomerID, FirstName, LastName, DateOfBirth, IsActive FROM Customer
                                            WHERE CustomerID = @CustomerID";

                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                if (reader.Read())
                {
                    customer = new CustomerModel
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    };
                }
            }
        }
    }
        return customer;
}
        public void Add(CustomerModel customer)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Customer                                         
                                           VALUES(@FirstName, @LastName, @DateOfBirth, @IsActive)";

                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                    command.Parameters.AddWithValue("@IsActive", customer.IsActive);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(CustomerModel customer)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Customer 
                                           SET FirstName = @FirstName,
                                           LastName = @LastName,
                                           DateOfBirth = @DateOfBirth,
                                           IsActive = @IsActive
                                           WHERE CustomerID = @CustomerID";

                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                    command.Parameters.AddWithValue("@IsActive", customer.IsActive);
                    command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(CustomerModel customer)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Customer
                                           WHERE CustomerID = @CustomerID";

                    command.Parameters.AddWithValue("@CustomerID", customer);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public string? GetById(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public void Delete(int customerID)
        {
            throw new NotImplementedException();
        }

        CustomerModel ICustomerRepository.GetById(int CustomerID)
        {
            throw new NotImplementedException();
        }
    }
}
