using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Stock_API.Application.Interfaces;
using Stock_API.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_API.Infrastructure.Repository
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _db = null;
        private readonly IConfiguration _configuration;


        public MongoDBContext(IConfiguration configuration)
        {
            _configuration = configuration;

            var client = new MongoClient(_configuration["MongoDB:Uri"]);
            if(client !=null)
            {
                _db = client.GetDatabase(_configuration["MongoDB:DBName"]);
            }

        }

        public IMongoCollection<PlayerScore> PlayerScore
        {
            get
            {
                return _db.GetCollection<PlayerScore>("PlayerScore");
            }
        }
    }
}
