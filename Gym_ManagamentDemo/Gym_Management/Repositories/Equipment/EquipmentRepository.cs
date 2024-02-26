using Gym_Management.Data;
using Gym_Management.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Gym_Management.Repositories.Equipment
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public EquipmentRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<EquipmentModel> GetAll()
        {
            List<EquipmentModel> Equipmentlist = new List<EquipmentModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT EquipmentID, NameE, Quantity, IsActive FROM Equipment;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EquipmentModel equipment = new EquipmentModel();
                            equipment.EquipmentID = Convert.ToInt32(reader["EquipmentID"]);
                            equipment.NameE = reader["NameE"].ToString();
                            equipment.Quantity = Convert.ToInt32(reader["Quantity"]);
                            equipment.IsActive = Convert.ToBoolean(reader["IsActive"]);


                            Equipmentlist.Add(equipment);
                        }
                    }
                }
            }
            return Equipmentlist;
        }

        public EquipmentModel? GetById(int EquipmentID)

        {
            EquipmentModel? equipment = null;

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT EquipmentID, NameE, Quantity, IsActive FROM Equipment
                                            WHERE EquipmentID = @EquipmentID";

                    command.Parameters.AddWithValue("@EquipmentID", EquipmentID);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            equipment = new EquipmentModel
                            {
                                EquipmentID = Convert.ToInt32(reader["EquipmentID"]),
                                NameE = reader["NameE"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }
            return equipment;
        }
        public void Add(EquipmentModel equipment)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Equipment                                         
                                           VALUES(@NameE, @Quantity, @IsActive)";

                    command.Parameters.AddWithValue("@NameE", equipment.NameE);
                    command.Parameters.AddWithValue("@Quantity", equipment.Quantity);
                    
                    command.Parameters.AddWithValue("@IsActive", equipment.IsActive);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(EquipmentModel equipment)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Equipment 
                                           SET NameE = @NameE,
                                           Quantity = @Quantity,
                                           
                                           IsActive = @IsActive
                                           WHERE EquipmentID = @EquipmentID";

                    command.Parameters.AddWithValue("@NameE", equipment.NameE);
                    command.Parameters.AddWithValue("@Quantity", equipment.Quantity);
              
                    command.Parameters.AddWithValue("@IsActive", equipment.IsActive);
                    command.Parameters.AddWithValue("@EquipmentID", equipment.EquipmentID);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int EquipmentID)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Equipment
                                           WHERE EquipmentID = @EquipmentID";

                    command.Parameters.AddWithValue("@EquipmentID", EquipmentID);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
