using AutoMapper;
using CodeQuest.Domain;
using CodeQuest.Repository.Data;
using CodeQuest.Repository.Dtos.Questao;
using CodeQuest.Repository.Dtos.Topico;
using CodeQuest.Repository.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodeQuest.Repository.Services.Repository
{
    public class TopicoRepository : ITopicoService
    {

        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly IQuestaoTopicoService _questaoTopicoService;

        public TopicoRepository(IGeralPersist geralPersist, IMapper mapper, Context context, IQuestaoTopicoService questaoTopicoService)
        {
            _geralPersist = geralPersist;
            _mapper = mapper;
            _context = context;
            _questaoTopicoService = questaoTopicoService;
        }

        public async Task<string> AddTopico(int userId, TopicoDto model)
        {
            try
            {
                //var topico = _mapper.Map<Topico>(model);
                //topico.UserId = userId;

                var topico = new Topico
                {
                    Nivel = model.Nivel,
                    Numero = model.Numero,
                    QtdQuestoes = model.QtdQuestoes,
                    UserId = userId
                };

                _geralPersist.Add<Topico>(topico);

                if (await _geralPersist.SaveChangesAsync())
                {
                    foreach (var item in model.Questoes)
                    {
                        var questaoTopico = new QuestaoTopico
                        {
                            TopicoId = topico.TopicoId,
                            QuestaoId = (Guid)item.QuestaoId,
                            UserId = userId
                        };
                        _geralPersist.Add<QuestaoTopico>(questaoTopico);
                        await _geralPersist.SaveChangesAsync();
                    }

                    return "Topico Adicionado com Sucesso!";
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTopico(int userId, Guid topicoId)
        {
            try
            {
                var topico = await _context.Topicos.Where(x => x.TopicoId == topicoId).FirstOrDefaultAsync();

                if (topico == null)
                {
                    throw new Exception("Topico não encontrado.");
                }

                _geralPersist.Delete<Topico>(topico);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TopicoDto[]> GetAllTopicoAsync()
        {
            try
            {
                var topicos = await _context.Topicos
                                            .Include(i => i.QuestaoTopicos)
                                            .ThenInclude(i => i.Questao)
                                            .ToListAsync();

                if (topicos == null)
                    return null;

                var resultado = _mapper.Map<TopicoDto[]>(topicos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TopicoDto> GetTopicoByIdAsync(Guid topicoId)
        {
            try
            {
                var topico = await _context.Topicos.Where(x => x.TopicoId == topicoId).FirstOrDefaultAsync();

                if (topico == null)
                    return null;

                var resultado = _mapper.Map<TopicoDto>(topico);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TopicoDto> GetTopicoByRandomAsync(int nivel)
        {
            try
            {
                var topico = await _context.Topicos
                                            .Where(x => x.Nivel == nivel)
                                            .Include(i => i.QuestaoTopicos)
                                            .OrderBy(x => Guid.NewGuid())
                                            .FirstOrDefaultAsync();

                var qt = await _context.QuestaoTopicos.Where(x => x.TopicoId == topico.TopicoId).ToListAsync();
                var range = qt.Count();
                var random = new Random();
                var sortRange = random.Next(0, range) - 1;
                sortRange = sortRange < 0 ? 0 : sortRange;
                var sortRange2 = qt[0].QuestaoId;
                var questao = await _context.Questoes.Where(x => x.QuestaoId == qt[sortRange].QuestaoId).FirstOrDefaultAsync();

                var resultado = _mapper.Map<TopicoDto>(topico);
                var resultado2 = _mapper.Map<QuestaoDto>(questao);
                resultado.Questao = resultado2;

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> UpdateTopico(int userId, Guid id, TopicoDto model)
        {
            try
            {
                var topico = await _context.Topicos.Where(x => x.TopicoId == id).FirstOrDefaultAsync();

                if (topico == null)
                {
                    return null;
                }

                model.TopicoId = topico.TopicoId;
                model.UserId = userId;
                _mapper.Map(model, topico);

                _geralPersist.Update<Topico>(topico);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return "Topico atualizado com Sucesso!";
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
