using eDISC.Models;
using eDISC.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace eDISC.Repositories
{
    public class CartRepository : ICartRepository, ICartRepository
    {
        private readonly IConfiguration _config;

        public CartRepository(IConfiguration config)
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

        public Cart GetUsersMostRecentCart


        public List<Disc> GetACartsDiscs(Cart cart) //func may not be right
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT * FROM discs d,  
                                        JOIN CartDisc cd on cd.DiscId=d.Id
                                        JOIN Cart c on c.Id=cd.CartId
                                        where c.Id=@id;
                    ";
                    cmd.Parameters.AddWithValue("@id", cart.Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Disc> discs = new List<Disc>();
                        while (reader.Read())
                        {
                            Disc disc = new Disc
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                BrandId = reader.GetInt32(reader.GetOrdinal("BrandId")),
                                Condition = reader.GetString(reader.GetOrdinal("Condition")),
                                Speed = reader.GetInt32(reader.GetOrdinal("Speed")),
                                Glide = reader.GetInt32(reader.GetOrdinal("Glide")),
                                Turn = reader.GetInt32(reader.GetOrdinal("Turn")),
                                Fade = reader.GetInt32(reader.GetOrdinal("Fade")),
                                Plastic = reader.GetString(reader.GetOrdinal("Plastic")),
                                Price = reader.GetInt32(reader.GetOrdinal("Price")),
                                Weight = reader.GetInt32(reader.GetOrdinal("Weight")),
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
                                DiscTypeId = reader.GetInt32(reader.GetOrdinal("DiscTypeId")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Brand = new Brand()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("BrandsId")),
                                    Name = reader.GetString(reader.GetOrdinal("BrandName"))
                                }
                            };
                            discs.Add(disc);
                        }
                        return discs;
                    }
                }
            }
        }

        public Cart GetCartById(int cartId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.*, u.id as UsersId, u.Name
                                        FROM Cart c 
                                        JOIN Users u on u.Id=c.UserId
                                        WHERE c.Id=@id
                    ";
                    cmd.Parameters.AddWithValue("@id", cartId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Cart cart = new Cart
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                User = new User
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("UsersId")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                }
                            };
                            cart.Discs = GetACartsDiscs(cart);
                            return cart;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void AddCart(Cart cart)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" INSERT INTO Cart (UserId)
                                          OUTPUT INSERTED.ID
                                          VALUES (@userId";
                    DbUtils.AddParameter(cmd, "@userId", cart.UserId);

                    int id = (int)cmd.ExecuteScalar();
                    cart.Id = id;
                }
            }
        }

        public void AddDiscToCart(int cartId, int discId, int userId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" INSERT INTO CartDisc (CartId, DiscId, UserId)
                                          OUTPUT INSERTED.ID
                                          VALUES (@cartId, @discId, @userId);";
                    DbUtils.AddParameter(cmd, "@cartId", cartId);
                    DbUtils.AddParameter(cmd, "@discId", discId);
                    DbUtils.AddParameter(cmd, "@userId", userId);

                    cmd.ExecuteScalar();

                }
            }
        }

    }
}
