using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoMongoApi.Models
{
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("IdNum")]
        public long IdNum { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("IsComplete")]
        public bool IsComplete { get; set; }
    }
}
