using MongoDB.Driver;
using Stock_API.Application.Interfaces;
using Stock_API.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stock_API.Infrastructure.Repository
{
    public class PlayerScoreRepository : MongoDBRepository,IPlayerScoreRepository
    {

        public PlayerScoreRepository(MongoDBContext context) : base(context)
        {

        }


        public async Task<PlayerScore> Add(PlayerScore playerScore)
        {
            await _context.PlayerScore.InsertOneAsync(playerScore);

            return playerScore;
        }

        public async Task<List<PlayerScore>> GetLeaderboard()
        {
            return await _context.PlayerScore
                     .Find(_ => true).ToListAsync();
        }

        public async Task<PlayerScore> GetPlayerScore(string SessionID)
        {
            var filter = Builders<PlayerScore>.Filter.Eq(s => s.SessionId,SessionID);
            var playerScore = await _context.PlayerScore.Find(filter).FirstOrDefaultAsync();
            return playerScore;
        }

        public async Task<PlayerScore> Update(PlayerScore playerScore)
        {
            var filter = Builders<PlayerScore>.Filter.Eq(s => s.Id,playerScore.Id);
            var update = Builders<PlayerScore>.Update
                            .Set(s => s.Score, playerScore.Score)
                            .Set(s => s.Balance, playerScore.Balance)
                            .CurrentDate(s=>s.LastUpdatedDate);

            var actionResult = await _context.PlayerScore.UpdateOneAsync(filter, update);

            return playerScore;
        }
    }
}
