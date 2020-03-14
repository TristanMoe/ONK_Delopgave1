using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CarpenterAPI.Domain
{
    public class Tool
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ToolId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Purchased { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ToolBoxId { get; set; }
        public string OwnerId { get; set; }
    }
}
