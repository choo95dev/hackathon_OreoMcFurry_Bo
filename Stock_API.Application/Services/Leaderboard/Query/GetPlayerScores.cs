using AutoMapper;
using MediatR;
using Stock_API.Application.Interfaces;
using Stock_API.Application.Services.Leaderboard.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_API.Application.Services.Leaderboard.Query
{
    public class GetPlayerScores : IRequest<List<PlayerScoreDto>>
    {
    }

    public class GetPlayerScoresHandler : IRequestHandler<GetPlayerScores, List<PlayerScoreDto>>
    {
        private readonly IPlayerScoreRepository _playerScoreRepository;
        private readonly IMapper _mapper;

        public GetPlayerScoresHandler(IPlayerScoreRepository playerScoreRepository,IMapper mapper)
        {
            _playerScoreRepository = playerScoreRepository;
            _mapper = mapper;
        }

        public async Task<List<PlayerScoreDto>> Handle(GetPlayerScores request, CancellationToken cancellationToken)
        {
            var playerScores = await _playerScoreRepository.GetLeaderboard();

            var list = _mapper.Map<List<PlayerScoreDto>>(playerScores);

            return list;
        }
    }
}
