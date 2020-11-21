using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_API.Application.Services.Leaderboard.Dto
{
    public class PlayerScoreDto
    {
        public string SessionId { get; set; }
        public double Score { get; set; }
        public double Balance { get; set; }
        public string Id { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
