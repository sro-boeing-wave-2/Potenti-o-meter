﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Result.Models
{
    public class UserResults
    {
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId InternalId { get; set; }

        public int UserId { get; set; }

        public string DomainName { get; set; }

        public double AverageScore { get; set; }

        public double[] Scores { get; set; }

        public DateTime Time { get; set; }
    }
}
