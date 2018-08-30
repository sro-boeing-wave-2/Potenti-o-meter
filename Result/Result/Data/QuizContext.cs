using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Result.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Result.Data
{
    public class QuizContext
    {
        private readonly IMongoDatabase _database = null;

        public QuizContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Quizes> Quizes
        {
            get
            {
                return _database.GetCollection<Quizes>("Quizes");
            }
        }

        public IMongoCollection<UserResults> UserResults
        {
            get
            {
                return _database.GetCollection<UserResults>("UserResults");
            }
        }



    }
}
