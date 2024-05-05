using AutoMapper;
using CodeQuest.Data;
using CodeQuest.Data.Dtos.Usuario;

namespace CodeQuest.Models.Profiles
{
    public class UsuarioProfile:Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
