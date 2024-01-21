using Npgsql;

namespace Discount.API.Repository
{
    public class PostgresConnection : IConnection
    {
        private readonly IConfiguration configuration;

        public PostgresConnection(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new NullReferenceException(nameof(configuration));
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(this.configuration.GetValue<string>("DatabaseSettings:ConnectionStrings"));
        }
    }
}
