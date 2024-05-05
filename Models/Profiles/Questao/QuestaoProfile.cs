using AutoMapper;
using CodeQuest.Data.Dtos.Login;
using CodeQuest.Data.Dtos.Questao;

namespace CodeQuest.Models.Profiles.Qustao
{
    public class QuestaoProfile : Profile
    {
        public QuestaoProfile()
        {
            CreateMap<QuestaoDto, Questao>();
        }

    }
}
