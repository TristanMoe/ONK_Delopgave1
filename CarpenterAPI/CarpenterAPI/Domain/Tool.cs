using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpenterAPI.Domain
{
    public class Tool
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ToolId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Purchased { get; set; }
        public Craftsman Owner { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ToolBoxId { get; set; }
    }
}
