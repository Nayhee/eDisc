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
        
        public List<Disc> GetAllDiscsForSale()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT d.*, b.Name as BrandName 
                                        FROM Discs d 
                                        JOIN Brands b on b.Id=d.BrandId
                                        WHERE d.DiscTypeId=1";

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
                                DiscTypeId = reader.GetInt32(reader.GetOrdinal("DiscTypeId")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Brand = new Brand()
                                {
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
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                DiscTypeId = reader.GetInt32(reader.GetOrdinal("DiscTypeId")),
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

        public void AddDisc(Disc disc)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Discs ([Name], BrandId, Condition, Speed, Glide, Turn, Fade, Plastic, Price, [ImageURL], Weight, Description, DiscTypeId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@name, @brandId, @condition, @speed, @glide, @turn, @fade, @plastic, @price, @imageURL, @weight, @description, @discTypeId)";
                    cmd.Parameters.AddWithValue("@name", disc.Name);
                    cmd.Parameters.AddWithValue("@brandId", disc.BrandId);
                    cmd.Parameters.AddWithValue("@condition", disc.Condition);
                    cmd.Parameters.AddWithValue("@speed", disc.Speed);
                    cmd.Parameters.AddWithValue("@glide", disc.Glide);
                    cmd.Parameters.AddWithValue("@turn", disc.Turn);
                    cmd.Parameters.AddWithValue("@fade", disc.Fade);
                    cmd.Parameters.AddWithValue("@plastic", disc.Plastic);
                    cmd.Parameters.AddWithValue("@price", disc.Price);
                    cmd.Parameters.AddWithValue("@imageURL", disc.ImageUrl);
                    cmd.Parameters.AddWithValue("@weight", disc.Weight);
                    cmd.Parameters.AddWithValue("@description", disc.Description);
                    cmd.Parameters.AddWithValue("@discTypeId", disc.DiscTypeId);

                    int id = (int)cmd.ExecuteScalar();
                    disc.Id = id;
                }
            }
        }
        public void UpdateDisc(Disc disc)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Discs
                                        SET 
                                            [Name] = @name, 
                                            BrandId = @brandId,
                                            Condition = @condition,
                                            Speed = @speed, 
                                            Glide = @glide,
                                            Turn = @turn,
                                            Fade = @fade, 
                                            Plastic = @plastic,
                                            Price = @price,
                                            ImageURL = @imageURL,
                                            Weight = @weight,
                                            Description = @description,
                                            DiscTypeId = @discTypeId
                                               
                                            WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@name", disc.Name);
                    cmd.Parameters.AddWithValue("@brandId", disc.BrandId);
                    cmd.Parameters.AddWithValue("@condition", disc.Condition);
                    cmd.Parameters.AddWithValue("@speed", disc.Speed);
                    cmd.Parameters.AddWithValue("@glide", disc.Glide);
                    cmd.Parameters.AddWithValue("@turn", disc.Turn);
                    cmd.Parameters.AddWithValue("@fade", disc.Fade);
                    cmd.Parameters.AddWithValue("@plastic", disc.Plastic);
                    cmd.Parameters.AddWithValue("@price", disc.Price);
                    cmd.Parameters.AddWithValue("@imageURL", disc.ImageUrl);
                    cmd.Parameters.AddWithValue("@weight", disc.Weight);
                    cmd.Parameters.AddWithValue("@id", disc.Id);
                    cmd.Parameters.AddWithValue("@description", disc.Description);
                    cmd.Parameters.AddWithValue("@discTypeId", disc.DiscTypeId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteDisc(int discId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" DELETE FROM Discs WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", discId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Brand> GetAllBrands()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" Select * FROM Brands";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Brand> brands = new List<Brand>();
                        while (reader.Read())
                        {
                            Brand brand = new Brand
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                            };
                            brands.Add(brand);
                        }
                        return brands;
                    }
                }
            }
        }

    }
}
