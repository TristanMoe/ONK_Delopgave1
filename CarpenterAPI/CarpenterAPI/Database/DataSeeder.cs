using CarpenterAPI.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpenterAPI.Database
{
    public class DataSeeder
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private readonly string _connectionstring;

        private IMongoCollection<Craftsman> _craftsmanCollection;

        public DataSeeder(string connectionString)
        {
            _connectionstring = connectionString;
            _client = new MongoClient(_connectionstring);
            _db = _client.GetDatabase("CraftsmanDb");

            _db.DropCollectionAsync("Craftsmen");
            _db.CreateCollectionAsync("Craftsmen");

            _craftsmanCollection = _db.GetCollection<Craftsman>("Craftsmen");

            // Dataseeding
            var Henry = new Craftsman()
            {
                CraftsmanId = "5cdd705eace4a36e8c3ca1A1",
                Firstname = "Henry",
                Surname = "Jensen",
                EmploymentDate = DateTime.Today,
                SubjectArea = "Carpenter",
                ToolBoxes = new List<Toolbox>()
            };

            var Bob = new Craftsman()
            {
                CraftsmanId = "5cdd705eace4a36e8c3ca1A2",
                Firstname = "Bob",
                Surname = "Pedersen",
                EmploymentDate = DateTime.Today,
                SubjectArea = "Carpenter",
                ToolBoxes = new List<Toolbox>()
            };


            _craftsmanCollection.InsertOne(Henry);
            _craftsmanCollection.InsertOne(Bob);
        }
    }
}
