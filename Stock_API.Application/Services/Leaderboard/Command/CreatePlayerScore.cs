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
    public class CreatePlayerScore : IRequest<PlayerScore>
    {
        public double Score { get; set; }
        public double Balance { get; set; }
        public string SessionId { get; set; }
        public string Name { get; set; }
    }

    public class CreatePlayerScoreHandler : IRequestHandler<CreatePlayerScore, PlayerScore>
    {
        private readonly IPlayerScoreRepository _playerScoreRepository;

        public CreatePlayerScoreHandler(IPlayerScoreRepository playerScoreRepository)
        {
            _playerScoreRepository = playerScoreRepository;
        }

        public async Task<PlayerScore> Handle(CreatePlayerScore request, CancellationToken cancellationToken)
        {
            var playerScore = new PlayerScore
            {
                Score = request.Score,
                SessionId =  request.SessionId,
                Balance = request.Balance,
                Id = DateTime.Now.ToString("yyyyMMddHHmmssffff") + request.SessionId,
                LastUpdatedDate = DateTime.Now,
                Name = request.Name
            };

            var insert = await _playerScoreRepository.Add(playerScore);
            return insert;
        }
    }
}
