using AutoMapper;
using GloomManager.Core;
using GloomManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloomManager.Web.Profiles
{
    public class EnemyProfile : Profile
    {
        public EnemyProfile()
        {
            CreateMap<Enemy, EnemyViewModel>()
                .ForMember(dest => dest.Stats,
                           opt => opt.MapFrom(src => src.BaseStats))
                .ReverseMap();

            // CreateMap<EnemyViewModel, Enemy>()
            //     .ForMember(dest => dest.Eliteness,
            //                opt => opt.MapFrom(src => src.Eliteness))
            //     .ForMember(dest => dest.BaseStats,
            //                opt => opt.MapFrom(src => src.Stats))
            //     .ForMember(dest => dest.Type,
            //                opt => opt.MapFrom(src => src.Stats.Type));
        }
    }
}
