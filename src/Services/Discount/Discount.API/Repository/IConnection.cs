using Npgsql;

namespace Discount.API.Repository
{
    public interface IConnection
    {
        NpgsqlConnection GetConnection();
    }
}
