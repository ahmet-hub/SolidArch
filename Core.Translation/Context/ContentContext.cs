using System.Data;
using System.Data.SqlClient;

namespace Core.Translation.Context
{
    public class ContentContext
    {
        public IDbConnection CreateConnection() => new SqlConnection("Data Source=DESKTOP-EUDN6E9;Initial Catalog=Demo-ContentDb;Trusted_Connection=True");
    }
}
