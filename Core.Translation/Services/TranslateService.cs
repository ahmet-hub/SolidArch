using Dapper;
using System.Data.SqlClient;

namespace Core.Translation.Services
{
    public class TranslateService
    {
        public async Task<string> Translate(string content, string localeCode)
        {
            var connection = new SqlConnection("Data Source=DESKTOP-EUDN6E9;Initial Catalog=Demo-ContentDb;Trusted_Connection=True");
            var query = @$"SELECT cl.Value
                           from ContentLocales cl
                           INNER JOIN Locales  l on l.Code  = '{localeCode}'
                           INNER JOIN Contents c on c.Name = '{content}'";

            //using var connection = _context.CreateConnection();
            var asd= await connection.QuerySingleOrDefaultAsync<string>(query);

            return "translated error message";
        }
    }

    public class TranslatedMessage
    {
        public int Code { get; set; }
        public string Content { get; set; }
        public string Value { get; set; }
    }
}
