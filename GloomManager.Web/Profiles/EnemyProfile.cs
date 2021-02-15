﻿using AutoMapper;
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
                .ForMember(dest => dest.Eliteness,
                           opt => opt.MapFrom(src => src.Eliteness.ToString()))
                .ForMember(dest => dest.Stats,
                           opt => opt.MapFrom(src => src.BaseStats));
        }
    }
}