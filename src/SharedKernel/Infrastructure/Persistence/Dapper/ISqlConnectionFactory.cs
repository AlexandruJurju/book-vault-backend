using System.Data;

namespace SharedKernel.Infrastructure.Persistence.Dapper;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
