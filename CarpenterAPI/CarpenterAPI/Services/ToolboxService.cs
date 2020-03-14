using CarpenterAPI.Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarpenterAPI.Services
{
    public class ToolboxService
    {
        private readonly IMongoCollection<Toolbox> _toolboxCollection;
        public ToolboxService(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetConnectionString("CraftsmanDb"));
            var database = mongoClient.GetDatabase("CraftsmanDb");
            _toolboxCollection = database.GetCollection<Toolbox>("Toolboxes");
        }

        public async Task<IEnumerable<Toolbox>> GetAll()
        {
            return await _toolboxCollection.FindAsync(_ => true).Result.ToListAsync();
        }

        public async Task<Toolbox> Get(string id)
        {
            return await _toolboxCollection.FindAsync(tb => tb.ToolboxId == id).Result.FirstOrDefaultAsync();
        }

        public async Task<Toolbox> Create(Toolbox value)
        {
            var toolbox = await _toolboxCollection.FindAsync(tb => tb.ToolboxId == value.ToolboxId).Result.FirstOrDefaultAsync();
            if (toolbox != null)
                throw new Exception("Toolbox already exists");
            await _toolboxCollection.InsertOneAsync(value);
            return value;
        }

        public async Task<Toolbox> Update(Toolbox toolbox)
        {
            return await _toolboxCollection.FindOneAndReplaceAsync(tb => tb.ToolboxId == toolbox.ToolboxId, toolbox);
        }

        public async Task Delete(string id)
        {
            await _toolboxCollection.DeleteOneAsync(cm => cm.ToolboxId == id);
        }
    }
}
