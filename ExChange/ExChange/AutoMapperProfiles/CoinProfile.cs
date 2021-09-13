using AutoMapper;
using Domain.Dtos.Coin;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.AutoMapperProfiles
{
    public class CoinProfile : Profile
    {
        public CoinProfile()
        {
            CreateMap<CoinDto, Coin>().ReverseMap();
        }
    }
}
