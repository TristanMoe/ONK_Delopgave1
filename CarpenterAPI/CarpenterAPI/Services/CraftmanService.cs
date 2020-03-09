using CarpenterAPI.Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpenterAPI.Services
{
    public class CraftmanService
    {
        private readonly IMongoCollection<Craftsman> _craftsmenCollection;
        
        public CraftmanService(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetConnectionString("CraftsmanDb"));
            var database = mongoClient.GetDatabase("CraftsmanDb");
            _craftsmenCollection = database.GetCollection<Craftsman>("Craftsmen");
        }

        public IEnumerable<Craftsman> GetAll()
        {
            return _craftsmenCollection.Find(_ => true).ToList(); 
        }

        public Craftsman Get(string id)
        {
            return _craftsmenCollection.Find(cm => cm.CraftsmanId == id).FirstOrDefault(); 
        }

        public Craftsman Create(Craftsman value)
        {
            var craftsman = _craftsmenCollection.Find(cm => cm.CraftsmanId == value.CraftsmanId).FirstOrDefault();
            if (craftsman != null)
                throw new Exception("Craftsman already exists");
            _craftsmenCollection.InsertOne(value);
            return value;
        }

        public Craftsman Update(string id, Craftsman craftsman)
        {
            _craftsmenCollection.FindOneAndReplace(cm => cm.CraftsmanId == id, craftsman);
            return craftsman;
        }

        public void Delete(string id)
        {
            _craftsmenCollection.DeleteOne(cm => cm.CraftsmanId.Equals(id));
        }
    }
}
