using AutoMapper;
using CodeQuest.Domain;
using CodeQuest.Repository.Data;
using CodeQuest.Repository.Dtos.Topico;
using CodeQuest.Repository.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodeQuest.Repository.Services.Repository
{
    public class QuestaoTopicoRepository : IQuestaoTopicoService
    {

        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;
        private readonly Context _context;

        public QuestaoTopicoRepository(IGeralPersist geralPersist, IMapper mapper, Context context)
        {
            _geralPersist = geralPersist;
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> PostSalvaQuestaoTopicoAsync(TopicoDto topicoDto, int userId)
        {
            try
            {
                var questaoTopico = new QuestaoTopico
                {
                    QuestaoId = topicoDto.Questoes.First().QuestaoId,
                    TopicoId = topicoDto.TopicoId,
                    UserId = userId
                };

                _geralPersist.Add<QuestaoTopico>(questaoTopico);

                if (await _geralPersist.SaveChangesAsync())
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
