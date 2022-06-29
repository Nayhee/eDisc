using eDISC.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace eDISC.Repositories
{
    public interface IDiscRepository
    {
        List<Disc> GetAllDiscsForSale();
        Disc GetDiscById(int id);
        void AddDisc(Disc disc);
        void UpdateDisc(Disc disc);
        void DeleteDisc(int id);
    }
}
