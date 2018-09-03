﻿using Microsoft.Extensions.Options;
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

        public IMongoCollection<Quiz> Quiz
        {
            get
            {
                return _database.GetCollection<Quiz>("Quiz");
            }
        }

<<<<<<< Updated upstream
        public IMongoCollection<UserResults> UserResults
=======
        public IMongoCollection<UserResult> userResult
>>>>>>> Stashed changes
        {
            get
            {
                return _database.GetCollection<UserResult>("UserResult");
            }
        }



    }
}
