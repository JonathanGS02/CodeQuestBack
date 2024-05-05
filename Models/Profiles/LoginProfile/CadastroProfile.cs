using AutoMapper;
using CodeQuest.Data.Dtos.Login;

namespace CodeQuest.Models.Profiles.LoginProfile
{
    public class CadastroProfile : Profile
    {
        public CadastroProfile() 
        {
            CreateMap<CreateCadastroDto, Cadastro>();
        }
    }
}
