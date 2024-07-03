using AutoMapper;
using CodeQuest.Domain;
using CodeQuest.Domain.Identity;
using CodeQuest.Repository.Dtos.Questao;
using CodeQuest.Repository.Dtos.Topico;
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

            CreateMap<Questao, QuestaoDto>().ReverseMap();
            CreateMap<Topico, TopicoDto>().ReverseMap();

        }
    }
}
