using Stock_API.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stock_API.Application.Interfaces
{
    public interface IPlayerScoreRepository
    {
        Task<List<PlayerScore>> GetLeaderboard();
        Task<PlayerScore> Add(PlayerScore playerScore);
        Task<PlayerScore> Update(PlayerScore playerScore);
        Task<PlayerScore> GetPlayerScore(string Id);
    }
}
