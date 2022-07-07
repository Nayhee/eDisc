using eDISC.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace eDISC.Repositories
{
    public interface ICartRepository
    {
        SqlConnection Connection { get; }

        void AddCart(Cart cart);
        void AddDiscToCart(int cartId, int discId, int userId);
        List<Disc> GetACartsDiscs(Cart cart);
        Cart GetCartById(int cartId);
    }
}