using Npgsql;

namespace Discount.Grpc.Repository
{
    public interface IConnection
    {
        NpgsqlConnection GetConnection();
    }
}
