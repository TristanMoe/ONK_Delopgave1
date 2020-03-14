using CarpenterAPI.Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarpenterAPI.Services
{
    public class CraftsmanService
    {
        private readonly IMongoCollection<Craftsman> _craftsmenCollection;
        
        public CraftsmanService(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetConnectionString("CraftsmanDb"));
            var database = mongoClient.GetDatabase("CraftsmanDb");
            _craftsmenCollection = database.GetCollection<Craftsman>("Craftsmen");
        }

        public async Task<IEnumerable<Craftsman>> GetAll()
        {
            return await _craftsmenCollection.FindAsync(_ => true).Result.ToListAsync(); 
        }

        public async Task<Craftsman> Get(string id)
        {
            return await _craftsmenCollection.FindAsync(cm => cm.CraftsmanId == id).Result.FirstOrDefaultAsync(); 
        }

        public async Task<Craftsman> Create(Craftsman value)
        {
            var craftsman = await _craftsmenCollection.FindAsync(cm => cm.CraftsmanId == value.CraftsmanId).Result.FirstOrDefaultAsync();
            if (craftsman != null)
                throw new Exception("Craftsman already exists");
            await _craftsmenCollection.InsertOneAsync(value);
            return value;
        }

        public async Task<Craftsman> Update(Craftsman craftsman)
        {
            return await _craftsmenCollection.FindOneAndReplaceAsync(cm => cm.CraftsmanId == craftsman.CraftsmanId, craftsman);
        }

        public async Task Delete(string id)
        {
            await _craftsmenCollection.DeleteOneAsync(cm => cm.CraftsmanId == id);
        }
    }
}
