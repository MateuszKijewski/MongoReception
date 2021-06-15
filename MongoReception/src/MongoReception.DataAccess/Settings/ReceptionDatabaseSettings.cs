using MongoReception.DataAccess.Interfaces;

namespace MongoReception.DataAccess.Settings
{
    public class ReceptionDatabaseSettings : IReceptionDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
