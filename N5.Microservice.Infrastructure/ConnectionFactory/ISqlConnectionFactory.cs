using System.Data;

namespace DDDCQRS.Microservice.Infrastructure.ConnectionFactory
{
    public interface ISqlConnectionFactory
    {
         IDbConnection GetOpenConnection();
    }
}