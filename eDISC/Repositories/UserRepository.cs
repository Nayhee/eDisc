using eDISC.Models;
using eDISC.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace eDISC.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        
       
        public List<User> GetAllUsers()
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT u.*, ut.Name as UserTypeName 
                                        FROM Users u 
                                        JOIN UserType ut on ut.Id=u.UserTypeId ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<User> users = new List<User>();
                        while(reader.Read())
                        {
                            User user = new User
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Email = DbUtils.GetString(reader, "Email"),
                                UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                UserType = new UserType
                                {
                                    Name = DbUtils.GetString(reader, "UserTypeName"),
                                }
                            };
                            users.Add(user);
                        }
                        return users;
                    }
                }
            }
        }

        public User GetUserById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT u.*, ut.Name as UserTypeName 
                                        FROM Users u 
                                        JOIN UserType ut on ut.Id=u.UserTypeId
                                        WHERE u.Id=@id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Email = DbUtils.GetString(reader, "Email"),
                                UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                UserType = new UserType
                                {
                                    Name = DbUtils.GetString(reader, "UserTypeName"),
                                }
                            };
                            return user;
                        }
                        return null;
                    }
                }
            }
        }
        public User GetUserByEmail(string email)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT u.*, ut.Name as UserTypeName 
                                        FROM Users u 
                                        JOIN UserType ut on ut.Id=u.UserTypeId
                                        WHERE u.Email = @email";

                    cmd.Parameters.AddWithValue("@email", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Email = DbUtils.GetString(reader, "Email"),
                                UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                UserType = new UserType
                                {
                                    Name = DbUtils.GetString(reader, "UserTypeName"),
                                }
                            };
                            return user;
                        }
                        return null;
                    }
                }
            }
        }

        public List<UserType> GetUserTypes()
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT * FROM UserType";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<UserType> userTypes = new List<UserType>();
                        while (reader.Read())
                        {
                            UserType userType = new UserType
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                            };
                            userTypes.Add(userType);
                        }
                        return userTypes;
                    }
                }
            }
        }

        public void AddUser(User user)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Users ([Name], Email, UserTypeId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@name, @email, @userTypeId)";
                    DbUtils.AddParameter(cmd, "@name", user.Name);
                    DbUtils.AddParameter(cmd, "@email", user.Email);
                    DbUtils.AddParameter(cmd,"@userTypeId", user.UserTypeId);
                    int id = (int)cmd.ExecuteScalar();
                    user.Id = id;
                }
            }
        }
        public void UpdateUser(User user)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Users
                                        SET 
                                            [Name] = @name, 
                                            Email = @email, 
                                            UserTypeId = @userTypeId
                                        WHERE Id = @id";
                    DbUtils.AddParameter(cmd, "@name", user.Name);
                    DbUtils.AddParameter(cmd, "@email", user.Email);
                    DbUtils.AddParameter(cmd, "@userTypeId", user.UserTypeId);
                    DbUtils.AddParameter(cmd, "@id", user.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteUser(int userId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" DELETE FROM Users WHERE Id=@id";
                    DbUtils.AddParameter(cmd, "@id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
