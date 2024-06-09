using AutoMapper;
using CodeQuest.Domain;
using CodeQuest.Domain.Identity;
using CodeQuest.Repository.Data;
using CodeQuest.Repository.Dtos.Questao;
using CodeQuest.Repository.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Repository.Services.Repository
{
    public class QuestaoRepository : IQuestaoService
    {

        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;
        private readonly Context _context;
        public QuestaoRepository(IGeralPersist geralPersist, IMapper mapper, Context context)
        {
            _geralPersist = geralPersist;
            _mapper = mapper;
            _context = context;
        }


        public async Task<string> AddQuestao(int userId, QuestaoDto model)
        {
            try
            {
                var questao = _mapper.Map<Questao>(model);
                questao.UserId = userId;
                _geralPersist.Add<Questao>(questao);

                if (await _geralPersist.SaveChangesAsync())
                    return "Questão Adicionada com Sucesso!";

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> UpdateQuestao(int userId, Guid id, QuestaoDto model)
        {
            try
            {
                var questao = await _context.Questoes.Where(x => x.QuestaoId == id).FirstOrDefaultAsync();

                if (questao == null)
                {
                    return null;
                }

                model.QuestaoId = questao.QuestaoId;
                model.UserId = userId;
                _mapper.Map(model, questao);

                _geralPersist.Update<Questao>(questao);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return "Questão atualizada com Sucesso!";
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteQuestao(int userId, Guid questaoId)
        {
            try
            {
                var questao = await _context.Questoes.Where(x => x.QuestaoId == questaoId).FirstOrDefaultAsync();

                if (questao == null)
                {
                    throw new Exception("Questão não encontrado.");
                }

                _geralPersist.Delete<Questao>(questao);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuestaoDto[]> GetAllQuestaoAsync()
        {
            try
            {
                var questoes = await _context.Questoes.ToListAsync();

                if (questoes == null)
                    return null;

                var resultado = _mapper.Map<QuestaoDto[]>(questoes);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuestaoDto> GetQuestaoByIdAsync(Guid questaoId)
        {
            try
            {
                var questao = await _context.Questoes.Where(x => x.QuestaoId == questaoId).FirstOrDefaultAsync();

                if (questao == null)
                    return null;

                var resultado = _mapper.Map<QuestaoDto>(questao);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
