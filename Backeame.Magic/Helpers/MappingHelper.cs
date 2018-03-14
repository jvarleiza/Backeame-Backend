using AutoMapper;
using Backeame.Data.Entities;
using Backeame.Magic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Magic.Helpers
{
    public static class MappingHelper
    {
        public static void CreateMappers()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
            });
        }        
    }
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<Project, ProjectShallowDTO>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Reward, RewardDTO>();
            CreateMap<RewardDTO, Reward>();
        }
    }
}
