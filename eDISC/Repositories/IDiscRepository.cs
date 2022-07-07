using eDISC.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace eDISC.Repositories
{
    public interface IDiscRepository
    {
        List<Disc> GetAllDiscsForSale();
        Disc GetDiscById(int id);
        List<Brand> GetAllBrands();
        void AddDisc(Disc disc);

        void AddDiscToCart(int cartId, int discId, int userId);
        void UpdateDisc(Disc disc);
        void DeleteDisc(int id);
    }
}
