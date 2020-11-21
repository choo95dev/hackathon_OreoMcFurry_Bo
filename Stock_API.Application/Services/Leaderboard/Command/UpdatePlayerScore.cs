using MediatR;
using Stock_API.Application.Interfaces;
using Stock_API.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_API.Application.Services.Leaderboard.Command
{
    public class UpdatePlayerScore : IRequest<PlayerScore>
    {
        public double Score { get; set; }
        public double Balance { get; set; }
        public string SessionId { get; set; }
    }

    public class UpdatePlayerScoreHandler : IRequestHandler<UpdatePlayerScore, PlayerScore>
    {
        private readonly IPlayerScoreRepository _playerScoreRepository;

        public UpdatePlayerScoreHandler(IPlayerScoreRepository playerScoreRepository)
        {
            _playerScoreRepository = playerScoreRepository;
        }

        public async Task<PlayerScore> Handle(UpdatePlayerScore request, CancellationToken cancellationToken)
        {
            var playerScore = await _playerScoreRepository.GetPlayerScore(request.SessionId);

            playerScore.Balance = request.Balance;
            playerScore.Score = request.Score;

            var insert = await _playerScoreRepository.Update(playerScore);
            return insert;
        }
    }
}
