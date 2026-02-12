using System.Data;

namespace ChubbReto.Infraestructure.Database
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
