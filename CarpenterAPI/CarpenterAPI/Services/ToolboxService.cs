using CarpenterAPI.Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

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

        public IEnumerable<Toolbox> GetAll()
        {
            return _toolboxCollection.Find(_ => true).ToList();
        }

        public Toolbox Get(string id)
        {
            return _toolboxCollection.Find(tb => tb.ToolboxId == id).FirstOrDefault();
        }

        public Toolbox Create(Toolbox value)
        {
            var toolbox = _toolboxCollection.Find(tb => tb.ToolboxId == value.ToolboxId).FirstOrDefault();
            if (toolbox == null)
                throw new Exception("Toolbox already exists");
            _toolboxCollection.InsertOne(value);
            return toolbox;
        }

        public Toolbox Update(Toolbox toolbox)
        {
            _toolboxCollection.ReplaceOne<>(tb => tb.ToolboxId == toolbox.ToolboxId, toolbox);
            return toolbox;
        }

        public void Delete(string id)
        {
            _toolboxCollection.DeleteOne(id);
        }
    }
}
