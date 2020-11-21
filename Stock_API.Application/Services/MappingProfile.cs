using AutoMapper;
using Stock_API.Application.Services.Leaderboard.Dto;
using Stock_API.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_API.Application.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PlayerScore,PlayerScoreDto>();
        }
    }
}
