using CodeQuest.Repository.Dtos.Questao;
using CodeQuest.Repository.Dtos.Topico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Repository.Services.Interface
{
    public interface ITopicoService
    {
        Task<string> AddTopico(int userId, TopicoDto model);
        Task<string> UpdateTopico(int userId, Guid id, TopicoDto model);
        Task<bool> DeleteTopico(int userId, Guid topicoId);

        Task<TopicoDto[]> GetAllTopicoAsync();
        Task<TopicoDto> GetTopicoByIdAsync(Guid topicoId);
    }
}
