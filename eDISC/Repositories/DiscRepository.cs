using eDISC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using eDISC.Utils;

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


        
        public List<Disc> GetAllDiscsForSale()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT d.*, b.Id as BrandsId, b.Name as BrandName 
                                        FROM Disc d 
                                        JOIN Brands b on b.Id=d.BrandId
                                        WHERE d.DiscTypeId=1";

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Disc> discs = new List<Disc>();
                        while(reader.Read())
                        {
                            Disc disc = new Disc
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                BrandId = DbUtils.GetInt(reader, "BrandId"),
                                Condition = DbUtils.GetString(reader, "Condition"),
                                Speed = DbUtils.GetInt(reader, "Speed"),
                                Glide = DbUtils.GetInt(reader, "Glide"),
                                Turn = DbUtils.GetInt(reader, "Turn"),
                                Fade = DbUtils.GetInt(reader, "Fade"),
                                Plastic = DbUtils.GetString(reader, "Plastic"),
                                Price = DbUtils.GetInt(reader, "Price"),
                                Weight = DbUtils.GetInt(reader, "Weight"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                DiscTypeId = DbUtils.GetInt(reader, "DiscTypeId"),
                                Description = DbUtils.GetString(reader, "Description"),
                                Brand = new Brand()
                                {
                                    Id = DbUtils.GetInt(reader, "BrandsId"),
                                    Name = DbUtils.GetString(reader, "BrandName"),
                                }
                            };
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
                    cmd.CommandText = @"SELECT d.*, 
                                        b.Id as BrandsId, b.Name as BrandName,
                                        t.Id as TagsId, t.Name as TagName
                                        FROM Disc d 
                                        JOIN Brands b on b.Id=d.BrandId
                                        JOIN DiscTags dt on dt.DiscId=d.Id
                                        JOIN Tags t on t.Id=dt.TagId
                                        WHERE d.Id=@id
                    ";
                    DbUtils.AddParameter(cmd, "@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Disc disc = null;
                        while (reader.Read())
                        {
                            int discId = DbUtils.GetInt(reader, "Id");

                            if (disc == null)
                            {
                                disc = new Disc()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    Name = DbUtils.GetString(reader, "Name"),
                                    BrandId = DbUtils.GetInt(reader, "BrandId"),
                                    Condition = DbUtils.GetString(reader, "Condition"),
                                    Speed = DbUtils.GetInt(reader, "Speed"),
                                    Glide = DbUtils.GetInt(reader, "Glide"),
                                    Turn = DbUtils.GetInt(reader, "Turn"),
                                    Fade = DbUtils.GetInt(reader, "Fade"),
                                    Plastic = DbUtils.GetString(reader, "Plastic"),
                                    Price = DbUtils.GetInt(reader, "Price"),
                                    Weight = DbUtils.GetInt(reader, "Weight"),
                                    ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                    DiscTypeId = DbUtils.GetInt(reader, "DiscTypeId"),
                                    Description = DbUtils.GetString(reader, "Description"),
                                    Brand = new Brand()
                                    {
                                        Id = DbUtils.GetInt(reader, "BrandsId"),
                                        Name = DbUtils.GetString(reader, "BrandName"),
                                    },
                                    Tags = new List<Tag>()
                                };
                            }
                            if(DbUtils.IsNotDbNull(reader, "TagsId"))
                            {
                                disc.Tags.Add(new Tag()
                                {
                                    Id = DbUtils.GetInt(reader, "TagsId"),
                                    Name = DbUtils.GetString(reader, "TagName")
                                });
                            }

                        }
                        return disc;
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
                    cmd.CommandText = @"INSERT INTO Disc ([Name], BrandId, Condition, Speed, Glide, Turn, Fade, Plastic, Price, [ImageURL], Weight, Description, DiscTypeId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@name, @brandId, @condition, @speed, @glide, @turn, @fade, @plastic, @price, @imageURL, @weight, @description, @discTypeId)";
                    DbUtils.AddParameter(cmd, "@name", disc.Name);
                    DbUtils.AddParameter(cmd,"@brandId", disc.BrandId);
                    DbUtils.AddParameter(cmd,"@condition", disc.Condition);
                    DbUtils.AddParameter(cmd,"@speed", disc.Speed);
                    DbUtils.AddParameter(cmd,"@glide", disc.Glide);
                    DbUtils.AddParameter(cmd,"@turn", disc.Turn);
                    DbUtils.AddParameter(cmd,"@fade", disc.Fade);
                    DbUtils.AddParameter(cmd,"@plastic", disc.Plastic);
                    DbUtils.AddParameter(cmd,"@price", disc.Price);
                    DbUtils.AddParameter(cmd,"@imageURL", disc.ImageUrl);
                    DbUtils.AddParameter(cmd,"@weight", disc.Weight);
                    DbUtils.AddParameter(cmd,"@description", disc.Description);
                    DbUtils.AddParameter(cmd,"@discTypeId", disc.DiscTypeId);

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
                    cmd.CommandText = @"UPDATE Disc
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

                    DbUtils.AddParameter(cmd, "@name", disc.Name);
                    DbUtils.AddParameter(cmd, "@brandId", disc.BrandId);
                    DbUtils.AddParameter(cmd, "@condition", disc.Condition);
                    DbUtils.AddParameter(cmd, "@speed", disc.Speed);
                    DbUtils.AddParameter(cmd, "@glide", disc.Glide);
                    DbUtils.AddParameter(cmd, "@turn", disc.Turn);
                    DbUtils.AddParameter(cmd, "@fade", disc.Fade);
                    DbUtils.AddParameter(cmd, "@plastic", disc.Plastic);
                    DbUtils.AddParameter(cmd, "@price", disc.Price);
                    DbUtils.AddParameter(cmd, "@imageURL", disc.ImageUrl);
                    DbUtils.AddParameter(cmd, "@weight", disc.Weight);
                    DbUtils.AddParameter(cmd, "@description", disc.Description);
                    DbUtils.AddParameter(cmd, "@discTypeId", disc.DiscTypeId);

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
                    cmd.CommandText = @" DELETE FROM Disc WHERE Id=@id";
                    DbUtils.AddParameter(cmd, "@id", discId);
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
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                            };
                            brands.Add(brand);
                        }
                        return brands;
                    }
                }
            }
        }


        //public List<Tag> GetADiscsTags(Disc disc)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @" Select t.Id, t.Name 
        //                                FROM DiscTags dt 
        //                                JOIN Tags t on t.Id=dt.TagId 
        //                                JOIN Discs d on d.Id=dt.DiscId 
        //                                Where d.Id=@id
        //            ";
        //            cmd.Parameters.AddWithValue("@id", disc.Id);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                List<Tag> tags = new List<Tag>();
        //                while(reader.Read())
        //                {
        //                    Tag tag = new Tag
        //                    {
        //                        Id = DbUtils.GetInt(reader, "Id"),
        //                        Name = DbUtils.GetString(reader, "Name"),
        //                    };
        //                    tags.Add(tag);
        //                }
        //                return tags;
        //            }
        //        }
        //    }
        //}

    }
}
