namespace MongoReception.DataAccess.Interfaces
{
    public interface IReceptionDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
