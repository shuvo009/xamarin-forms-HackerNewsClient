using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;
using HackerNewsClient.Core.Models;
using HackerNewsClient.Repository.DbModel;

namespace HackerNewsClient.Repository
{
    public class AutoMapperStarter
    {
        public void Initialize()
        {
            var mapperConfigurationExpression = new MapperConfigurationExpression();
            mapperConfigurationExpression.AddProfile(new AutoMapperProfile());
            
            Mapper.Initialize(mapperConfigurationExpression);
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ItemModel, ItemDbModel>().ReverseMap();
        }
    }
}
