using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;

namespace Fiap_ChallengeQUOD
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("BiometriaDB");
        }

        public IMongoCollection<BsonDocument> Biometrias => _database.GetCollection<BsonDocument>("biometrias");
        public IMongoCollection<BsonDocument> Documentos => _database.GetCollection<BsonDocument>("documentos");
        public IMongoCollection<BsonDocument> Notificacoes => _database.GetCollection<BsonDocument>("notificacoes");
    }
}
