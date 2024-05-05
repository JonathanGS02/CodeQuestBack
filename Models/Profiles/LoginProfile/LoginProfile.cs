using AutoMapper;
using CodeQuest.Data.Dtos.Login;

namespace CodeQuest.Models.Profiles.LoginProfile
{
    public class LoginProfile : Profile
    {
        public LoginProfile() 
        {
            CreateMap<LoginDto, Login>();
        }
    }
}
