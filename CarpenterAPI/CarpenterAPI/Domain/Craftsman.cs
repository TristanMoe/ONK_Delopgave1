using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpenterAPI.Domain
{
    public class Craftsman
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CraftsmanId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EmploymentDate { get; set; }
        public string Surname { get; set; }
        public string SubjectArea { get; set; }
        public string Firstname { get; set; }
        public List<Toolbox> ToolBoxes { get; set; }
    }
}
