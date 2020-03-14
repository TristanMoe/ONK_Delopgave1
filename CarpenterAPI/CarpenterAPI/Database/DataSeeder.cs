using CarpenterAPI.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace CarpenterAPI.Database
{
    public class DataSeeder
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private readonly string _connectionstring;

        private IMongoCollection<Craftsman> _craftsmanCollection;
        private IMongoCollection<Toolbox> _toolboxCollection;
        private IMongoCollection<Tool> _toolCollection;

        public DataSeeder(string connectionString)
        {
            _connectionstring = connectionString;
            _client = new MongoClient(_connectionstring);
            _db = _client.GetDatabase("CraftsmanDb");

            _db.DropCollectionAsync("Craftsmen");
            _db.DropCollectionAsync("Toolboxes");
            _db.DropCollectionAsync("Tools");
            _db.CreateCollectionAsync("Craftsmen");
            _db.CreateCollectionAsync("ToolBoxes");
            _db.CreateCollectionAsync("Tools");

            _craftsmanCollection = _db.GetCollection<Craftsman>("Craftsmen");
            _toolboxCollection = _db.GetCollection<Toolbox>("Toolboxes");
            _toolCollection = _db.GetCollection<Tool>("Tools");

            // Dataseeding
            var hammer = new Tool()
            {
                ToolId = "5cdd705eace4a36e8c3ca1C1",
                Purchased = DateTime.Today,
                Color = "Black",
                Brand = "M.C.",
                Model = "Hammer",
                SerialNumber = "4CE0460D0F",
                ToolBoxId = "5cdd705eace4a36e8c3ca1B1",
                OwnerId = "5cdd705eace4a36e8c3ca1A1"
            };
            
            var screwdriver = new Tool()
            {
                ToolId = "5cdd705eace4a36e8c3ca1C2",
                Purchased = DateTime.Today,
                Brand = "Tools 'r' us",
                Color = "White",
                Model = "Flathead screwdriver",
                SerialNumber = "4CE0460D0M",
                ToolBoxId = "5cdd705eace4a36e8c3ca1B1",
                OwnerId = "5cdd705eace4a36e8c3ca1A1"
            };

            var toolbox1 = new Toolbox()
            {
                ToolboxId = "5cdd705eace4a36e8c3ca1B1",
                Purchased = DateTime.Today,
                Brand = "Black & Decker",
                Model = "Deluxe",
                SerialNumber = "4CE0460D0H",
                Type = "Ze best",
                Tools = new List<Tool> {hammer, screwdriver},
                OwnerId = "5cdd705eace4a36e8c3ca1A1"
            };

            var henry = new Craftsman()
            {
                CraftsmanId = "5cdd705eace4a36e8c3ca1A1",
                Firstname = "Henry",
                Surname = "Jensen",
                EmploymentDate = DateTime.Today,
                SubjectArea = "Carpenter",
                ToolBoxes = new List<Toolbox> { toolbox1 }
            };

            _toolboxCollection.InsertOneAsync(toolbox1);
            _craftsmanCollection.InsertOneAsync(henry);
            _toolCollection.InsertMany(new [] {hammer, screwdriver});
        }
    }
}