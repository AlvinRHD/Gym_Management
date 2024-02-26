using Gym_Management.Data;
using Gym_Management.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Gym_Management.Repositories.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public EmployeeRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            List<EmployeeModel> Employeelist = new List<EmployeeModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT EmployeeID, FirstName, LastName, DateOfBirth, IsActive FROM Employee;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeModel employee = new EmployeeModel();
                            employee.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                            employee.FirstName = reader["FirstName"].ToString();
                            employee.LastName = reader["LastName"].ToString();
                            employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            employee.IsActive = Convert.ToBoolean(reader["IsActive"]);


                            Employeelist.Add(employee);
                        }
                    }
                }
            }
            return Employeelist;
        }

        public EmployeeModel? GetEmployeeById(int EmployeeID)

        {
            EmployeeModel? employee = null;

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT EmployeeID, FirstName, LastName, DateOfBirth, IsActive FROM Employee
                                            WHERE EmployeeID = @EmployeeID";

                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new EmployeeModel
                            {
                                EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }
            return employee;
        }
        public void Add(EmployeeModel employee)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Employee                                         
                                           VALUES(@FirstName, @LastName, @DateOfBirth, @IsActive)";

                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    command.Parameters.AddWithValue("@IsActive", employee.IsActive);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(EmployeeModel employee)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Employee 
                                           SET FirstName = @FirstName,
                                           LastName = @LastName,
                                           DateOfBirth = @DateOfBirth,
                                           IsActive = @IsActive
                                           WHERE EmployeeID = @EmployeeID";

                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    command.Parameters.AddWithValue("@IsActive", employee.IsActive);
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(EmployeeModel employee)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Employee
                                           WHERE EmployeeID = @EmployeeID";

                    command.Parameters.AddWithValue("@EmployeeID", employee);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public string? GetById(int EmployeeID)
        {
            throw new NotImplementedException();
        }

        public void Delete(int employeeID)
        {
            throw new NotImplementedException();
        }

        public void Add(CustomerModel employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(object employeeID)
        {
            throw new NotImplementedException();
        }
    }
}
