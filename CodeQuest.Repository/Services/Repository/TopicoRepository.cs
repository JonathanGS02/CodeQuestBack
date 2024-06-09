using AutoMapper;
using CodeQuest.Domain;
using CodeQuest.Repository.Data;
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

        public TopicoRepository(IGeralPersist geralPersist, IMapper mapper, Context context)
        {
            _geralPersist = geralPersist;
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> AddTopico(int userId, TopicoDto model)
        {
            try
            {
                var topico = _mapper.Map<Topico>(model);
                topico.UserId = userId;
                _geralPersist.Add<Topico>(topico);

                if (await _geralPersist.SaveChangesAsync())
                    return "Topico Adicionado com Sucesso!";

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
                var topicos = await _context.Topicos.ToListAsync();

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
