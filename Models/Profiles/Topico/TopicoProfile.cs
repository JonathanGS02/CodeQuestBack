using AutoMapper;
using CodeQuest.Data;

namespace CodeQuest.Models.Profiles.QuestaoProfile
{
    public class TopicoProfile:Profile
    {
        public TopicoProfile()
        {
            CreateMap<TopicoDto, Topico>();
        }
    }
}
