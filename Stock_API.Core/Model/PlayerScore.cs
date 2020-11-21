using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_API.Core.Model
{
    public class PlayerScore
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public string Id { get; set; }
        public string SessionId { get; set; }
        public double Score { get; set; }
        public double Balance { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string Name { get; set; }
    }
}
