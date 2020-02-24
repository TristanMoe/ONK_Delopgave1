using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpenterAPI.Domain
{
    public class Toolbox
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ToolboxId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Purchased { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string OwnerId { get; set; }
        public List<Tool> Tools { get; set; }
    }
}
