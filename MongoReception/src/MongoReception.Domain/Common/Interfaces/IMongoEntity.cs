namespace MongoReception.Domain.Common.Interfaces
{
    public interface IMongoEntity
    {
        public string Id { get; set; }

        public string GetCollectionName();
    }
}
