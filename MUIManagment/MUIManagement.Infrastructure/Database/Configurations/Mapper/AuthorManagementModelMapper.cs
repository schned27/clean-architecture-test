using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Infrastructure.Database.Entities;

namespace MUIManagement.Infrastructure.Database.Configurations.Mapper
{
    public class AuthorManagementModelMapper : Profile
    {
        public AuthorManagementModelMapper()
        {
            CreateMap<AuthorManagementModel, AuthorEntity>().ReverseMap();
        }
    }
}
