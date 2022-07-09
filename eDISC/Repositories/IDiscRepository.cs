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

        List<Disc> SearchDiscByName(string q);
        void UpdateDisc(Disc disc);
        void DeleteDisc(int id);
    }
}
