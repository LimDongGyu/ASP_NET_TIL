using System.Configuration;
using System.Data;

namespace BasicModels
{
    public class BasicRepository
    {
        private IDbConnection db;
        public BasicRepository()
        {
            db = new SqlConnection(ConfigurationManager);
        }
    }
}
