using AutoMapper;
using Ecommerce.Aplicattion.Dtos.ViewModels;
using Ecommerce.Core.Entities;
using System.Collections.Generic;

namespace Api.MiniEcommerce
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
