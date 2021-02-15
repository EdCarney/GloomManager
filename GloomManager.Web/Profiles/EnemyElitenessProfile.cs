using AutoMapper;
using GloomManager.Core;
using GloomManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloomManager.Web.Profiles
{
    public class EnemyElitenessProfile : Profile
    {
        public EnemyElitenessProfile()
        {
            CreateMap<EnemyEliteness, EnemyElitenessViewModel>();
        }
    }
}
