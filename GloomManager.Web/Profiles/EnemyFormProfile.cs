using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloomManager.Core.Enemy;
using GloomManager.Web.Models;

namespace GloomManager.Web.Profiles
{
    public class EnemyFormProfile : Profile
    {
        public EnemyFormProfile()
        {
            CreateMap<Enemy, Enemy>();

            CreateMap<Stats, Stats>();

            CreateMap<SpecialAbility, SpecialAbility>();

            CreateMap<Enemy, EnemyFormViewModel>()
                .ForMember(dest => dest.Enemy,
                           opt => opt.MapFrom(src => src))
                .ReverseMap();
        }
    }
}
