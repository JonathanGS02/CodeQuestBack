using AutoMapper;
using CodeQuest.Domain.Identity;
using CodeQuest.Repository.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Repository.Helpers
{
    public class CodeQuestProfile : Profile
    {

        public CodeQuestProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
