using Gym_Management.Data;
using Gym_Management.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Gym_Management.Repositories.Program
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public ProgramRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<ProgramModel> GetAll()
        {
            List<ProgramModel> Programlist = new List<ProgramModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT ProgramsID, NameP, DescriptionP, IsActive FROM Programs;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProgramModel program = new ProgramModel();
                            program.ProgramsID = Convert.ToInt32(reader["ProgramsID"]);
                            program.NameP = reader["NameP"].ToString();
                            program.DescriptionP = reader["DescriptionP"].ToString();
                            program.IsActive = Convert.ToBoolean(reader["IsActive"]);


                            Programlist.Add(program);
                        }
                    }
                }
            }
            return Programlist;
        }

        public ProgramModel? GetById(int ProgramID)

        {
            ProgramModel? program = null;

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT ProgramsID, NameP, DescriptionP, IsActive FROM Programs
                                            WHERE ProgramsID = @ProgramsID";

                    command.Parameters.AddWithValue("@ProgramsID", ProgramID);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            program = new ProgramModel
                            {
                                ProgramsID = Convert.ToInt32(reader["ProgramsID"]),
                                NameP = reader["NameP"].ToString(),
                                DescriptionP = reader["DescriptionP"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }
            return program;
        }
        public void Add(ProgramModel program)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Programs                                         
                                           VALUES(@NameP, @DescriptionP, @IsActive)";

                    command.Parameters.AddWithValue("@NameP", program.NameP);
                    command.Parameters.AddWithValue("@DescriptionP", program.DescriptionP);
                    command.Parameters.AddWithValue("@IsActive", program.IsActive);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(ProgramModel program)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Programs
                                           SET NameP = @NameP,
                                           DescriptionP = @DescriptionP,
                                           IsActive = @IsActive
                                           WHERE ProgramsID = @ProgramsID";

                    command.Parameters.AddWithValue("@NameP", program.NameP);
                    command.Parameters.AddWithValue("@DescriptionP", program.DescriptionP);
                    command.Parameters.AddWithValue("@IsActive", program.IsActive);
                    command.Parameters.AddWithValue("@CustomerID", program.ProgramsID);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int programID)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Programs
                                           WHERE ProgramsID = @ProgramsID";

                    command.Parameters.AddWithValue("@ProgramsID", programID);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
