using CodeQuest.Repository.Dtos.Topico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Repository.Services.Interface
{
    public interface IQuestaoTopicoService
    {
        Task<bool> PostSalvaQuestaoTopicoAsync(TopicoDto topicoDto, int userId);
    }
}
