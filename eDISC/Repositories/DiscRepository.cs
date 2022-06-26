using eDISC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace eDISC.Repositories
{
    public class DiscRepository :IDiscRepository
    {
        private readonly IConfiguration _config;
        public DiscRepository(IConfiguration config)
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

        public List<Tag> GetADiscsTags(Disc disc)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" Select t.Id, t.Name 
                                        FROM DiscTags dt 
                                        JOIN Tags t on t.Id=dt.TagId 
                                        JOIN Discs d on d.Id=dt.DiscId 
                                        Where d.Id=@id
                    ";
                    cmd.Parameters.AddWithValue("@id", disc.Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Tag> tags = new List<Tag>();
                        while(reader.Read())
                        {
                            Tag tag = new Tag
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                            };
                            tags.Add(tag);
                        }
                        return tags;
                    }
                }
            }
        }
        
        public List<Disc> GetAllDiscs()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT d.*, b.Id as BrandsId, b.Name as BrandName 
                                        FROM Discs d 
                                        JOIN Brands b on b.Id=d.BrandId";

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Disc> discs = new List<Disc>();
                        while(reader.Read())
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
                                Brand = new Brand()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("BrandsId")),
                                    Name = reader.GetString(reader.GetOrdinal("BrandName"))
                                }
                            };
                            var tags = GetADiscsTags(disc);
                            disc.Tags = tags;

                            discs.Add(disc);
                        }
                        return discs;
                    }
                }
            }
        }
        public Disc GetDiscById(int id)
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT d.*, b.Id as BrandsId, b.Name as BrandName 
                                        FROM Discs d 
                                        JOIN Brands b on b.Id=d.BrandId
                                        WHERE d.Id=@id
                    ";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            Disc disc = new Disc
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                BrandId = reader.GetInt32(reader.GetOrdinal("BrandId")),
                                Condition = reader.GetString(reader.GetOrdinal("Condition")),
                                Speed = reader.GetInt32(reader.GetOrdinal("Speed")),
                                Glide = reader.GetInt32(reader.GetOrdinal("Glide")),
                                Turn = reader.GetInt32(reader.GetOrdinal("Turn")),
                                Fade = reader.GetInt32(reader.GetOrdinal("Fade")),
                                Plastic = reader.GetString(reader.GetOrdinal("Plastic")),
                                Price = reader.GetInt32(reader.GetOrdinal("Price")),
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageURL")),
                                Weight = reader.GetInt32(reader.GetOrdinal("Weight")),
                                Brand = new Brand()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("BrandsId")),
                                    Name = reader.GetString(reader.GetOrdinal("BrandName"))
                                }
                            };
                            var tags = GetADiscsTags(disc);
                            disc.Tags = tags;
                            return disc;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

    }
}
