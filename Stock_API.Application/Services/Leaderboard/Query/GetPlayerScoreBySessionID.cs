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
    public class GetPlayerScoreBySessionID : IRequest<PlayerScoreDto>
    {
        public string SessionID;
    }

    public class GetPlayerScoreBySessionIDHandler : IRequestHandler<GetPlayerScoreBySessionID, PlayerScoreDto>
    {
        private readonly IPlayerScoreRepository _playerScoreRepository;
        private readonly IMapper _mapper;

        public GetPlayerScoreBySessionIDHandler(IPlayerScoreRepository playerScoreRepository,IMapper mapper)
        {
            _playerScoreRepository = playerScoreRepository;
            _mapper = mapper;
        }

        public async Task<PlayerScoreDto> Handle(GetPlayerScoreBySessionID request, CancellationToken cancellationToken)
        {
            var playerScore = await _playerScoreRepository.GetPlayerScore(request.SessionID);

            var dto = _mapper.Map<PlayerScoreDto>(playerScore);
            return dto;
        }
    }
}
