using CarpenterAPI.Configuration;
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
            var mongoClient = new MongoClient(AppConfig.ConnectionStringDb);
            var database = mongoClient.GetDatabase("CraftsmanDb");
            _craftsmenCollection = database.GetCollection<Craftsman>("Craftsmen");
        }

        public Craftsman Get(string firstname, string surname)
        {
            return _craftsmenCollection.Find(cm => cm.Firstname == firstname && cm.Surname == surname).FirstOrDefault(); 
        }

        public List<Craftsman> GetAll()
        {
            return _craftsmenCollection.Find(user => true).ToList(); 
        }

        public Craftsman Create(Craftsman craftsman)
        {
            var userExists = _craftsmenCollection.Find(cm => cm.CraftsmanId == craftsman.CraftsmanId).FirstOrDefault();
            if (userExists != null)
                throw new Exception("User already exists");
            craftsman.ToolBoxes = new List<Toolbox>();
            _craftsmenCollection.InsertOne(craftsman);
            return craftsman;         
        }

        public Craftsman Update(Craftsman craftsman)
        {
            _craftsmenCollection.ReplaceOne<Craftsman>(cm => cm.CraftsmanId == craftsman.CraftsmanId, craftsman);
            return craftsman; 
        }
    }
}
